using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : DbContext
  {
    public DbSet<Recipe> Recipe { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }
    public DbSet<Recipe_Tag> Recipe_Tag {get; set;}
    public DbSet<Recipe_Ingredient> Recipe_Ingredient {get; set;}

    public RecipeBoxContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}