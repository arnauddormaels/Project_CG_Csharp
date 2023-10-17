using CG.Application.Models;
using CG.Application.Repositorys;

namespace CollectAndGO.Application
{
    public class DomainManager
    {
        private readonly IRecipeRepository _recipeRepo;

        public DomainManager(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        public List<Recipe> GetRecipes()
        {
            return _recipeRepo.GetRecipes();
        }
    }
}