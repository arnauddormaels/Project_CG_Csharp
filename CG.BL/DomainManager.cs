using CG.BL.Models;
using CG.BL.Repositorys;

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
        public List<Product> GetProducts() {
            return _productRepo.GetProducts();
        }

        public void AddRecipe(List<string> recipeInfo)
        {
            Recipe recipe = new Recipe(recipeInfo[0], recipeInfo[1], recipeInfo[2]);
            _recipeRepo.AddRecipe(recipe);
        }
        public void RemoveRecipe(string recipeId)   
        {
            _recipeRepo.RemoveRecipe(recipeId);
        }       //Not Implemented

        public void ActivateRecipe(string recipeId)
        {
            _recipeRepo.ActivateRecipe(recipeId);
        }  //not implemented

    }
}