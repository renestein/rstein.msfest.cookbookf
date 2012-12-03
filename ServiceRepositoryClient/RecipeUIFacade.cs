using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;
using RStein.Cookbook.ExportServices;
using ServiceRepository;

namespace ServiceRepositoryClient
{
  internal class RecipeUIFacade
  {
    public const string EXPORT_MESSAGE = "Exporting - {0} ";

    public void ExportAllRecipes()
    {
      var repository = SimpleServiceRepository.Instance.GetService<IRepository<Recipe>>();
      IExporter exporter = SimpleServiceRepository.Instance.GetService<IExporter>();

      foreach (var recipe in repository.GetObjectsQuery())
      {
        exporter.ExportRecipe(recipe);
      }
    }
  }
}