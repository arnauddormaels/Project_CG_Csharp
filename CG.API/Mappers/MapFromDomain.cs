using CG.API.Exceptions;
using CG.API.Model.Output;
using CG.BL.Models;

namespace CG.API.Mappers
{
    public static class MapFromDomain
    {
        public static RecipeRESToutputDTO MapFromRecipeDomain(Recipe recipe)
        {
            try
            {
                RecipeRESToutputDTO recipeDTO = new RecipeRESToutputDTO(recipe.RecipeId, recipe.Name, recipe.ImgUrl, recipe.VideoUrl, recipe.IsActive);
                return recipeDTO;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Eroor with mapping from domain", ex);
            }
        }


    }
}
