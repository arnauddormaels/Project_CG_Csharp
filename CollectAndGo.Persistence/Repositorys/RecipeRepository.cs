using CG.Application.Models;
using CG.Application.Repositorys;
using CG.Persistence.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Repositorys
{
    public class RecipeRepository : IRecipeRepository
    {
        DatabaseContext ctx = new DatabaseContext();


        public void ActivateRecipe(string recipeId)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            //how to convert bl to dl??? Timings???
            Model.RecipeEntity DLRecipe = new(recipe.Name,recipe.Category,recipe.IsActive,recipe.ImgUrl,recipe.VideoUrl);
            ctx.Recipe.Add(DLRecipe);
            ctx.SaveChanges();
        }

        public List<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public void RemoveRecipe(string recipe)
        {
            throw new NotImplementedException();
        }
    }
}
