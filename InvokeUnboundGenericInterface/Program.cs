using System;
using System.Collections.Generic;
using System.Linq;
using InvokeUnboundGenericInterface.Data;
using InvokeUnboundGenericInterface.Interface;

namespace InvokeUnboundGenericInterface
{
  internal class Program
  {
    private static void Main()
    {
      var fromList = new List<BaseObject>
      {
        new A(1,1),
        new B(2,"Value 1"),
        new C(3,"Fixed"),
        new A(4,2),
        new A(5,3),
      };
      var toList = new List<BaseObject>
      {
        new A(1,10),
        new B(2,"Value 1 updated"),
        new C(2,"Fixed updated"), // Notice this value !!
        new C(3,"Fixed updated"),
        new A(4,200),
        new A(5,359),
      };
      PrintList(fromList);
      Console.WriteLine("Copy data from toList to fromList");
      CopyList(fromList, toList);
      PrintList(fromList);
      // When watched closely you'll see that C[2] doesn't create a crash and that C is also ignored because there isn't a not implemented exception thrown.
      Console.ReadLine();
    }

    private static void CopyList(List<BaseObject> fromList, List<BaseObject> toList)
    {
      var filteredFrom = from o in fromList
                           // Find the objects that implement the interface IDoSomething<>, notice that this is unbound
                         let oInterface = o.GetType().GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDoSomething<>))
                         // Not all the objects implement the interface so check that we only use the ones that use it.
                         where oInterface != null
                         // Here we already take the copy method that we'll need to use
                         let oM = oInterface.GetMethod("Copy")
                         // Select the object and the method
                         select new { From = o, Method = oM };

      // Enumerate the query
      foreach (var data in filteredFrom)
      {
        // Find the corresponding to object that matches the type.
        var to = toList.FirstOrDefault(x => x.Id == data.From.Id && x.GetType() == data.From.GetType());
        if (to != null)
        {
          // Invoke the copy method with the to object.
          data.Method.Invoke(data.From, new object[] { to });
        }
      }
    }

    private static void PrintList(List<BaseObject> list)
    {
      list.ForEach(Console.WriteLine);
    }
  }
}
