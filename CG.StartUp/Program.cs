﻿using CG.BL.Repositorys;
using CG.DL;
using CG.DL.Data;
using CG.DL.Repositorys;
using CollectAndGO.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

namespace CG.StartUp
{
    internal class Program
    {
        readonly static IRecipeRepository recipeRepo = new RecipeRepository();
        readonly static IProductRepository productRepo = new ProductRepository();
        readonly static ITimingRepository timingRepo = new TimingRepository();
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
            //Work in progress :)
        }

        public static void CreateDB()
        {
            DatabaseContext context = new DatabaseContext();
            context.Database.EnsureDeleted();//deze database verwijderen
            context.Database.EnsureCreated();//niet save maar snel en gemakkelijk aanmaken..... 
        }  //done

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