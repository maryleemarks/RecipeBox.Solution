namespace RecipeBox.Models
{
  public class Recipe_Ingredient
  {
    public int Recipe_IngredientId {get; set;}
    public int RecipeId {get; set;}
    public int IngredientId {get; set;}
    public virtual Recipe CRecipe {get; set;}
    public virtual Ingredient Ingredient {get; set;}
  }
}