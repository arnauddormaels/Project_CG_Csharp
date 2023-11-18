using CG.BL.Models;
using CG.DL.Entities;
using CG.DL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Mappers
{
    public class MapFromDomain
    {
        public RecipeEntity MapFromDomainRecipe(Recipe recipe)
        {
            try
            {
                RecipeEntity recipeEntity = new RecipeEntity(recipe.Name, recipe.Category,recipe.IsActive,recipe.ImgUrl, recipe.VideoUrl);       //voorlopig id gecast naar een string
                //recipeEntity.Id = recipe.RecipeId;
                return recipeEntity;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping from domain into Data Layer", ex);
            }

        }
    }
}
