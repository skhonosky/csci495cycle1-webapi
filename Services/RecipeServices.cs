using System.Collections.Generic;
using RecipeApi.Models;
using RecipeApi.Repository;
using System.Linq;


namespace RecipeApi.Services{
    public class RecipeServices : IRecipeServices
    {
        private readonly IRecipeRepository _repo;
        public RecipeServices(IRecipeRepository recipeRepo) {
            _repo=recipeRepo;
        }

        /*public List<Recipe> GetRecipes() {
            return _repo.GetRecipes().ToList<Recipe>();
        }*/
        
        public IEnumerable<Recipe> GetRecipes() {
            IEnumerable<Recipe> myList = _repo.GetRecipes();
            return myList;
        }
        

    }

}