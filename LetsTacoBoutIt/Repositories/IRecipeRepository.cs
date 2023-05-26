using LetsTacoBoutIt.Models;

namespace LetsTacoBoutIt.Repositories
{
    public interface IRecipeRepository
    {
        void Delete(int id);
        List<Recipe> GetAll();
        Recipe GetById(int id);
        void Insert(Recipe recipe);
        void Update(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
    }
}