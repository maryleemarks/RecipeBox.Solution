using System.Collections.Generic;
using System;

namespace RecipeBox.Models
{
  public class Tag
  {
    public Tag()
    {
      this.JoinEntities = new HashSet<Recipe_Tag>();
    }
    public int TagId{get;set;}
    public string RecipeCategory {get; set;}
  
    public virtual ICollection<Recipe_Tag> JoinEntities {  get; }
  }
}