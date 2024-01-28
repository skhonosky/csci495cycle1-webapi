using System;

namespace RecipeApi.Models
{
    public class Direction: IComparable<Direction>
    {
        public string Description {get;set;}
        
        public int CompareTo(Direction other) {
            return this.Description.CompareTo(other.Description);
        }

        /*public override bool Equals(object obj)
        {
            Direction d = obj as Direction;
            
            return !Object.ReferenceEquals(null,d)
            && String.Equals(Description,d.Description);
        }
        */
    }
}
