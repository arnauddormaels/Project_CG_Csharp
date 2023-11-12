using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL.Data;
using CG.DL.Entities;
using CG.DL.Mappers;
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

        public List<Product> GetProducts()
        {
            return ctx.Product.ToList().Select(p => MapToDomain.MapToDomainProduct(p)).ToList();
        }

        public void AddProduct(Product product)
        {
            //ProductEntity productEntity = MapFromDomain
        }

        public List<Product> GetBrandProducts()
        {
            throw new NotImplementedException();
        }

        public void AddBrandProduct(BrandProduct brandproduct)
        {
            throw new NotImplementedException();
        }
    }
}
