using InvokeUnboundGenericInterface.Interface;

namespace InvokeUnboundGenericInterface.Data
{
  public class B : BaseObject, IDoSomething<B>
  {
    #region Properties
    public string Value { get; set; }
    #endregion

    #region Constructors

    public B(byte id, string value) : base(id)
    {
      Value = value;
    }


    #endregion

    #region Methods
    public void Copy(B copyFrom)
    {
      Value = copyFrom.Value;
    }
    protected override string GetPropertiesString()
    {
      return $"'{Value}'";
    }
    #endregion
  }
}