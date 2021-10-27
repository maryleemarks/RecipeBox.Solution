namespace RecipeBox.Models
{
  public class Recipe_Tag
  {
    public int Recipe_TagId {get; set;}
    public int RecipeId {get; set;}
    public int TagId {get; set;}
    public virtual Recipe Recipe {get; set;}
    public virtual Tag Tag {get; set;}
  }
}