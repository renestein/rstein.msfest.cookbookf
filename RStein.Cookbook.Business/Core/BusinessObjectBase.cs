namespace RStein.Cookbook.Business.Core
{
  public abstract class BusinessObjectBase : IBusinessEntity
  {
    private int m_id;


    public virtual int Id
    {
      get
      {
        return m_id;
      }

      private set
      {
        m_id = value;
      }
    }

    public virtual bool IsDeleted
    {
      get;
      set;
    }
  }
}