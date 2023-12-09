using CG.API.Mappers;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CG.BL.Models;
using CollectAndGO.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CG.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        //mappers - moet nog injecteert worden!
        private DomainManager manager;
        private MapFromDTO mapFromDTO;
        private MapToDTO mapToDTO;

        public RecipeController(DomainManager manager,MapFromDTO mapFromDTO, MapToDTO mapToDTO)
        {
            this.manager = manager;
            this.mapFromDTO = mapFromDTO;
            this.mapToDTO = mapToDTO;
        }

        //vergeet de Badrequest (status code) door te geven 
        //Logging inplementeren!

        [HttpGet]
        public ActionResult<List<RecipeDtoRESToutputDTO>> GetAllRecipes() 
        {
            try
            {
                return mapToDTO.MapRecipies(manager.GetRecipes());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        //[Route("https://localhost:7226/api/Recipe")]
        [HttpGet("({recipeId})")]
        public ActionResult<RecipeRESToutputDTO>GetRecipeById(int recipeId)
        {
            try
            {
                return mapToDTO.MapFromRecipeDomain(manager.GetRecipeById(recipeId));
                /*return dummyDTOlist.Where(r => r.RecipeId == recipeId).First();*/
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }
        //inputDTo aanmaken waar er geen id in zit!
        [HttpPost]
        public ActionResult<RecipeRESTinputDTO> AddRecipe([FromBody] RecipeRESTinputDTO recipeRESTinputDTO)
        {
            try
            {
                //voeg toe? return de toegevoegde waarde?
                manager.AddRecipe(mapFromDTO.MapToDomainRecipe(recipeRESTinputDTO));
                return recipeRESTinputDTO;
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }

        }

        
        
        [HttpPut("IsActive/({recipeId})")]
        public ActionResult<string> IsActiveOfRecipe(int RecipeId)
        {
            try
            {
                bool isActive = manager.ActivateRecipe(RecipeId);
                return "The value of recipeId [" + RecipeId + "] has been set to " + isActive;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }
        
        //
        [HttpPut("({recipeId})")]
        public ActionResult<RecipeRESTinputDTO> EditRecipe(int recipeId ,[FromBody] RecipeRESTinputDTO recipeRESTinputDTO)
        {
            try
            {
                //Update recipe zonder timers updaten in de databank!
                manager.UpdateRecipe(recipeId, mapFromDTO.MapToDomainRecipe(recipeRESTinputDTO));
                return recipeRESTinputDTO;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }

        }

        [HttpDelete("{recipeId}")]
        public ActionResult<List<RecipeRESToutputDTO>> RemoveRecipe(int recipeId)
        {

            try
            {
                manager.RemoveRecipe(recipeId);
                //moet dit hier nog goed inplementeren!
                return null;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }

        }

    }
}
