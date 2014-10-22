using Jedznaplus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jedznaplus.Controllers
{
    public class RecipesController : Controller
    {
        //
        // GET: /Recipes/

        RecipesDataContext db = new RecipesDataContext();

        public ActionResult Index()
        {
         var recipes=db.Recipes.ToList();

            return View(recipes);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Models.Recipe recipe, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {               
                recipe.UserName = User.Identity.Name;

                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var absolutePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                    var relativePath ="~/Images/"+fileName;
                    file.SaveAs(absolutePath);
                    recipe.ImageUrl = relativePath;
                }
                else
                {
                    recipe.ImageUrl = "~/Images/noPhoto.png";
                }
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Create();
        }

      
        [Authorize]
        [HttpGet]
        public ActionResult Edit (int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recipe = db.Recipes.Find(id);
            return View(recipe);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Models.Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var dbPost = db.Recipes.FirstOrDefault(p => p.Id == recipe.Id);
                if (dbPost == null)
                {
                    return HttpNotFound();
                }

                dbPost.Calories = recipe.Calories;
                dbPost.ImageUrl = recipe.ImageUrl;
                dbPost.Ingredients = recipe.Ingredients;
                dbPost.Name = recipe.Name;
                dbPost.PreparationMethod = recipe.PreparationMethod;
                dbPost.PreparationTime = recipe.PreparationTime;
                dbPost.Serves = recipe.Serves;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);

        }


        [Authorize]
        public ActionResult Delete(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var toDelete = db.Recipes.Find(id);
            
            if(toDelete!=null)
            {
                db.Recipes.Remove(toDelete);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult UserRecipes()
        {
            var userRecipes = db.Recipes.Where(a=>a.UserName== User.Identity.Name).ToList();

            return View(userRecipes);
        }

        public ActionResult Details(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var toView = db.Recipes.Find(id);
            
            if(toView!=null)
            {
                return View(toView);
            }

            return RedirectToAction("Index");
        }

    }
}
