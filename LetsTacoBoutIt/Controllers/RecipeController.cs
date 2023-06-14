using LetsTacoBoutIt.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LetsTacoBoutIt.Models;

namespace LetsTacoBoutIt.Controllers
{
    [Route("api/Recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_recipeRepository.GetAllRecipes());
        }

        ///************
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var recipe = _recipeRepository.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {
            _recipeRepository.AddRecipe(recipe);
            return Created("/api/recipe/" + recipe.id, recipe);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Update(Recipe recipe)
        {
            _recipeRepository.Update(recipe);
            return Created("/api/recipe/" + recipe.id, recipe);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var recipe = _recipeRepository.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            _recipeRepository.Delete(id);
            return NoContent();
        }














    }
}
