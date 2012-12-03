using System;
using System.Data.Entity;
using RStein.Cookbook.Business.Core;
using RStein.Cookbook.EF;

namespace CookbookTester
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      runEfContext();
      Console.ReadLine();
    }

    private static void runEfContext()
    {
      Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CookbookMfContext>());

      using (var context = new CookbookMfContext())
      {
        seed(context);
      }
    }

    private static void seed(CookbookMfContext context)
    {
      const string dummyRecipeText =
        @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vitae felis sapien. Sed a faucibus lacus.";


      var standardCategory = new RecipeCategory("Všední jídla");
      var specilitiesCategory = new RecipeCategory("Specialitky");

      context.RecipeCategories.Add(standardCategory);

      context.RecipeCategories.Add(specilitiesCategory);


      context.Recipes.Add(new Recipe
                            {
                              Category = standardCategory,
                              Name = "Michaná vajíčka",
                              Description = dummyRecipeText
                            });

      context.Recipes.Add(new Recipe
                            {
                              Category = standardCategory,
                              Name = "Párky",
                              Description = dummyRecipeText
                            });

      context.Recipes.Add(new Recipe
                            {
                              Category = specilitiesCategory,
                              Name = "Lahůdkové párky",
                              Description = dummyRecipeText
                            });


      context.Recipes.Add(new Recipe
                            {
                              Category = specilitiesCategory,
                              Name = "Babicova pizza",
                              Description = dummyRecipeText
                            });


      context.Recipes.Add(new Recipe
                            {
                              Category = specilitiesCategory,
                              Name = "Kuře Vindaloo",
                              Description = dummyRecipeText
                            });

      context.SaveChanges();
    }
  }
}