using CG.BL.Models;
using CG.BL.Repositorys;
using CG.DL;
using CG.DL.Data;
using CG.DL.Mappers;
using CG.DL.Repositorys;
using CollectAndGO.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

namespace CG.StartUp
{
    internal class Program
    {
        private static MapFromEntity fromEntity = new MapFromEntity();
        private static MapToEntity toEntity = new();
        readonly static IRecipeRepository recipeRepo = new RecipeRepository(fromEntity,toEntity);
        readonly static IProductRepository productRepo = new ProductRepository(fromEntity, toEntity);
        readonly static ITimingRepository timingRepo = new TimingRepository(fromEntity, toEntity);
        readonly static DomainManager manager = new DomainManager(recipeRepo, productRepo,timingRepo);

        static void Main(string[] args)
        {
            CreateDB();
            //FillDatabase(); //work in progress

            //Testmethodes 
            /*
            //ShowRecipes();               //Werkt met EF

            //ShowProductsFromRecipe(1);                

            //ShowProducts();

            //AddRecipe(new List<string>{ "Lasagna", "/videoUrlLasagna", "/ImgUrlLasagna"});
            */
        }
        
        private static void FillDatabase()
        {
            //voeg Recipes
            List<Recipe> recipes = new()
            {
                new Recipe("Lasania", "https://jenzvandevelde-images-host.onrender.com/boter.jpeg", "videoUrl"),
                new Recipe("Bolagne", "imgUrl", "VideoUrl")
            };
            foreach (Recipe recipe in recipes)
            {
                manager.AddRecipe(recipe);
            }

            //voeg Brandproducts
            List<BrandProduct> brandProducts = new()
            {
                new BrandProduct(),
                new BrandProduct()
            };
            foreach(BrandProduct brandProduct in brandProducts)
            {
                manager.AddBrandProduct(brandProduct);
            }

            //voeg products
            List<Product> products = new()
            {
                new Product(),
                new Product()
            };
            foreach(Product product in products)
            {
                manager.AddProduct(product);
            }

            //voeg timings
            List<Timing> timings = new()
            {
                new Timing(),
                new Timing()
            };
            foreach (Timing timing in timings)
            {
                manager.AddTiming(timing);
            }

            

        }

        public static void CreateDB()
        {
            DatabaseContext context = new DatabaseContext();
            context.Database.EnsureDeleted();//deze database verwijderen
            context.Database.EnsureCreated();//niet save maar snel en gemakkelijk aanmaken..... 
        }  //done

        public static void TransferDataToCVS()
        {

        }

        public static void ShowRecipes()
        {
            manager.GetRecipes().ForEach(r =>
            {
                Console.WriteLine(r.ToString());
                Console.WriteLine();
            });
        }   //done
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
        /*        public static void AddRecipe(List<string> stringListRecipe)
        {
            manager.AddRecipe(stringListRecipe);
            ShowRecipes();
        }*/
    }
}