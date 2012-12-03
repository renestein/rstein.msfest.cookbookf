using System;
using System.Web.Mvc;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.Business.Core;
using SimpleUIFacade;
using SimpleWebDI.Models;

namespace SimpleWebDI.Controllers
{
  public class RecipeController : Controller
  {
    private readonly IRepository<Recipe> m_repository;
    private readonly RecipeUIFacade m_uiFacade;

    public RecipeController(IRepository<Recipe> repository, RecipeUIFacade uiFacade)
    {
      if (repository == null)
      {
        throw new ArgumentNullException("repository");
      }

      if (uiFacade == null)
      {
        throw new ArgumentNullException("uiFacade");
      }


      m_repository = repository;
      m_uiFacade = uiFacade;
    }

    public ActionResult Index(int page = 0)
    {
      const int PAGE_SIZE = 10;
      if (page < 0)
      {
        throw new ArgumentException("page");
      }

      var pager = new SimplePaginator<Recipe>(m_repository, page, PAGE_SIZE);
      return View(pager);
    }

    public ActionResult ExportAllRecipes()
    {
      m_uiFacade.ExportAllRecipes();
      return View();
    }
  }
}