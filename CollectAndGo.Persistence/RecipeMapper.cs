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
        public List<Recipe> GetRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe(1, "Biefstuk met frietjes", "/ImgUrlBiefstuk", "/videoUrl", new List<object>() { new object(), new object() }),
                new Recipe(2, "Spaghetti bolongaise", "/ImgUrlPaghetti", "/videoUrl", new List<object>() { new object(), new object() })                            //Object moet nog aangepast worden.
            };
        }
    
    
    
    }
}
