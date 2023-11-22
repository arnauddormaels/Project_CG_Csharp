using CG.BL.Models;
using CG.DL.Data;
using CG.DL.Entities;
using CG.DL.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Mappers
{
    public class MapFromEntity
    {
        public Recipe MapToDomainRecipe(RecipeEntity recipeEntity)
        {
            try
            {
                Recipe recipe = new Recipe(recipeEntity.Id, recipeEntity.Name,recipeEntity.Category, recipeEntity.ImgUrl, recipeEntity.VideoUrl);
                return recipe;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping recipe to domain in Data Layer", ex);
            }

        }

        public Product MapToDomainProduct(ProductEntity productEntity)
        {
            try
            {
                Product product = new Product(productEntity.Id, productEntity.Name, productEntity.Category, productEntity.ImgUrl,new BrandProduct(productEntity.BrandId));
                return product;
            }
            catch(Exception ex)
            {
                throw new MapFromDomainException("MapToDomainProduct", ex);
            }
            
        }

        public BrandProduct MapToDomainBrandProduct(BrandEntity brandEntity)
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

        public Timing MapToDomainTiming(TimingEntity timingEntity, ProductEntity productEntity)
        {
            try
            {
                //throw exception if the id doesnt match! TODO
                Product product = MapToDomainProduct(productEntity);
                Timing timing = new Timing(timingEntity.Id, timingEntity.StartTijd, timingEntity.EndTijd,product);

                return timing;
            }
            catch(Exception ex)
            {
                throw new MapFromDomainException("MapToDomainTiming", ex);
            }
        }
    }
}
