using InvokeUnboundGenericInterface.Interface;

namespace InvokeUnboundGenericInterface.Data
{
  public class A : BaseObject, IDoSomething<A>
  {
    #region Properties
    public int Number { get; set; }
    #endregion

    #region Constructors
    public A(byte id, int number) : base(id)
    {
      Number = number;
    }
    #endregion

    #region Methods
    public void Copy(A copyFrom)
    {
      Number = copyFrom.Number;
    }
    protected override string GetPropertiesString()
    {
      return $"'{Number}'";
    }
    #endregion
  }
}