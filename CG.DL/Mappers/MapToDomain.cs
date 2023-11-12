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
                throw new MapFromDomainException("Error with mapping recipe to domain in Data Layer", ex);
            }

        }

        public static Product MapToDomainProduct(ProductEntity productEntity)
        {
            try
            {
                Product product = new Product(productEntity.Id, productEntity.Name,productEntity.Category, productEntity.ImgUrl);
                return product;
            }
            catch(Exception ex)
            {
                throw new MapFromDomainException("MapToDomainProduct", ex);
            }
            
        }

        public static BrandProduct MapToDomainBrandProduct(BrandEntity brandEntity)
        {
            try
            {
                BrandProduct brandProduct = new(brandEntity.Id, brandEntity.Name, brandEntity.Price, brandEntity.Description, brandEntity.ImgUrl);
                return brandProduct;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("MapToDomainBrandProduct", ex);
            }
        }
    }
}
