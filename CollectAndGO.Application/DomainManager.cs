using CG.Application.Models;
using CG.Application.Repositorys;

namespace CollectAndGO.Application
{
    public class DomainManager
    {
        private readonly IRecipeRepository _recipeRepo;
        private readonly IProductRepository _productRepo;

        public DomainManager(IRecipeRepository recipeRepo, IProductRepository productRepo)
        {
            _recipeRepo = recipeRepo;
            _productRepo = productRepo;
        }

        public List<Recipe> GetRecipes()
        {
            return _recipeRepo.GetRecipes();
        }
        public List<Product> GetProducts(int recipeId) {
        return _productRepo.GetProducts(recipeId);
        }

        public void AddRecipe(List<string> stringListRecipe)
        {
            Recipe recipe = new Recipe(stringListRecipe[0], stringListRecipe[1], stringListRecipe[2]);
            _recipeRepo.AddRecipe(recipe);
        }
        public void RemoveRecipe(string recipeId)
        {
            _recipeRepo.RemoveRecipe(recipeId);
        }
    }
}