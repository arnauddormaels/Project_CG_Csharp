using CG.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Application.Repositorys
{
    public interface IProductRepository
    {
        List<Product> GetProducts(int recipeId);


    }
}
