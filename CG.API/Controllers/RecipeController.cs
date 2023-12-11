﻿using CG.API.Mappers;
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
        private readonly ILogger logger;

        public RecipeController(DomainManager manager, MapFromDTO mapFromDTO, MapToDTO mapToDTO, ILoggerFactory loggerFactory)
        {
            this.manager = manager;
            this.mapFromDTO = mapFromDTO;
            this.mapToDTO = mapToDTO;
            this.logger = loggerFactory.CreateLogger("RecipeController");
        }

        [HttpGet]
        public ActionResult<List<RecipeDtoRESToutputDTO>> GetAllRecipes() 
        {
            try
            {
                logger.LogInformation(1001,"GetAllRecipes called");
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
                logger.LogInformation("GetRecipeById called");
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

        [HttpPost]
        public ActionResult<RecipeRESTinputDTO> AddRecipe([FromBody] RecipeRESTinputDTO recipeRESTinputDTO)
        {
            try
            {
                logger.LogInformation("AddRecipe called");
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
                logger.LogInformation("IsActiveOfRecipe called");
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
                logger.LogInformation("EditRecipe called");
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
                logger.LogInformation("RemoveRecipe called");
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
