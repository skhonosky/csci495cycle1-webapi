using System.Collections.Generic;
using RecipeApi.Models;

namespace RecipeApi.Repository {
    public interface IRecipeRepository {
        public IEnumerable<Recipe> GetRecipes();
        
    }
}