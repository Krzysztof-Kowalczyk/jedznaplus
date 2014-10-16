using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jedznaplus.Models
{
    public class RecipesDataContext : DbContext
    {
        public DbSet<Recipe> Recpes { get; set; }
    }
}