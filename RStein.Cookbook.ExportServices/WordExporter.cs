using System;
using RStein.Cookbook.Business.Core;

namespace RStein.Cookbook.ExportServices
{
  public class WordExporter : IExporter
  {
    public const string DEFAULT_ITEM_FORMAT = "Exporting - {0}-{1}\n";

    public virtual void ExportRecipe(Recipe recipe)
    {
      var message = String.Format(DEFAULT_ITEM_FORMAT, recipe.Name, recipe.Description);
      Console.WriteLine(message);
    }
  }
}