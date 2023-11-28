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
            //is dit de correcte manier om data op te slaan?
            TimingEntity timingEntity = mapToEntity.mapFromDomainTiming(timing);
            timingEntity.RecipeId = recipeId;
            //Voeg nu de timingToe waar nodig is!
            ctx.Timing.Add(timingEntity);
            ctx.SaveChanges();
        }

        public List<Timing> GetAllTimingsFromRecipe(int recipeId)
        {
            try
            {
                //Is dit de best manier van werken?
                List<TimingEntity> timingsEntity = ctx.Timing.AsNoTracking()
                        .Where(r => r.RecipeId == recipeId)
                        .ToList();

                return timingsEntity
                    .Select(t => mapFromEntity.MapToDomainTiming(t)).ToList();
            }
            catch (Exception ex)
            {
                throw new TimingRepositoryException("GetAllTimingsFromRecipe", ex);
            }

        }

        public void RemoveTimingFromRecipe(string timing)
        {
            throw new NotImplementedException();
        }
    }
}
