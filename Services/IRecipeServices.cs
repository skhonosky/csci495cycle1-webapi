using System.Collections.Generic;
using RecipeApi.Models;
using RecipeApi.Repository;


namespace RecipeApi.Services {
    public interface IRecipeServices
    {
        public IEnumerable<Recipe> GetRecipes();

    }
}