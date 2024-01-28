using System;

namespace RecipeApi.Models
{
    public class Ingredient: IComparable<Ingredient>
    {
        public string Name {get;set;}
        public string Measurement {get; set;}
        
        public int CompareTo(Ingredient other) {
            return this.Name.CompareTo(other.Name);
        }

        /*public override bool Equals(object obj)
        {
            Ingredient i = obj as Ingredient;
            
            return !Object.ReferenceEquals(null,i)
            && String.Equals(Name,i.Name);
        }*/
    }
}
