using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL.Data;
using CG.DL.Entities;
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


        public void ActivateRecipe(string recipeId)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            //how to convert bl to dl??? Timings???
            RecipeEntity recipeEntity = MapFromDomain.MapFromDomainRecipe(recipe);
            ctx.Recipe.Add(recipeEntity);
            ctx.SaveChanges();
        }

        public Recipe GetRecipe(int recipeId)
        {
            try
            {
                //thow exception if the id doesnt match! TODO
                return MapToDomain.MapToDomainRecipe(ctx.Recipe.Where(r => r.Id == recipeId)
                    .AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                //add custom exception
                throw new NotImplementedException();
            }
        }

        public List<Recipe> GetRecipes()
        {
            try
            {
                return ctx.Recipe.AsNoTracking().Select(r => MapToDomain.MapToDomainRecipe(r)).ToList();
            }
            catch(Exception ex)
            {
                //add custom exception
                throw new NotImplementedException();
            }
        }

        public void RemoveRecipe(string recipe)
        {
            throw new NotImplementedException();
        }
    }
}
