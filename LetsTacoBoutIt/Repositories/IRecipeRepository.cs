using LetsTacoBoutIt.Models;

namespace LetsTacoBoutIt.Repositories
{
    public interface IRecipeRepository
    {
        void AddRecipe(Recipe recipe);
        void Delete(int id);
        List<Recipe> GetAllRecipes();
        Recipe GetById(int id);
        void Update(Recipe recipe);
    }
}