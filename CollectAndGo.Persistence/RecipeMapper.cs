using CG.Application.Models;
using CG.Application.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence
{
    public class RecipeMapper : IRecipeRepository

    {
        private List<Recipe> _recipes = new List<Recipe>() {
                new Recipe(1, "Biefstuk met frietjes", "/ImgUrlBiefstuk", "/videoUrl"),
                new Recipe(2, "Spaghetti bolongaise", "/ImgUrlPaghetti", "/videoUrl") 
            };
        public List<Recipe> GetRecipes()
        {
            //oproepen via databank moet nog gebeuren
            return _recipes;

        }

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public void RemoveRecipe(string recipe)              
        {
            //IsActiveOp False zetten in databank.
            throw new NotImplementedException();

        }

        public void ActivateRecipe(string recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
