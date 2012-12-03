using RStein.Cookbook.Business.Core;

namespace RStein.Cookbook.Business.EF.Configuration
{
  public class RecipeCategoryConfiguration : CommonConfiguration<RecipeCategory>
  {
    public RecipeCategoryConfiguration()
    {
      HasMany(category => category.Recipes).WithRequired(recipe => recipe.Category);
    }
  }
}