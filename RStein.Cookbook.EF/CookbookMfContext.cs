using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using RStein.Cookbook.Business.Core;
using RStein.Cookbook.Business.EF.Configuration;

namespace RStein.Cookbook.EF
{
  public class CookbookMfContext : DbContext
  {
    private const string CODE_TABLE_NAME = "CodeTableBase";
    private const string BUSINESS_OBJECT_TABLE = "BusinessObjectBase";

    public DbSet<Recipe> Recipes
    {
      get;
      set;
    }

    public DbSet<RecipeCategory> RecipeCategories
    {
      get;
      set;
    }

    public DbSet<RecipeTag> RecipeTags
    {
      get;
      set;
    }

    public DbSet<Unit> Units
    {
      get;
      set;
    }

    public DbSet<Ingredient> Ingredients
    {
      get;
      set;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BusinessObjectBase>().ToTable(BUSINESS_OBJECT_TABLE);
      modelBuilder.Entity<CodeTableBase>().ToTable(CODE_TABLE_NAME);

      addConfigurations(modelBuilder);
      base.OnModelCreating(modelBuilder);
    }

    protected override void Dispose(bool disposing)
    {
      Trace.WriteLine("Recipes - context disposed");
      base.Dispose(disposing);
    }

    private void addConfigurations(DbModelBuilder modelBuilder)
    {
      Type efConfigType = typeof (IEfConfiguration);
      var configTypes = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(type => type.GetInterfaces().Contains(efConfigType) && !type.IsAbstract);

      foreach (dynamic efConfiguration in configTypes.Select(Activator.CreateInstance))
      {
        modelBuilder.Configurations.Add(efConfiguration);
      }
    }
  }
}