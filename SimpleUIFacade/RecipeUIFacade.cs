using System;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;
using RStein.Cookbook.ExportServices;

namespace SimpleUIFacade
{
  public class RecipeUIFacade
  {
    public const string EXPORT_MESSAGE = "Exporting - {0} ";
    private readonly IExporter m_exporter;
    private readonly IRepository<Recipe> m_recipeRepository;

    public RecipeUIFacade(IRepository<Recipe> recipeRepository, IExporter exporter)
    {
      if (recipeRepository == null)
      {
        throw new ArgumentNullException("recipeRepository");
      }

      if (exporter == null)
      {
        throw new ArgumentNullException("exporter");
      }

      m_recipeRepository = recipeRepository;
      m_exporter = exporter;
    }

    public void ExportAllRecipes()
    {
      foreach (var recipe in m_recipeRepository.GetObjectsQuery())
      {
        m_exporter.ExportRecipe(recipe);
      }
    }
  }
}