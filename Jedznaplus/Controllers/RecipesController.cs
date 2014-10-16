using Jedznaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jedznaplus.Controllers
{
    public class RecipesController : Controller
    {
        //
        // GET: /Recipes/

        public ActionResult Index()
        {
         var db = new RecipesDataContext();
         var recipes=db.Recipes.ToList();

            return View(recipes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Models.Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var db = new RecipesDataContext();
                recipe.UserName = User.Identity.Name;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Create();
        }

        public ActionResult Edit (int id)
        {
            var db = new RecipesDataContext();
            var recipe = db.Recipes.Single(a => a.Id == id);
            return View(recipe);
        }

    }
}
