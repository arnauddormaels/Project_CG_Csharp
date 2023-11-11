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
                throw new MapFromDomainException("Error with mapping from domain", ex);
            }
        }
        public static List<RecipeRESToutputDTO> MapRecipies(List<Recipe> recipies)
        {
           return recipies.Select(r => MapFromRecipeDomain((Recipe)r)).ToList();
        }


    }
}
