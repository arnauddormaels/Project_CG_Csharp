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
    public class MapToEntity
    {
        public RecipeEntity MapFromDomainRecipe(Recipe recipe)
        {
            try
            {
                RecipeEntity recipeEntity = new RecipeEntity(recipe.Name, /*recipe.Category,*/recipe.IsActive,recipe.ImgUrl, recipe.VideoUrl);       //voorlopig id gecast naar een string
                //recipeEntity.Id = recipe.RecipeId;
                return recipeEntity;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping from domain into Data Layer", ex);
            }

        }

        internal BrandEntity mapFromDomainBrandProduct(BrandProduct brandproduct)
        {
            try
            {
                BrandEntity brandEntity = new(brandproduct.Name, brandproduct.Price, brandproduct.Description, brandproduct.ImgUrl);
                return brandEntity;
            }
            catch(Exception ex)
            {
                throw new MapFromDomainException("mapFromDomainBrandProduct");
            }
        }

        internal ProductEntity mapFromDomainProduct(Product product)
        {
            try
            {
                ProductEntity productEntity = new(product.ProductName, /*product.Category,*/ product.ImgUrl);
                productEntity.BrandId = product.BrandProduct.BrandId;
                return productEntity;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("mapFromDomainProduct", ex);
            }
        }

        internal TimingEntity mapFromDomainTiming(Timing timing)
        {
            try
            {
                TimingEntity timingEntity = new(timing.StartTime,timing.EndTime);
                //die moet je dus meegeven want product bevat nog geen ID of je haalt het af uit de databank...!
                timingEntity.ProductId = timing.Product.ProductId;
                return timingEntity;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("mapFromDomainTiming", ex);
            }
        }
    }
}
