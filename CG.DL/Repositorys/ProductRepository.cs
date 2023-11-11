using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL.Data;
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
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {

        }
    }
}
