using CG.Application.Models;
using CG.Application.Repositorys;

namespace CG.Persistence
{
    public class ProductMapper : IProductRepository
    {

        private List<Product> _products = new List<Product>()                //dummycode 
        {
            new Product(1, "Melk",new BrandProduct(1, "melkMerk", 2.2M, "hallo ik ben een melk descriptie", "imgUrlMerk1"),"imageUrl1"),
            new Product(2, "Bread", new BrandProduct(2, "breadMerk", 1.5M, "This is a bread description.", "imgUrlMerk2"), "imageUrl2"),
            new Product(3, "Eggs", new BrandProduct(3, "eggsMerk", 3.0M, "Fresh eggs from local farms.", "imgUrlMerk3"), "imageUrl3"),
            new Product(4, "Cheese", new BrandProduct(4, "cheeseMerk", 5.99M, "A variety of delicious cheeses.", "imgUrlMerk4"), "imageUrl4"),
            new Product(5, "Apples", new BrandProduct(5, "applesMerk", 2.49M, "Fresh and crispy apples.", "imgUrlMerk5"), "imageUrl5"),
            new Product(6, "Pasta", new BrandProduct(6, "pastaMerk", 1.79M, "High-quality pasta for your recipes.", "imgUrlMerk6"), "imageUrl6"),
            new Product(7, "Tomatoes", new BrandProduct(7, "tomatoesMerk", 1.99M, "Ripe and juicy tomatoes.", "imgUrlMerk7"), "imageUrl7"),
            new Product(8, "Chicken", new BrandProduct(8, "chickenMerk", 7.49M, "Farm-fresh chicken meat.", "imgUrlMerk8"), "imageUrl8")
            };

        public ProductMapper()
        {
        }

        public List<Product> GetProducts()
        {
            //In de databank zoeken naar de producten met hetzelfde recipeId en deze returnen
            return _products;
        }
    }
}