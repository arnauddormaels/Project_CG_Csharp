using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL.Data;
using CG.DL.Entities;
using CG.DL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        readonly DatabaseContext ctx = new DatabaseContext();
        readonly MapFromEntity mapFromEntity;
        readonly MapToEntity mapToEntity;

        public ProductRepository(MapFromEntity mapFromEntity,MapToEntity mapToEntity)
        {
            this.mapFromEntity = mapFromEntity;
            this.mapToEntity = mapToEntity;
        }

        public List<Product> GetProducts()
        {
            return ctx.Product.ToList().Select(p => mapFromEntity.MapToDomainProduct(p)).ToList();
        }

        public void AddProduct(Product product)
        {
            //controleer of die product all bestaat in de repository! en geef terug de ID
            ProductEntity productEntity = mapToEntity.mapFromDomainProduct(product);
            ctx.Product.Add(productEntity);
            ctx.SaveChanges();
        }

        public void AddBrandProduct(BrandProduct brandproduct)
        {
            BrandEntity brandEntity = mapToEntity.mapFromDomainBrandProduct(brandproduct);
            ctx.Brand.Add(brandEntity);
            ctx.SaveChanges();
        }

        public List<BrandProduct> GetBrandProducts(int brandId)
        {
            try
            {
                return ctx.Brand.AsNoTracking().Where(b => b.Id == brandId).Select(t => mapFromEntity.MapToDomainBrandProduct(t)).ToList();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
