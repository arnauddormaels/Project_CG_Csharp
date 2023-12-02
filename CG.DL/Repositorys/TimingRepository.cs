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
            TimingEntity timingEntity = mapToEntity.MapFromDomainTiming(timing);
            timingEntity.RecipeId = recipeId;
            //Voeg nu de timingToe waar nodig is!
            ctx.Timing.Add(timingEntity);
            ctx.SaveChanges();
        }

        //it is not the correct way to do it! But it does iets job!
        public List<Timing> GetAllTimingsFromRecipe(int recipeId)
        {
            try
            {
                //Is dit de best manier van werken?
                List<TimingEntity> timingsEntity = ctx.Timing.AsNoTracking()
                        .Where(r => r.RecipeId == recipeId)
                        .ToList();

                //Voeg de Producten toe!
                //voeg de BrandProduct toe
                timingsEntity.ForEach(t =>
                {
                    ProductEntity product = ctx.Product.AsNoTracking().Where(p=> p.Id == t.ProductId).FirstOrDefault();
                    BrandEntity brand = ctx.Brand.AsNoTracking().Where(b => b.Id == product.BrandId).FirstOrDefault();
                    product.Brand = brand;
                    t.Product = product;
                });

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
