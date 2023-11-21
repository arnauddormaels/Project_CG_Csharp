using CG.API.Exceptions;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CG.BL.Models;
using System.Net.NetworkInformation;

namespace CG.API.Mappers
{
    public class MapFromDTO
    {
        public Recipe MapToDomainRecipe(RecipeRESTinputDTO recipeDTO)
        {

            try
            {
                Recipe recipe = new Recipe(recipeDTO.Name, recipeDTO.Category, recipeDTO.ImgUrl, recipeDTO.VideoUrl);
                return recipe;
            }
            catch(Exception ex)
            {
                throw new MapToDomainException("Error wiht mapping to domain recipe", ex);
            }

            throw new NotImplementedException();
        }
    }


}
