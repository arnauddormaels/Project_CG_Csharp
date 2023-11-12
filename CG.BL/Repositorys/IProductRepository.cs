using CG.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Repositorys
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
        List<Product> GetBrandProducts();
        void AddBrandProduct(BrandProduct brandproduct);

    }
}
