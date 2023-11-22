using CG.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Repositorys
{
    public interface IRecipeRepository
    {
        public List<Recipe> GetRecipes();
        public Recipe GetRecipe(int recipeId);
        public void AddRecipe(Recipe recipe);
        public void RemoveRecipe(string recipe);
        public void UpdateRecipe(int recipeId, Recipe recipe);
        public void ActivateRecipe(string recipeId);
    }
}
