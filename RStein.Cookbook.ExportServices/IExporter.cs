using RStein.Cookbook.Business.Core;

namespace RStein.Cookbook.ExportServices
{
  public interface IExporter
  {
    void ExportRecipe(Recipe recipe);
  }
}