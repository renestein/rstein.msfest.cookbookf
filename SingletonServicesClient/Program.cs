using System;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;
using SingletonServices;

namespace SingletonServicesClient
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var recipeRepository = DefaultRepositoryHolder.Instance.RecipeRepository;
      dumpRecipes(recipeRepository);
      Console.ReadLine();
    }

    private static void dumpRecipes(IRepository<Recipe> recipeRepository)
    {
      foreach (var recipe in recipeRepository.GetObjectsQuery())
      {
        Console.WriteLine(recipe.Name);
      }
    }
  }
}