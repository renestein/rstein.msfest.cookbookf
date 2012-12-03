using System.Data.Entity.ModelConfiguration;
using RStein.Cookbook.Business.Core;

namespace RStein.Cookbook.Business.EF.Configuration
{
  public abstract class CommonConfiguration<T> : EntityTypeConfiguration<T>, IEfConfiguration
    where T : BusinessObjectBase
  {
    protected CommonConfiguration()
    {
      Map(mapping =>
            {
              mapping.ToTable(typeof (T).Name);
            });
    }
  }
}