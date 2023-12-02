using CG.BL.Exceptions;
using CG.BL.Models;
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
            try
            {
                return _recipeRepo.GetRecipes();
            }
            catch(Exception ex)
            {
                throw new DomainManagerException("GetRecipes", ex);
            }
            
        }
        public List<Product> GetProducts() 
        {
            try
            {
                return _productRepo.GetProducts();
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("GetProducts", ex);
            }
            
        }

        public Recipe GetRecipeById(int recipeId)
        {
            try
            {
                return _recipeRepo.GetRecipeById(recipeId);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("GetRecipeById", ex);
            }
            
        }

        public void AddRecipe(Recipe recipe)
        {
            try
            {
                _recipeRepo.AddRecipe(recipe);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("AddRecipe", ex);
            }
            
        }
        public void RemoveRecipe(int recipeId)   
        {
            try
            {
                _recipeRepo.RemoveRecipe(recipeId);  
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("RemoveRecipe", ex);
            }
            
        }      

        public void UpdateRecipe(int recipeId, Recipe recipe)
        {
            try
            {
                _recipeRepo.UpdateRecipe(recipeId, recipe);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("UpdateRecipe", ex);
            }
        
        }

        public void ActivateRecipe(int recipeId)
        {
            try
            {
                _recipeRepo.ActivateRecipe(recipeId); //not implemented
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("ActivateRecipe", ex);
            }
            
        }  

        //Timings Methodes
        public List<Timing> GetTimingsFromRecipe(int recipeId)
        {
            try
            {
                return _timingRepository.GetAllTimingsFromRecipe(recipeId);
            }
            catch(Exception ex)
            {
                throw new DomainManagerException("GetTimingsFromRecipe", ex);
            }
           
        }

        public void AddTiming(int recipeId, Timing timing)
        {
            try
            {
                _timingRepository.AddTimingToRecipe(recipeId, timing);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("AddTiming", ex);
            }
            
        }

        //ProductMethodes
        public void AddProduct(Product product)
        {
            try
            {
                _productRepo.AddProduct(product);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("AddProduct", ex);
            }
            
        }

        public Product GetProductById(int productId)
        {
            try
            {
               return _productRepo.GetProductById(productId);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("GetProductById", ex);
            }
        }

        //BrandProductMethodes
        public void AddBrandProduct(BrandProduct brandProduct)
        {
            try
            {
                _productRepo.AddBrandProduct(brandProduct);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("AddBrandProduct", ex);
            }
            
        }

        public List<BrandProduct> GetBrandProducts(int productId)
        {
            try
            {
                return _productRepo.GetBrandProducts(productId);
            }
            catch (Exception ex)
            {
                throw new DomainManagerException("GetBrandProducts", ex);
            }
            
        }
    }
}