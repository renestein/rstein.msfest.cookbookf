using RStein.Cookbook.Business.Core.Collections;

namespace RStein.Cookbook.Business.Core
{
  public class Recipe : BusinessObjectBase
  {
    private RecipeIngredientCollection m_ingredients;
    private RecipeTagCollection m_recipesCollection;

    public Recipe()
    {
      init();
    }


    public virtual string Name
    {
      get;
      set;
    }

    public virtual RecipeCategory Category
    {
      get;
      set;
    }

    public virtual int CategoryId
    {
      get;
      set;
    }

    public virtual RecipeTagCollection Tags
    {
      get
      {
        return m_recipesCollection;
      }
    }

    public virtual RecipeIngredientCollection Ingredients
    {
      get
      {
        return m_ingredients;
      }
    }

    public virtual string Description
    {
      get;
      set;
    }

    private void init()
    {
      m_recipesCollection = new RecipeTagCollection();
      m_ingredients = new RecipeIngredientCollection();
    }
  }
}