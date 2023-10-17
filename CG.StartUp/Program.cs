using CG.Application.Repositorys;
using CG.Persistence;
using CollectAndGO.Application;
using System.Security.Cryptography.X509Certificates;

namespace CG.StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRecipeRepository recipeRepo = new RecipeMapper();
            DomainManager manager = new DomainManager(recipeRepo);

            manager.GetRecipes().ForEach(r => {
                Console.WriteLine(r.ToString());
                Console.WriteLine();    
            });  ;
            
        }
    }
}