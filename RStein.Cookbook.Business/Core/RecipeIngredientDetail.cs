using System;

namespace RStein.Cookbook.Business.Core
{
  public class RecipeIngredientDetail : CodeTableBase
  {
    private Ingredient m_ingredient;
    public RecipeIngredientDetail() {}

    public RecipeIngredientDetail(Ingredient ingredient, Amount amount)
    {
      if (ingredient == null)
      {
        throw new ArgumentNullException("ingredient");
      }
      if (amount == null)
      {
        throw new ArgumentNullException("amount");
      }

      Ingredient = ingredient;
      Amount = amount;
    }


    public virtual Recipe Recipe
    {
      get;
      set;
    }

    public virtual int RecipeId
    {
      get;
      set;
    }

    public virtual int IngredientId
    {
      get;
      set;
    }

    public virtual Ingredient Ingredient
    {
      get
      {
        return m_ingredient;
      }
      set
      {
        if (value == null)
        {
          throw new ArgumentNullException("Ingredient");
        }
        m_ingredient = value;
      }
    }

    public virtual Amount Amount
    {
      get;
      set;
    }
  }
}