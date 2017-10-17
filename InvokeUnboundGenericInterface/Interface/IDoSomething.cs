using System.ComponentModel;
using InvokeUnboundGenericInterface.Data;

namespace InvokeUnboundGenericInterface.Interface
{
  public interface IDoSomething<in T>
    where T : BaseObject
  {
    void Copy(T copyFrom);
  }
}