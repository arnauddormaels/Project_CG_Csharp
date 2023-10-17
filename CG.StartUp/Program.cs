using CG.Application.Repositorys;
using CG.Persistence;
using CollectAndGO.Application;
using System.Security.Cryptography.X509Certificates;

namespace CG.StartUp
{
    internal class Program
    {
        static IRecipeRepository recipeRepo = new RecipeMapper();
        static IProductRepository productRepo = new ProductMapper();
        static DomainManager manager = new DomainManager(recipeRepo, productRepo);

        static void Main(string[] args)
        {

            ShowRecipes();

            //ShowProductsFromRecipe(1);

            //ShowProductsFromRecipes();

            // AddRecipe(new List<string>{ "Lasagna", "/videoUrlLasagna", "/ImgUrlLasagna"});
            
            



        }
        public static void ShowRecipes()
        {
            manager.GetRecipes().ForEach(r =>
            {
                Console.WriteLine(r.ToString());
                Console.WriteLine();
            });
        }
        public static void ShowProductsFromRecipe(int recipeId)
        {

            Console.WriteLine("Lijst van producten met Id " + recipeId);
            Console.WriteLine();
            manager.GetProducts(recipeId).ForEach(p =>
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine();
            });
        }
        public static void ShowProductsFromRecipes()
        {
            manager.GetRecipes().ForEach(r =>
            {
                Console.WriteLine(r.ToString());
                Console.WriteLine();
                manager.GetProducts(r.Id).ForEach(p =>
                {
                    Console.WriteLine(p.ToString());
                    Console.WriteLine();
                    Console.WriteLine();
                });
            });
        }
        public static void AddRecipe(List<string> stringListRecipe)
        {
            manager.AddRecipe(stringListRecipe);
            ShowRecipes();
        }



    }
}