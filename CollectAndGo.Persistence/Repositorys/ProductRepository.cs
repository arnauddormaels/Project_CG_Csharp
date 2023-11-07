using CG.Application.Models;
using CG.Application.Repositorys;
using CG.Persistence.Data;
using CG.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        DatabaseContext ctx = new DatabaseContext();

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {

        }
    }
}
