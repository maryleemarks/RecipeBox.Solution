using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public Ingredient()
    {
      this.JoinEntities2 = new HashSet<Recipe_Ingredient>();
    }
     public int IngredientId { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public virtual ICollection<Recipe_Ingredient> JoinEntities2 {get; set;}
  }
}