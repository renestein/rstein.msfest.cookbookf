
using RStein.Cookbook.Business.Core;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.ServiceModel.DomainServices.EntityFramework;
using System.ServiceModel.DomainServices.Hosting;
using RStein.Cookbook.Business.EF;

namespace RStein.Cookbook.SL.Web.Services
{
  // Implements application logic using the CookbookContext context.
  // TODO: Add your application logic to these methods or in additional methods.
  // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
  // Also consider adding roles to restrict access as appropriate.
  // [RequiresAuthentication]
  [EnableClientAccess()]
  public class CookbookService : DbDomainService<CookbookContext>
  {
    public IQueryable<Recipe> GetRecipes()
    {
      return this.DbContext.Recipes;
    }

    public void InsertRecipe(Recipe recipe)
    {
      DbEntityEntry<Recipe> entityEntry = this.DbContext.Entry(recipe);

      if ((entityEntry.State != EntityState.Detached))
      {
        entityEntry.State = EntityState.Added;
      }
      else
      {
        this.DbContext.Recipes.Add(recipe);
      }
    }

    public void UpdateRecipe(Recipe recipe)
    {
      this.DbContext.Recipes.AttachAsModified(recipe, this.ChangeSet.GetOriginal(recipe), this.DbContext);
    }

    public void DeleteRecipe(Recipe recipe)
    {
      DbEntityEntry<Recipe> entityEntry = this.DbContext.Entry(recipe);

      if ((entityEntry.State != EntityState.Deleted))
      {
        entityEntry.State = EntityState.Deleted;
      }
      else
      {
        this.DbContext.Recipes.Attach(recipe);
        this.DbContext.Recipes.Remove(recipe);
      }
    }
  }
}


