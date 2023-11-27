﻿using CG.BL.Models;
using CG.BL.Repositorys;

namespace CollectAndGO.Application
{
    public class DomainManager
    {
        private readonly IRecipeRepository _recipeRepo;
        private readonly IProductRepository _productRepo;
        private readonly ITimingRepository _timingRepository;

        public DomainManager(IRecipeRepository recipeRepo, IProductRepository productRepo, ITimingRepository timingRepository)
        {
            _recipeRepo = recipeRepo;
            _productRepo = productRepo;
            _timingRepository = timingRepository;
        }

        //Recipes Methodes
        public List<Recipe> GetRecipes()
        {
            return _recipeRepo.GetRecipes();
        }
        public List<Product> GetProducts() 
        {
            return _productRepo.GetProducts();
        }

        public Recipe GetRecipe(int recipeId)
        {
            return _recipeRepo.GetRecipe(recipeId);
        }

        public void AddRecipe(Recipe recipe)
        {
            //Recipe recipe = new Recipe(recipeInfo[0], recipeInfo[1], recipeInfo[2]);
            _recipeRepo.AddRecipe(recipe);
        }
        public void RemoveRecipe(string recipeId)   
        {
            _recipeRepo.RemoveRecipe(recipeId);
        }       //Not Implemented

        public void UpdateRecipe(int recipeId, Recipe recipe)
        {
            _recipeRepo.UpdateRecipe(recipeId, recipe);
        }

        public void ActivateRecipe(string recipeId)
        {
            _recipeRepo.ActivateRecipe(recipeId);
        }  //not implemented

        //Timings Methodes
        public List<Timing> GetTimingsFromRecipe(int recipeId)
        {
           return _timingRepository.GetAllTimingsFromRecipe(recipeId);
        }

        public void AddTiming(int recipeId, Timing timing)
        {
            _timingRepository.AddTimingToRecipe(recipeId, timing);
        }

        //ProductMethodes
        public void addProduct(Product product)
        {
           _productRepo.AddProduct(product);
        }

        //BrandProductMethodes
        public void AddBrandProduct(BrandProduct brandProduct)
        {
            _productRepo.AddBrandProduct(brandProduct);
        }

        public List<BrandProduct> GetBrandProducts(int productId)
        {
            return _productRepo.GetBrandProducts(productId);
        }
    }
}