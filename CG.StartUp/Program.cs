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
                new Recipe("Bavarios", "https://jenzvandevelde-images-host.onrender.com/frambozenbavarois.png", "https://jenzvandevelde-images-host.onrender.com/Bavarois.mp4"),
                new Recipe("Scampi", "https://jenzvandevelde-images-host.onrender.com/ScampiDiabolique.png", "https://jenzvandevelde-images-host.onrender.com/ScampiDiabolique.mp4"),
                new Recipe("SpagettiBolognaise","https://jenzvandevelde-images-host.onrender.com/spaghetti.jpeg","https://jenzvandevelde-images-host.onrender.com/SpaghettiBolognaise.mp4"),
                new Recipe("Stoofvlees","https://jenzvandevelde-images-host.onrender.com/Stoofvlees.png","https://jenzvandevelde-images-host.onrender.com/Stoofvlees.mp4")
            };
            foreach (Recipe recipe in recipes)
            {
                manager.AddRecipe(recipe);
            }


            //voeg Brandproducts
            List<BrandProduct> brandProducts = new()
            {
                new BrandProduct(1,"Fama",12m,"boter","https://jenzvandevelde-images-host.onrender.com/famaboter.webp"),
                new BrandProduct(2,"SpaghettiBarilla",10m,"spagetti","https://jenzvandevelde-images-host.onrender.com/spaghettibarilla.jpg"),
                new BrandProduct(3,"KaasSpaghettiMixBoni",6.78m,"spagetti kaas mix","https://jenzvandevelde-images-host.onrender.com/kaasspaghettimix.jpeg"),
                new BrandProduct(4,"LookEveryday",4m,"knoflook","https://jenzvandevelde-images-host.onrender.com/lookeveryday.jpeg"),
                new BrandProduct(5,"PassataAlvea",3.7m,"Elvea Tradizionale is de perfecte basis voor een natuurlijk pastagerecht, of voor een snelle spaghetti (bolognaise).","https://jenzvandevelde-images-host.onrender.com/pasataelvea.avif"),
                new BrandProduct(6,"RodewijnElvado",15.99m,"rode wijn","https://jenzvandevelde-images-host.onrender.com/rodewijnelvado.jpeg"),
                new BrandProduct(7,"RundervleesGehaktWahid",5m,"rund gehakt","https://jenzvandevelde-images-host.onrender.com/rundervleesgehaktwahid.jpeg"),
                new BrandProduct(8,"SelderBoni",2.4m,"selder","https://jenzvandevelde-images-host.onrender.com/selderbio.jpeg"),
                new BrandProduct(9,"TomatenpureeHeinz",4,"tomatenpuree","https://jenzvandevelde-images-host.onrender.com/tomatenpureeheinz.jpeg"),
                new BrandProduct(10,"UienEveryday",3,"uien","https://jenzvandevelde-images-host.onrender.com/uieneveryday.jpeg"),
                new BrandProduct(11,"WortelenBoni",2.4m,"kleine wortelen","https://jenzvandevelde-images-host.onrender.com/wortelenboni.jpeg")
            };
            foreach(BrandProduct brandProduct in brandProducts)
            {
                manager.AddBrandProduct(brandProduct);
            }


            ////voeg products
            //list<product> products = new()
            //{
            //    new product(),
            //    new product()
            //};
            //foreach (product product in products)
            //{
            //    manager.addproduct(product);
            //}


            ////voeg timings
            //list<timing> timings1 = new()
            //{
            //    new timing(),
            //    new timing()
            //};
            //foreach (timing timing in timings1)
            //{
            //    manager.addtiming(1, timing);
            //}
            //list<timing> timings2 = new()
            //{
            //    new timing(),
            //    new timing()
            //};
            //foreach (timing timing in timings1)
            //{
            //    manager.addtiming(2, timing);
            //}
            //list<timing> timings3 = new()
            //{
            //    new timing(),
            //    new timing()
            //};
            //foreach (timing timing in timings1)
            //{
            //    manager.addtiming(3, timing);
            //}
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