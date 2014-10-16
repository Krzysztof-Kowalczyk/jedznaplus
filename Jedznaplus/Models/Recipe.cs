using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jedznaplus.Models
{
    public class Recipe
    {
        
        public long Id { get; set; }
      
        [Required]
        [Display(Name = "Nazwa")]    
        public string Name { get; set; }

        [Required]
        [Display(Name = "Składniki")]
        public string Ingredients { get; set; }

        [Required]
        [Display(Name = "Sposób przygotowania")]
        public string PreparationMethod { get; set; }
       
        [Required]
        [Display(Name = "Zdjęcie")]
        public string ImageUrl { get; set; }
        
        [Required]
        [Display(Name = "Czas przygotowania")]
        [Range(1, 1000, ErrorMessage = "Czas przygotowania musi być powyżej 1 minuty")] 
        public int PreparationTime { get; set; }
        
        [Required]
        [Display(Name = "Porcje")]
        [Range(1, 10, ErrorMessage = "Musi być minimum jedna porcja")] 
        public int Serves { get; set; }

        [Required]
        [Display(Name = "Kalorie")]
        [Range(1, 9000, ErrorMessage = "Musi być powyżej 0 kalorii")] 
        public int Calories { get; set; }

        [Display(Name = "Nazwa uzytkownika")]
        public string UserName { get; set; }

    }
}