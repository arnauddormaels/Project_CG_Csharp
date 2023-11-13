using CG.API.Exceptions;
using CG.API.Model.Output;
using CG.BL.Models;

namespace CG.API.Mappers
{
    public static class MapFromDomain
    {

        public static ProductRESToutputDTO MapFromProductDomain(Product product)
        {
            try
            {
                ProductRESToutputDTO productDTO = new ProductRESToutputDTO(product.ProductId, product.ProductName, product.Category, product.ImgUrl);
                return productDTO;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("MapFromProductDomain API", ex);
            }
        }

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

        public static TimingRESToutputDTO MapFromTimingDomain(Timing timing, ProductRESToutputDTO productDTO)
        {
            TimingRESToutputDTO timingDTO = new TimingRESToutputDTO(timing.TimingId,timing.StartTime,timing.EndTime,productDTO);
            return timingDTO;
        }

        public static List<ProductRESToutputDTO> MapProducs(List<Product> products)
        {
            return products.Select(p => MapFromProductDomain(p)).ToList();
        }

        public static List<RecipeRESToutputDTO> MapRecipies(List<Recipe> recipies)
        {
           return recipies.Select(r => MapFromRecipeDomain(r)).ToList();
        }

    }
}
