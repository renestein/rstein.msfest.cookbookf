using System;
using System.Threading;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;
using RStein.Cookbook.EF;
using RStein.Cookbook.EF.EFServices;

namespace SingletonServices
{
  public class DefaultRepositoryHolder
  {
    private static Lazy<DefaultRepositoryHolder> _instance =
      new Lazy<DefaultRepositoryHolder>(() => new DefaultRepositoryHolder(),
                                        LazyThreadSafetyMode.ExecutionAndPublication);
    private readonly CookbookMfContext m_context;
    private readonly IRepository<RecipeCategory> m_recipeCategoryRepository;
    private readonly IRepository<Recipe> m_recipeRepository;

    protected DefaultRepositoryHolder()
    {
      m_context = new CookbookMfContext();
      m_recipeRepository = new DefaultEfRepository<Recipe>(m_context);
      m_recipeCategoryRepository = new DefaultEfRepository<RecipeCategory>(m_context);
    }

    public IRepository<Recipe> RecipeRepository
    {
      get
      {
        return m_recipeRepository;        
      }
    }

    public IRepository<RecipeCategory> RecipeCategoryRepository
    {
      get
      {
        return m_recipeCategoryRepository;
      }
    }

    public static DefaultRepositoryHolder Instance
    {
      get
      {
        return _instance.Value;
      }
    }
  }
}