using RStein.Cookbook.Business.Core.Collections;

namespace RStein.Cookbook.Business.Core
{
  public class RecipeCategory : CodeTableBase
  {
    private RecipeCollection m_recipes;

    public RecipeCategory()
    {
      init();
    }

    public RecipeCategory(string name) : base(name)
    {
      init();
    }

    public virtual RecipeCollection Recipes
    {
      get
      {
        return m_recipes;
      }
    }

    private void init()
    {
      m_recipes = new RecipeCollection();
    }
  }
}