using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jedznaplus.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PreparationMethod { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTime { get; set; }
        public int CookTime { get; set; }
        public int TotalTime { get; set; }
        public int Serves { get; set; }
        public int Calories { get; set; }
        public string UserName { get; set; }

    }
}