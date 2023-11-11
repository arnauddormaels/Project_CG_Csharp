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
    internal static class MapToDomain
    {
        public static Recipe MapToDomainRecipe(RecipeEntity recipeEntity)
        {
            try
            {
                Recipe recipe = new Recipe(recipeEntity.Id, recipeEntity.Name, recipeEntity.ImgUrl, recipeEntity.VideoUrl);
                return recipe;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping to to domain in Data Layer", ex);
            }

        }
    }
}
