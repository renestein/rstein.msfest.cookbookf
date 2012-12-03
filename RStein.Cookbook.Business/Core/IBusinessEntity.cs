namespace RStein.Cookbook.Business.Core
{
  public interface IBusinessEntity
  {
    int Id
    {
      get;
    }

    bool IsDeleted
    {
      get;
    }
  }
}