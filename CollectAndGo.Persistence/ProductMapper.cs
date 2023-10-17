using CG.Application.Models;
using CG.Application.Repositorys;

namespace CG.Persistence
{
    public class ProductMapper : IProductRepository
    {

        private List<Product> _products = new List<Product>()                //dummycode 
        {
            new Product("Melk", new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(2000, 1, 1, 0, 30, 0), 0, 0,0),
            new Product("CacaoPoeder", new DateTime(2000, 1, 1, 0, 15, 0), new DateTime(2000, 1, 1, 0, 30, 0), 1, 1,0),
            new Product("Suiker", new DateTime(2000, 1, 1, 0, 20, 0), new DateTime(2000, 1, 1, 0, 25, 0), 2, 2,0),
            new Product("Tomaten", new DateTime(2000, 1, 1, 0, 20, 0), new DateTime(2000, 1, 1, 0, 25, 0), 3, 3,2),
            new Product("Biefstuk", new DateTime(2000, 1, 1, 0, 15, 0), new DateTime(2000, 1, 1, 0, 40, 0), 4, 4,1),
            new Product("Boter", new DateTime(2000, 1, 1, 0, 00, 0), new DateTime(2000, 1, 1, 0, 15, 0), 5, 5,1),
            new Product("Frieten", new DateTime(2000, 1, 1, 0, 20, 0), new DateTime(2000, 1, 1, 0, 25, 0), 6, 6,1),
            new Product("Spaghetti", new DateTime(2000, 1, 1, 0, 10, 0), new DateTime(2000, 1, 1, 0, 25, 0), 7, 7,2),
            new Product("Gehakt", new DateTime(2000, 1, 1, 0, 20, 0), new DateTime(2000, 1, 1, 0, 25, 0), 8, 8,2)

            };             

        public ProductMapper()
        {
        }

        public List<Product> GetProducts(int recipeId)
        {
            //In de databank zoeken naar de producten met hetzelfde recipeId en deze returnen
            return _products.Where(p => p.RecipeId == recipeId).ToList();
        }
    }
}
