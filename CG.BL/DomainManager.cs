using CG.BL.DTO_s;
using CG.BL.OldExceptions;
using CG.BL.Models;
using CG.BL.Repositorys;
using CG.BL.Exceptions;

namespace CollectAndGO.Application
{
    public class DomainManager
    {
        private readonly IRecipeRepository _recipeRepo;
        private readonly IProductRepository _productRepo;
        private readonly ITimingRepository _timingRepo;

        public DomainManager(IRecipeRepository recipeRepo, IProductRepository productRepo, ITimingRepository timingRepository)
        {
            _recipeRepo = recipeRepo;
            _productRepo = productRepo;
            _timingRepo = timingRepository;
        }

        //Recipes Methodes - Vergeet de logging niet!
        public List<RecipeDTO> GetRecipes()
        {
            try
            {
                return _recipeRepo.GetRecipes();
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipes)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipes)));
                throw bex;
            }

        }
        public List<Product> GetProducts() 
        {
            try
            {
                return _productRepo.GetProducts();
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetProducts)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetProducts)));
                throw bex;
            }

        }

        public Recipe GetRecipeById(int recipeId)
        {
            try
            {
                return _recipeRepo.GetRecipeById(recipeId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipeById)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRecipeById)));
                throw bex;
            }

        }

        public void AddRecipe(Recipe recipe)
        {
            try
            {
                _recipeRepo.AddRecipe(recipe);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddRecipe)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddRecipe)));
                throw bex;
            }

        }
        public void RemoveRecipe(int recipeId)   
        {
            try
            {
                _recipeRepo.RemoveRecipe(recipeId);  
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveRecipe)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveRecipe)));
                throw bex;
            }

        }      

        public void UpdateRecipe(int recipeId, Recipe recipe)
        {
            try
            {
                _recipeRepo.UpdateRecipe(recipeId, recipe);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateRecipe)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateRecipe)));
                throw bex;
            }

        }

        public bool ActivateRecipe(int recipeId)
        {
            try
            {
                return _recipeRepo.ActivateRecipe(recipeId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ActivateRecipe)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ActivateRecipe)));
                throw bex;
            }

        }  

        //Timings Methodes
        public List<Timing> GetTimingsFromRecipe(int recipeId)
        {
            try
            {
                return _timingRepo.GetAllTimingsFromRecipe(recipeId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetTimingsFromRecipe)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetTimingsFromRecipe)));
                throw bex;
            }

        }

        public void AddTiming(int recipeId, Timing timing)
        {
            try
            {
                _timingRepo.AddTimingToRecipe(recipeId, timing);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddTiming)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddTiming)));
                throw bex;
            }

        }

        public void UpdateTiming(int timingId, Timing timing)
        {
            try
            {
                _timingRepo.UpdateTimingWithId(timingId, timing);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateTiming)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateTiming)));
                throw bex;
            }
        }

        public void RemoveTiming(int timingId)
        {
            try
            {
                _timingRepo.RemoveTimingFromRecipe(timingId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveTiming)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveTiming)));
                throw bex;
            }
        }

        //ProductMethodes
        public void AddProduct(Product product)
        {
            try
            {
                _productRepo.AddProduct(product);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddProduct)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddProduct)));
                throw bex;
            }

        }

        public Product GetProductById(int productId)
        {
            try
            {
               return _productRepo.GetProductById(productId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetProductById)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetProductById)));
                throw bex;
            }
        }

        //BrandProductMethodes
        public void AddBrandProduct(BrandProduct brandProduct)
        {
            try
            {
                _productRepo.AddBrandProduct(brandProduct);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddBrandProduct)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddBrandProduct)));
                throw bex;
            }

        }

        public List<BrandProduct> GetBrandProducts(int productId)
        {
            try
            {
                return _productRepo.GetBrandProducts(productId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetBrandProducts)));
                throw ex;
            }
            catch (Exception ex)
            {
                var bex = new BLException("Business Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetBrandProducts)));
                throw bex;
            }

        }

    }
}