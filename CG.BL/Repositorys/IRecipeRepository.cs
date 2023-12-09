using CG.BL.DTO_s;
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
        public List<RecipeDTO> GetRecipes();
        public Recipe GetRecipeById(int recipeId);
        public void AddRecipe(Recipe recipe);
        public void RemoveRecipe(int recipeId);
        public void UpdateRecipe(int recipeId, Recipe recipe);
        public bool ActivateRecipe(int recipeId);
    }
}
