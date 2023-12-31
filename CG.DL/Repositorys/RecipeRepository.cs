﻿using CG.BL.DTO_s;
using CG.BL.Exceptions;
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
                RecipeEntity re = ctx.Recipe.Where(r => r.Id == recipeId).FirstOrDefault();
                //verander de waarde
                ctx.Entry(re).Property("Active").CurrentValue = !re.Active;
                ctx.SaveChanges();
                return !re.Active;
            }
            catch(Exception ex)
            {
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ActivateRecipe)));
                throw iex;
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
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddRecipe)));
                throw iex;
            }
            
        }
        public Recipe GetRecipeById(int recipeId)
        {
            try
            {

                //throw exception if the id doesnt match! TODO
                if (!ctx.Recipe.Any(r => r.Id == recipeId)) throw new RecipeRepositoryException("The recipe id doesn't exist in the database");

                RecipeEntity recipeEntities = ctx.Recipe
                    .Include(r => r.Timings)
                    .ThenInclude(t => t.Product)
                    .ThenInclude(p => p.Brand)
                    .AsNoTracking()
                    .FirstOrDefault(r => r.Id == recipeId);
  
                return mapFromEntity.MapToDomainRecipe(recipeEntities);
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipeById)));
                throw iex;
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
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipes)));
                throw iex;
            }
        }
        public List<RecipeDTO> GetActiveRecipes()
        {
            try
            {
                //return a list of recipes that are active without their timings - recipeDTO!
                return ctx.Recipe.Where(r => r.TimeLog == null & r.Active == true).AsNoTracking().Select(r => mapFromEntity.MapToDomainRecipeDTO(r)).ToList();
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipes)));
                throw iex;
            }
        }
        public void RemoveRecipe(int recipeId)
        {
            //because of tracking it is possible to change the entity and save it!
            try
            {
                //Search for the recipeEntity
                RecipeEntity recipeToRemove = ctx.Recipe
                    .Include(t => t.Timings)
                    .SingleOrDefault(r => r.Id == recipeId);

                //if not found throw exception
                if (recipeToRemove == null)
                {
                    throw new RecipeRepositoryException("The recipe id doesn't exist in the database");
                }

                //update the TimeLog of recipe to now! the time that is deleted
                recipeToRemove.TimeLog = DateTime.Now;

                //update the Timelg of Timings too of recipe!
                recipeToRemove.Timings.ForEach(t =>
                {
                    t.TimeLog = DateTime.Now;
                });

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveRecipe)));
                throw iex;
            }
            
        }
        public void UpdateRecipe(int recipeId, Recipe recipe)
        {
            try
            {

                //throw exception if the id doesnt match!
                //detach any existing tracking for this entity
                RecipeEntity existingEntity = ctx.Recipe.FirstOrDefault(r => r.Id.Equals(recipeId));
                if (existingEntity != null)
                {
                    ctx.Entry(existingEntity).State = EntityState.Detached;
                }
                else
                {
                    throw new RecipeRepositoryException("The recipe id doesn't exist in the database");
                }

                //maak de nieuwe object en voeg de id toe
                RecipeEntity recipeEntity = mapToEntity.MapFromDomainRecipe(recipe);
                recipeEntity.Id = recipeId;

                //update de database for the existing entity
                ctx.Update(recipeEntity);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //here you override the table info -Update method of EF
                var iex = new InfrastructureException("RecipeRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateRecipe)));
                throw iex;
            }

        }
    }
}
