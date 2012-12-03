using System;
using System.Collections.Generic;
using System.Linq;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;

namespace SimpleWebDI.Models
{
  //IBusinessEntity jen pro MS Fest - jinak používat view modely, DTO objekty a zapouzdřené dotazy.
  public class SimplePaginator<T>
    where T : class, IBusinessEntity
  {
    public SimplePaginator(IRepository<T> source, int pageIndex, int pageSize)
    {
      PageIndex = pageIndex;
      PageSize = pageSize;
      initProperties(source);
    }

    public int PageIndex
    {
      get;
      private set;
    }

    public int PageSize
    {
      get;
      private set;
    }


    public int TotalCount
    {
      get;
      private set;
    }

    public int TotalPages
    {
      get;
      private set;
    }

    public IEnumerable<T> DataSource
    {
      get;
      private set;
    }

    public bool HasPreviousPage
    {
      get
      {
        return (PageIndex > 0);
      }
    }

    public bool HasNextPage
    {
      get
      {
        return (PageIndex + 1 < TotalPages);
      }
    }

    public int? NextPage
    {
      get
      {
        return HasNextPage ? PageIndex + 1 : (int?) null;
      }
    }

    public int? PreviousPage
    {
      get
      {
        return HasPreviousPage ? PageIndex - 1 : (int?) null;
      }
    }

    private void initProperties(IRepository<T> source)
    {
      TotalCount = source.GetObjectsCount();
      TotalPages = (int) Math.Ceiling(TotalCount/(double) PageSize);
      DataSource = source.GetObjectsQuery().OrderBy(obj => obj.Id)
                         .Skip(PageIndex*PageSize)
                         .Take(PageSize).ToList();
    }
  }
}