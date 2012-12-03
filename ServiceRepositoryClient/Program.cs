using System;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;
using RStein.Cookbook.EF;
using RStein.Cookbook.EF.EFServices;
using RStein.Cookbook.ExportServices;
using ServiceRepository;

namespace ServiceRepositoryClient
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      initServices();
      dumpRecipes();
      exportData();
      Console.ReadLine();
    }

    private static void exportData()
    {
      var recipeUIFacade = SimpleServiceRepository.Instance.GetService<RecipeUIFacade>();
      recipeUIFacade.ExportAllRecipes();
    }

    private static void dumpRecipes()
    {
      var recipeRepository = SimpleServiceRepository.Instance.GetService<IRepository<Recipe>>();

      foreach (var recipe in recipeRepository.GetObjectsQuery())
      {
        Console.WriteLine(recipe.Name);
      }
    }

    private static void initServices()
    {
      //Polovičaté mapování abstrakce na implementaci

      var context = new CookbookMfContext();
      SimpleServiceRepository.Instance.RegisterService<IRepository<Recipe>>(new DefaultEfRepository<Recipe>(context));
      SimpleServiceRepository.Instance.RegisterService<IRepository<RecipeCategory>>(
                                                                                    new DefaultEfRepository
                                                                                      <RecipeCategory>(context));
      SimpleServiceRepository.Instance.RegisterService<IExporter>(new WordExporter());
      SimpleServiceRepository.Instance.RegisterService(new RecipeUIFacade());
    }
  }
}