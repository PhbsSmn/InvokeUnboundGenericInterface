namespace InvokeUnboundGenericInterface.Data
{
  public class C : BaseObject
  {
    #region Properties
    public string Value { get; set; }
    #endregion

    #region Constructors
    public C(byte id, string value) : base(id)
    {
      Value = value;
    }
    #endregion

    #region Methods
    public void Copy(C copyFrom)
    {
      // Interface not implemented, it shouldn't trigger.
      throw new System.NotImplementedException();
    }

    protected override string GetPropertiesString()
    {
      return $"'{Value}'";
    }
    #endregion
  }
}