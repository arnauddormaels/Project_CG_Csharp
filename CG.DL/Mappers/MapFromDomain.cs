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
    internal static class MapFromDomain
    {
        public static RecipeEntity MapFromDomainRecipe(Recipe recipe)
        {
            try
            {
                RecipeEntity recipeEntity = new RecipeEntity(recipe.RecipeId.ToString(), recipe.Name, recipe.IsActive,recipe.ImgUrl, recipe.VideoUrl);       //voorlopig id gecast naar een string
                return recipeEntity;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping from domain in Data Layer", ex);
            }

        }
    }
}
