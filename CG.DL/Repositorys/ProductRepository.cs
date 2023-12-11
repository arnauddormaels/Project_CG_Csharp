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
            try
            {
                //Kijkt eerst de brandproduct die bijhoren bij product!
                List<ProductEntity> productEntity = ctx.Product.ToList();
                //voeg de brandproduct bij de entit!
                productEntity.ForEach(p =>
                {
                    p.Brand = ctx.Brand.Where(b => b.Id == p.BrandId).AsNoTracking().FirstOrDefault();
                });

                return productEntity.Select(p => mapFromEntity.MapToDomainProduct(p)).ToList();
            }
            catch(Exception ex) 
            {
                var iex = new InfrastructureException("ProductRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetProducts)));
                throw iex;
            }
        }

        public Product GetProductById(int productId)
        {
            try
            {
                //Get Product and BrandProduct
                ProductEntity productEntity = ctx.Product.AsNoTracking().Where(p => p.Id == productId).FirstOrDefault();
                productEntity.Brand = ctx.Brand.AsNoTracking().Where(b => b.Id == productEntity.BrandId).FirstOrDefault();

                Product product = mapFromEntity.MapToDomainProduct(productEntity);
                return product;
                
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("ProductRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetProductById)));
                throw iex;
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                //controleer of die product all bestaat in de repository! en geef terug de ID
                ProductEntity productEntity = mapToEntity.MapFromDomainProduct(product);
                ctx.Product.Add(productEntity);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                var iex = new InfrastructureException("ProductRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddProduct)));
                throw iex;
            }

        }

        public void AddBrandProduct(BrandProduct brandproduct)
        {
            try
            {
                BrandEntity brandEntity = mapToEntity.MapFromDomainBrandProduct(brandproduct);
                ctx.Brand.Add(brandEntity);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                var iex = new InfrastructureException("ProductRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddBrandProduct)));
                throw iex;
            }
        }

        public List<BrandProduct> GetBrandProducts(int brandId)
        {
            try
            {
                return ctx.Brand.AsNoTracking().Where(b => b.Id == brandId).Select(t => mapFromEntity.MapToDomainBrandProduct(t)).ToList();
            }
            catch (Exception ex)
            {
                var iex = new InfrastructureException("ProductRepository", ex);
                iex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetBrandProducts)));
                throw iex;
            }
        }
    }
}
