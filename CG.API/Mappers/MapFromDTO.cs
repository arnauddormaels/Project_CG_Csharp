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
                Recipe recipe = new Recipe(recipeDTO.Name, recipeDTO.Category, recipeDTO.ImgUrl, recipeDTO.VideoUrl,recipeDTO.IsActive);
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
               Product product = new Product(productDTO.Name, /*productDTO.Category,*/ productDTO.ImgUrl, MapToDomainBrandProduct(productDTO.BrandProduct));
                return product;
            }
            catch (Exception ex)
            {
                throw new MapToDomainException("MapToDomainProduct", ex);
            }
        }

        private BrandProduct MapToDomainBrandProduct(BrandProductRESTinputDTO brandProductDTO)
        {
            try
            {
                BrandProduct brandProduct = new BrandProduct(brandProductDTO.Name, brandProductDTO.Price, brandProductDTO.Description, brandProductDTO.ImgUrl);
                return brandProduct;
            }
            catch (Exception ex)
            {
                throw new MapToDomainException("MapToDomainBrandProduct", ex);
            }
        }

        public Timing MapToDomainTiming(TimingRESTinputDTO timingDTO)
        {

            try
            {
                Timing timing = new Timing(timingDTO.StartTime, timingDTO.EndTime,MapToDomainProduct(timingDTO.Product));
                //voorlopig id toevoegen - 
                timing.Product.ProductId = timingDTO.ProductId;
                return timing;
            }
            catch(Exception ex)
            {
                throw new MapToDomainException("MapToDomainTiming",ex);
            }
        }
    }


}
