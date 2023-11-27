using CG.API.Exceptions;
using CG.API.Model.Output;
using CG.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Mappers
{
    public class MapToDTO
    {

        public ProductRESToutputDTO MapFromProductDomain(Product product)
        {
            try
            {
                ProductRESToutputDTO productDTO = new ProductRESToutputDTO(product.ProductId, product.ProductName, product.Category, product.ImgUrl);
                productDTO.BrandId = product.BrandProduct.BrandId;
                return productDTO;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("MapFromProductDomain API", ex);
            }
        }

        public RecipeRESToutputDTO MapFromRecipeDomain(Recipe recipe)
        {
            try
            {
                RecipeRESToutputDTO recipeDTO = new RecipeRESToutputDTO(recipe.RecipeId, recipe.Name,recipe.Category ,recipe.ImgUrl, recipe.VideoUrl, recipe.IsActive) ;
                return recipeDTO;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping to Recipe DTO", ex);
            }
        }

        public TimingRESToutputDTO MapFromTimingDomain(Timing timing, ProductRESToutputDTO productDTO)
        {
            try
            {
                TimingRESToutputDTO timingDTO = new TimingRESToutputDTO(timing.TimingId, timing.StartTime, timing.EndTime, productDTO);
                return timingDTO;
            }
            catch(Exception ex)
            {
                throw new MapFromDomainException("Error with mapping To Timing DTO", ex);
            }

        }

        public BrandProductRESToutputDTO MapFromBrandProductDomain(BrandProduct brandProduct)
        {
            try
            {
                BrandProductRESToutputDTO BrandDTO = new BrandProductRESToutputDTO(brandProduct.BrandId,brandProduct.Name,brandProduct.Description,brandProduct.Price,brandProduct.ImgUrl);
                return BrandDTO;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping to BrandProduct DTO", ex);
            }
        }

        public List<ProductRESToutputDTO> MapProducs(List<Product> products)
        {
            return products.Select(p => MapFromProductDomain(p)).ToList();
        }

        public List<RecipeRESToutputDTO> MapRecipies(List<Recipe> recipies)
        {
           return recipies.Select(r => MapFromRecipeDomain(r)).ToList();
        }

        public List<TimingRESToutputDTO> MapTimings(List<Timing> Timings)
        {
            return Timings.Select(t => MapFromTimingDomain(t,MapFromProductDomain(t.Product))).ToList();
        }

        public List<BrandProductRESToutputDTO> MapBrandProducts(List<BrandProduct> brandProducts)
        {
            return brandProducts.Select(b => MapFromBrandProductDomain(b)).ToList();    
        }
    }
}
