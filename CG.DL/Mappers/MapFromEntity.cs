
using CG.BL.DTO_s;
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
        public RecipeDTO MapToDomainRecipeDTO(RecipeEntity r)
        {
            try
            {
                RecipeDTO recipe = new RecipeDTO(r.Id, r.Name, r.Category,r.ImgUrl, r.VideoUrl, r.Active);
                return recipe;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping recipe to domain in Data Layer", ex);
            }
        }
        public Recipe MapToDomainRecipe(RecipeEntity recipeEntity)
        {
            try
            {
                List<Timing> timings = new List<Timing>();
                if (recipeEntity.Timings != null)
                {
                    timings= recipeEntity.Timings.Select(t => MapToDomainTiming(t)).ToList();
                }
                Recipe recipe = new Recipe(recipeEntity.Id, recipeEntity.Name, recipeEntity.Category, recipeEntity.ImgUrl, recipeEntity.VideoUrl,recipeEntity.Active,timings);
                return recipe;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("Error with mapping recipe to domain in Data Layer", ex);
            }

        }

        public Timing MapToDomainTiming(TimingEntity timingEntity)
        {
            try
            {
                //throw exception if the id doesnt match! TODO
                Product product = MapToDomainProduct(timingEntity.Product);
                Timing timing = new Timing(timingEntity.Id, timingEntity.StartTijd, timingEntity.EndTijd, product);

                return timing;
            }
            catch (Exception ex)
            {
                throw new MapFromDomainException("MapToDomainTiming", ex);
            }
        }

        public Product MapToDomainProduct(ProductEntity productEntity) //not implemented
        {
            try
            {
                BrandProduct brandProduct = MapToDomainBrandProduct(productEntity.Brand);
                Product product = new Product(productEntity.Id, productEntity.Name,/*productEntity.Category,*/ productEntity.ImgUrl,brandProduct);
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


    }
}
