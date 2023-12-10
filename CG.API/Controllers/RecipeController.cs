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
        /*private readonly ILogger logger;*/

        public RecipeController(DomainManager manager, MapFromDTO mapFromDTO, MapToDTO mapToDTO/*, ILogger<RecipeController> logger*/)
        {
            this.manager = manager;
            this.mapFromDTO = mapFromDTO;
            this.mapToDTO = mapToDTO;
        }

        //Logging inplementeren - Welke methodes dat je uitvoerd bij de controllers

        [HttpGet]
        public ActionResult<List<RecipeDtoRESToutputDTO>> GetAllRecipes() 
        {
            try
            { 
                return Ok(mapToDTO.MapRecipies(manager.GetRecipes()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Route("https://localhost:7226/api/Recipe")]
        [HttpGet("({recipeId})")]
        public ActionResult<RecipeRESToutputDTO>GetRecipeById(int recipeId)
        {
            try
            {
                Recipe recipe = manager.GetRecipeById(recipeId);
                if(recipe == null)
                {
                    return NotFound($"Recipe with ID {recipeId} not found");
                }

                return Ok(mapToDTO.MapFromRecipeDomain(recipe));
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //inputDTo aanmaken waar er geen id in zit!
        [HttpPost]
        public ActionResult<RecipeRESTinputDTO> AddRecipe([FromBody] RecipeRESTinputDTO recipeRESTinputDTO)
        {
            try
            {
                //voeg toe? return de toegevoegde waarde?
                Recipe recipe = mapFromDTO.MapToDomainRecipe(recipeRESTinputDTO);
                manager.AddRecipe(recipe);
                return CreatedAtAction(nameof(GetRecipeById), new { recipeId = recipe.RecipeId }, recipeRESTinputDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        //task!-TODO 
        [HttpPut("isActive/({recipeId})")]
        public ActionResult<string> IsActiveOfRecipe(int recipeId)
        {
            try
            {
                bool isActive = manager.ActivateRecipe(recipeId);
                return Ok("The value of recipeId [" + recipeId + "] has been set to " + !isActive);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("({recipeId})")]
        public ActionResult<RecipeRESTinputDTO> EditRecipe(int recipeId ,[FromBody] RecipeRESTinputDTO recipeRESTinputDTO)
        {
            try
            {
                //Update recipe zonder timers updaten in de databank!
                Recipe recipe = mapFromDTO.MapToDomainRecipe(recipeRESTinputDTO);
                manager.UpdateRecipe(recipeId,recipe);
                return Ok(recipeRESTinputDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{recipeId}")]
        public ActionResult<List<RecipeRESToutputDTO>> RemoveRecipe(int recipeId)
        {
            try
            {
                manager.RemoveRecipe(recipeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
