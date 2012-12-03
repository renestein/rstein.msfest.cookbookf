using System;
using System.Linq;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;

namespace RStein.Cookbook.EF.EFServices
{
  public class DefaultEfRepository<T> : IRepository<T>
    where T : class, IBusinessEntity
  {
    private readonly CookbookMfContext m_context;

    public DefaultEfRepository(CookbookMfContext context)
    {
      if (context == null)
      {
        throw new ArgumentNullException("context");
      }

      m_context = context;
    }

    public T FindObjectById(int id)
    {
      return m_context.Set<T>().Find(id);
    }

    public void AddObject(T newObject)
    {
      m_context.Set<T>().Add(newObject);
    }

    public void RemoveObject(T objToRemove)
    {
      m_context.Set<T>().Remove(objToRemove);
    }

    public void RemoveById(int id)
    {
      T obj = FindObjectById(id);
      RemoveObject(obj);
    }

    public IQueryable<T> GetObjectsQuery()
    {
      return m_context.Set<T>();
    }

    public int GetObjectsCount()
    {
      return GetObjectsQuery().Count();
    }

    public void SaveChanges()
    {
      m_context.SaveChanges();
    }
  }
}