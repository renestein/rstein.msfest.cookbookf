using RStein.Cookbook.Business.Core;

namespace RStein.Cookbook.Business.EF.Configuration
{
  public class RecipeConfiguration : CommonConfiguration<Recipe>
  {
    public RecipeConfiguration()
    {
      HasMany(recipe => recipe.Tags).WithMany();
    }
  }
}