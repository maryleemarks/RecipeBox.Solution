using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<Recipe_Tag>();
      this.JoinEntities2 = new HashSet<Recipe_Ingredient>();
    }

    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public int Rating { get; set; }
    public virtual ICollection<Recipe_Tag> JoinEntities { get; set; }
    public virtual ICollection<Recipe_Ingredient> JoinEntities2 { get; set; }
  }
}