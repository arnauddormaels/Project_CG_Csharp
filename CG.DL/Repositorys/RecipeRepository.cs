using CG.BL.DTO_s;
using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL.Data;
using CG.DL.Entities;
using CG.DL.Exceptions;
using CG.DL.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Repositorys
{
    public class RecipeRepository : IRecipeRepository
    {
        readonly DatabaseContext ctx = new DatabaseContext();
        //mappers die niet static mogen zijn! - nog injecteren in de constuctor!
        private MapFromEntity mapFromEntity;
        private MapToEntity mapToEntity;

        public RecipeRepository(MapFromEntity mapFromEntity, MapToEntity mapToEntity)
        {
            this.mapFromEntity = mapFromEntity;
            this.mapToEntity = mapToEntity;
        }

        public bool ActivateRecipe(int recipeId)
        {
            try
            {
                //throw exception if the id doesnt match!
                if (!ctx.Recipe.Any(r => r.Id == recipeId)) throw new RecipeRepositoryException("The recipe id doesn't exist in the database");
                //haal de waarde uit!
                RecipeEntity re = ctx.Recipe.Where(r => r.Id == recipeId).First();
                //verander de waarde
                ctx.Entry(re).Property("Active").CurrentValue = !re.Active;
                ctx.SaveChanges();
                return !re.Active;
            }
            catch(Exception ex)
            {
                throw new RecipeRepositoryException("ActivateRecipe", ex);
            }
        }

        public void AddRecipe(Recipe recipe)
        {
            try
            {
                //how to convert bl to dl??? Timings???
                //voeg een recipe toe zonder timings! addtiming gebruiken om timing toe te voegen!
                RecipeEntity recipeEntity = mapToEntity.MapFromDomainRecipe(recipe);
                ctx.Recipe.Add(recipeEntity);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new RecipeRepositoryException("AddRecipe", ex);
            }
            
        }

        public Recipe GetRecipeById(int recipeId)
        {
            try
            {
                //throw exception if the id doesnt match! TODO
                if(!ctx.Recipe.Any(r => r.Id == recipeId)) throw new RecipeRepositoryException("The recipe id doesn't exist in the database");

                //Voeg de timing toe van de recept en de producten en hun brandproduct
                RecipeEntity recipeEntities = ctx.Recipe.Where(r => r.Id == recipeId)
                    .AsNoTracking().First();
                
                List<TimingEntity> timingEntities = ctx.Timing.Where(t => t.RecipeId == recipeEntities.Id).AsNoTracking().ToList();

                timingEntities.ForEach(timingEntity =>
                {
                    ProductEntity productEntity = ctx.Product.Where(p => p.Id == timingEntity.ProductId).AsNoTracking().First();
                    productEntity.Brand = ctx.Brand.Where(b => b.Id == productEntity.BrandId).AsNoTracking().First();
                    timingEntity.Product = productEntity;
                });

                recipeEntities.Timings = timingEntities;
  
                return mapFromEntity.MapToDomainRecipe(recipeEntities);
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("GetRecipeById", ex);
            }
        }

        public List<RecipeDTO> GetRecipes()
        {
            try
            {
                //return a list of recipes without their timings - recipeDTO!
                return ctx.Recipe.Where(r => r.TimeLog == null).AsNoTracking().Select(r => mapFromEntity.MapToDomainRecipeDTO(r)).ToList();
            }
            catch(Exception ex)
            {
                throw new RecipeRepositoryException("GetRecipes", ex);
            }
        }

        public void RemoveRecipe(int recipeId)
        {
            try
            {
                //throw exception if the id doesnt match! TODO
                if (!ctx.Recipe.Any(r => r.Id == recipeId)) throw new RecipeRepositoryException("The recipe id doesn't exist in the database");

                ctx.Entry(ctx.Recipe.Where(r => r.Id == recipeId).First()).Property("TimeLog").CurrentValue = DateTime.Now;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("RemoveRecipe", ex);
            }
            
        }

        public void UpdateRecipe(int recipeId, Recipe recipe)
        {
            try
            {
                RecipeEntity recipeEntity = mapToEntity.MapFromDomainRecipe(recipe);
                recipeEntity.Id = recipeId;
                ctx.Update(recipeEntity);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //here you override the table info -Update method of EF
                throw new RecipeRepositoryException("UpdateRecipe", ex);
            }

        }
    }
}
