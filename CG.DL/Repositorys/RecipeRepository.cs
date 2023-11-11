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

        public List<Recipe> GetRecipes()
        {
            //throw new NotImplementedException();
            return ctx.Recipe.ToList().Select(r => MapToDomain.MapToDomainRecipe(r)).ToList();
            
        }

        public void RemoveRecipe(string recipe)
        {
            throw new NotImplementedException();
        }
    }
}
