using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;

    public RecipesController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Recipe> model = _db.Recipe.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      _db.Recipe.Add(recipe);
      _db.SaveChanges();
      return View();
    }

    public ActionResult Details(int id)
    {
      List<Recipe> RecipeList = _db.Recipe.ToList();
      ViewBag.RecipeList = RecipeList;
      ViewBag.TagId = _db.Tag.ToList();
      ViewBag.IngredientId = _db.Ingredient.ToList();
      var thisRecipe = _db.Recipe
        .Include(recipe => recipe.JoinEntities)
        .ThenInclude(join => join.Tag)
        .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipe.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      _db.Entry(recipe).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRecipe = _db.Recipe.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRecipe = _db.Recipe.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipe.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    /*
    public ActionResult AddTag(int id)
    {
      List<Tag> TagList = _db.Tag.ToList();
      ViewBag.Tags = TagList; // this is to check for empty tags list
      var thisRecipe = _db.Recipe.FirstOrDefault(recipe => recipe.RecipeId == id);
      ViewBag.TagId = new SelectList(_db.Recipe, "RecipeId", "Name");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddTag(Recipe recipe, int TagId)
    {
      if(TagId != 0)
      {
        _db.Recipe_Tag.Add(new Recipe_Tag(){TagId = TagId, RecipeId = recipe.RecipeId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    */

    [HttpPost]
    public ActionResult DeleteTag(int joinId)
    {
      Recipe_Tag joinEntry = _db.Recipe_Tag.FirstOrDefault(entry => entry.Recipe_TagId == joinId);
      _db.Recipe_Tag.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    /*

    public ActionResult AddIngredient(int id)
    {
      List<Ingredient> IngredientList = _db.Ingredient.ToList();
      ViewBag.Ingredients = IngredientList; // this is to check for empty tags list
      var thisRecipe = _db.Recipe.FirstOrDefault(recipe => recipe.RecipeId == id);
      ViewBag.IngredientId = new SelectList(_db.Ingredient, "IngredientId", "Name");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddIngredient(Recipe recipe, int IngredientId)
    {
      if(IngredientId != 0)
      {
        _db.Recipe_Ingredient.Add(new Recipe_Ingredient(){IngredientId = IngredientId, RecipeId = recipe.RecipeId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
*/
    [HttpPost]
    public ActionResult DeleteIngredient(int joinId)
    {
      Recipe_Ingredient joinEntry = _db.Recipe_Ingredient.FirstOrDefault(entry => entry.Recipe_IngredientId == joinId);
      _db.Recipe_Ingredient.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}