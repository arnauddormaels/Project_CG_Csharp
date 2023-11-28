using CG.API.Exceptions;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CG.BL.Models;
using System.Net.NetworkInformation;

namespace CG.API.Mappers
{
    public class MapFromDTO
    {
        public Recipe MapToDomainRecipe(RecipeRESTinputDTO recipeDTO) //not implemented
        {

            try
            {
                List<Timing> timings = new List<Timing>();
                Recipe recipe = new Recipe(recipeDTO.Name, /*recipeDTO.Category,*/ recipeDTO.ImgUrl, recipeDTO.VideoUrl,recipeDTO.IsActive, timings);
                return recipe;
            }
            catch(Exception ex)
            {
                throw new MapToDomainException("MapToDomainRecipe", ex);
            }

        }

        public Product MapToDomainProduct(ProductRESTinputDTO productDTO) //not implemented
        {

            try
            {
               // Product product = new Product(productDTO.Name, /*productDTO.Category,*/ productDTO.ImgUrl, new BrandProduct(productDTO.BrandId));
                return null;
            }
            catch (Exception ex)
            {
                throw new MapToDomainException("MapToDomainProduct", ex);
            }
        }

        public Timing mapToDomainTiming(TimingRESTinputDTO timingDTO) //not implemented
        {

            try
            {
                //Timing timing = new Timing(timingDTO.StartTime, timingDTO.EndTime, new Product(timingDTO.ProductId));
                return null;
            }
            catch(Exception ex)
            {
                throw new MapToDomainException("MapToDomainTiming",ex);
            }
        }
    }


}
