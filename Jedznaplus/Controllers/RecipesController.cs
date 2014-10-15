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

            var auction = new []{
                new Models.Recipe(){
                Name = "Pomidorowka",
                Ingredients="Koncentrat pomidorowy, rosół z niedzieli, śmietana, cukier",
                PreparationMethod = "Podgrzej rosół, wlej koncentrat, dodaj troche cukru, dodaj śmietany",
                PreparationTime = 0,
                CookTime = 10,
                TotalTime = 10,
                Serves = 4,
                Calories=200,
                UserName="Krzysztof"
                },
                new Models.Recipe(){
                Name = "Pomidorowka",
                Ingredients="Koncentrat pomidorowy, rosół z niedzieli, śmietana, cukier",
                PreparationMethod = "Podgrzej rosół, wlej koncentrat, dodaj troche cukru, dodaj śmietany",
                PreparationTime = 0,
                CookTime = 10,
                TotalTime = 10,
                Serves = 4,
                Calories=200,
                UserName="Krzysztof"
                }
            };

            return View(auction);
        }

    }
}
