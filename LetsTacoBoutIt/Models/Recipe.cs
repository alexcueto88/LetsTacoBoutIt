using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LetsTacoBoutIt.Models
{
    public class Recipe
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int ProteinTypeId { get; set;}


        [DisplayName("Recipe Name")]
        public string RecipeName { get; set; }


        public string Level { get; set; }

        public int PrepTime { get; set; }

        public int CookTime { get; set; }

        public int TotalTime { get; set; }  

        public int ServingSize { get; set; }    

        public string Ingredients { get; set; }

        public string Directions { get; set; }


        [DisplayName("Recipe Image")]
        public string RecipeImage { get; set; }


        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

    }
}
