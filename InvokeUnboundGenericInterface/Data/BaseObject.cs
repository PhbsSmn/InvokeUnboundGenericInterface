namespace InvokeUnboundGenericInterface.Data
{
  public abstract class BaseObject
  {
    #region Properties
    public byte Id { get; }
    #endregion

    #region Constructors
    protected BaseObject(byte id)
    {
      Id = id;
    }
    #endregion

    #region Methods
    protected abstract string GetPropertiesString();
    public override string ToString()
    {
      return $"{GetType().Name}[{Id}]({GetPropertiesString()})";
    }
    #endregion
  }
}