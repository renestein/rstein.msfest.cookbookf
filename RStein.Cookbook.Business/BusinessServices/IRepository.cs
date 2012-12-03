using System.Linq;

namespace RStein.Cookbook.Business.BusinessServices
{
  public interface IRepository<T>
    where T : class
  {
    T FindObjectById(int id);
    void AddObject(T newObject);
    void RemoveObject(T obj);
    void RemoveById(int id);
    IQueryable<T> GetObjectsQuery();
    int GetObjectsCount();
    void SaveChanges();
  }
}