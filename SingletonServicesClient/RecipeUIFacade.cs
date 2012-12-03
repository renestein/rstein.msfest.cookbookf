using RStein.Cookbook.ExportServices;
using SingletonServices;

namespace SingletonServicesClient
{
  internal class RecipeUIFacade
  {
    public const string EXPORT_MESSAGE = "Exporting - {0} ";

    public void ExportAllRecipes()
    {
      var repository = DefaultRepositoryHolder.Instance.RecipeRepository;
      IExporter exporter = new WordExporter();

      foreach (var recipe in repository.GetObjectsQuery())
      {
        exporter.ExportRecipe(recipe);
      }
    }
  }
}