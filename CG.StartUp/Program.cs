using CG.Application.Repositorys;
using CG.Persistence;
using CG.Persistence.Data;
using CG.Persistence.Repositorys;
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
            CreateDB();

            //ShowRecipes();

            //ShowProductsFromRecipe(1);                  //not finished

            //ShowProducts();

             //AddRecipe(new List<string>{ "Lasagna", "/videoUrlLasagna", "/ImgUrlLasagna"});

        }

        public static void CreateDB()
        {
            RecipeContext context = new RecipeContext();
            context.Database.EnsureDeleted();//deze database verwijderen
            context.Database.EnsureCreated();//niet save maar snel en gemakkelijk aanmaken..... 
        }

        public static void addBoek()
        {
            RecipeEFRepository repository = new RecipeEFRepository();
        }

        public static void ShowRecipes()
        {
            manager.GetRecipes().ForEach(r =>
            {
                Console.WriteLine(r.ToString());
                Console.WriteLine();
            });
        }
        //public static void ShowProductsFromRecipe(int recipeId)            //Not finished
        //{

        //    Console.WriteLine("Lijst van producten met Id " + recipeId);
        //    Console.WriteLine();
        //    manager.GetProducts().ForEach(p =>
        //    {
        //        Console.WriteLine(p.ToString());
        //        Console.WriteLine();
        //    });
        //}
        public static void ShowProducts()
        {
            manager.GetRecipes().ForEach(r =>
            {
                Console.WriteLine(r.ToString());
                Console.WriteLine();
                manager.GetProducts().ForEach(p =>
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