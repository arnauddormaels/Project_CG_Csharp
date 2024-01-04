using CG.BL.Exceptions;
using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL.Data;
using CG.DL.Entities;
using CG.DL.Exceptions;
using CG.DL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Repositorys
{
    public class TimingRepository : ITimingRepository
    {
        readonly DatabaseContext ctx = new DatabaseContext();
        //mappers die niet static mogen zijn! - nog injecteren in de constuctor!
        private MapFromEntity mapFromEntity;
        private MapToEntity mapToEntity;

        public TimingRepository(MapFromEntity mapFromEntity, MapToEntity mapToEntity)
        {
            this.mapFromEntity = mapFromEntity;
            this.mapToEntity = mapToEntity;
        }

        public void AddTimingToRecipe(int recipeId, Timing timing)
        {
            try
            {
                //is dit de correcte manier om data op te slaan?
                TimingEntity timingEntity = mapToEntity.MapFromDomainTiming(timing);
                timingEntity.RecipeId = recipeId;
                //Voeg nu de timingToe waar nodig is!
                ctx.Timing.Add(timingEntity);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                var iex = new InfrastructureException("TimingRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddTimingToRecipe)));
                throw iex;
            }
        }

        //it is not the correct way to do it! But it does iets job!
        public List<Timing> GetAllTimingsFromRecipe(int recipeId)
        {
            try
            {
                //dit is de beter manier!
                List<Timing> timings = ctx.Timing
                    .AsNoTracking()
                    .Where(t => t.RecipeId == recipeId)
                    //Voeg de Producten toe!
                    .Include(t => t.Product)
                        //voeg de BrandProduct toe
                        .ThenInclude(p => p.Brand)
                        .Where(t => t.TimeLog ==null)
                    //map het naar model timing
                    .Select(t => mapFromEntity.MapToDomainTiming(t))
                    .ToList();

                return timings;
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("TimingRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetAllTimingsFromRecipe)));
                throw iex;
            }

        }

        public void RemoveTimingFromRecipe(int timingId)
        {
            try
            {
                TimingEntity timingToRemove = ctx.Timing.SingleOrDefault(t => t.Id == timingId);

                if (timingToRemove == null)
                {
                    throw new RecipeRepositoryException("The recipe id doesn't exist in the database");
                }

                timingToRemove.TimeLog = DateTime.Now;
                ctx.SaveChanges();
            }
            catch (Exception  ex)
            {
                var iex = new InfrastructureException("TimingRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveTimingFromRecipe)));
                throw iex;
            }
            
        }

        public void UpdateTimingWithId(int timingId, Timing timing)
        {
            //throw exception if the id doesnt match!
            //detach any existing tracking for this entity
            TimingEntity existingEntity = ctx.Timing.FirstOrDefault(t => t.Id.Equals(timingId));
            if (existingEntity != null)
            {
                ctx.Entry(existingEntity).State = EntityState.Detached;
            }
            else
            {
                throw new RecipeRepositoryException("The timing id doesn't exist in the database");
            }

            //maak de nieuwe object timingEntity
            TimingEntity timingEntity = mapToEntity.MapFromDomainTiming(timing);

            //voeg de id's in van timing and recept
            timingEntity.Id = timingId;
            timingEntity.RecipeId = existingEntity.RecipeId;

            //update de database for the existing entity
            ctx.Update(timingEntity);
            ctx.SaveChanges();
        }
    }
}
