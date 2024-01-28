using System;
using System.Collections.Generic;

namespace RecipeApi.Models {
    public class Recipe : IComparable<Recipe> {
        private int RecipeID {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string Ingredients {get; set;}
        //public List<Ingredient> Ingredients {get; set;}
        public List<Direction> Directions {get; set;}


        public override String ToString() {
            return $"{Title} \n {Description} \n {Ingredients} \n {Directions}";

        }
        public int CompareTo(Recipe other) {
            return this.Title.CompareTo(other.Title);
        }

        /*public override bool Equals(object obj)
        {
            Recipe r = obj as Recipe;
            
            return !Object.ReferenceEquals(null,r)
            && String.Equals(Title,r.Title);
        }*/
    }
}