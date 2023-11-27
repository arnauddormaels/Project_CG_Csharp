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
            //CreateDB();
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


            //voeg products
            List<Product> products = new()
            {
                new Product(1,"boter","https://jenzvandevelde-images-host.onrender.com/boter.jpeg",brandProducts[0]),
                new Product(2,"Spaghetti","https://jenzvandevelde-images-host.onrender.com/spaghetti.jpeg",brandProducts[1]),
                new Product(3,"KaasSpaghettiMix","https://jenzvandevelde-images-host.onrender.com/kaasspaghettimix.jpeg",brandProducts[2]),
                new Product(4,"Look","https://jenzvandevelde-images-host.onrender.com/look.jpeg",brandProducts[3]),
                new Product(5,"Passata","https://jenzvandevelde-images-host.onrender.com/pasata.jpeg",brandProducts[4]),
                new Product(6,"Rodewijn","https://jenzvandevelde-images-host.onrender.com/rodewijn.jpeg",brandProducts[5]),
                new Product(7,"RundervleesGehakt","https://jenzvandevelde-images-host.onrender.com/rundervleesgehakt.webp",brandProducts[6]),
                new Product(8,"Selder","https://jenzvandevelde-images-host.onrender.com/selder.avif",brandProducts[7]),
                new Product(9,"Tomatenpuree","https://jenzvandevelde-images-host.onrender.com/tomatenpuree.jpeg",brandProducts[8]),
                new Product(10,"Uien","https://jenzvandevelde-images-host.onrender.com/ui.jpeg",brandProducts[9]),
                new Product(11,"Wortelen","https://jenzvandevelde-images-host.onrender.com/wortelen.jpeg",brandProducts[10])
            };
            foreach (Product product in products)
            {
                manager.AddProduct(product);
            }


            //voeg timings
            List<Timing> timings1 = new()
            {
                new Timing(1,5,products[1]),
                new Timing(7,8,products[2])
            };
            foreach (Timing timing in timings1)
            {
                manager.AddTiming(1, timing);
            }

            List<Timing> timings2 = new()
            {
                new Timing(3,6,products[3]),
                new Timing(6,9,products[4])
            };
            foreach (Timing timing in timings2)
            {
                manager.AddTiming(2, timing);
            }

            List<Timing> timings3 = new()
            {
                new Timing(5,7,products[5]),
                new Timing(10,15,products[6])
            };
            foreach (Timing timing in timings3)
            {
                manager.AddTiming(3, timing);
            }

            List<Timing> timings4 = new()
            {
                new Timing(1,5,products[7]),
                new Timing(1,5,products[8])
            };
            foreach (Timing timing in timings4)
            {
                manager.AddTiming(4, timing);
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