using CG.Application.Models;
using CG.Application.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Repositorys
{
    public class ProductEFMapper : IProductRepository
    {

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {

        }
    }
}
