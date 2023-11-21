using CG.API.Mappers;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CG.BL.Models;
using CollectAndGO.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private RecipeRESToutputDTO dummyDTO = new RecipeRESToutputDTO(1, "pasta Bolognaise", "Pasta", "https://jenzvandevelde-images-host.onrender.com/tagliatelle%20bolognaise.jpeg", "https://jenzvandevelde-images-host.onrender.com/SpaghettiBolognaise.mp4", true);
        private List<RecipeRESToutputDTO> dummyDTOlist;
        private DomainManager manager ;
        private string url = "http://localhost:5209";
        //mappers - moet nog injecteert worden!
        private MapFromDTO mapFromDTO;
        private MapToDTO mapToDTO;

        public RecipeController(DomainManager manager,MapFromDTO mapFromDTO, MapToDTO mapToDTO)
        {
            this.manager = manager;
            this.mapFromDTO = mapFromDTO;
            this.mapToDTO = mapToDTO;
            dummyDTOlist = new List<RecipeRESToutputDTO> { dummyDTO, new RecipeRESToutputDTO(2, "lasagne", "lasagne","https://jenzvandevelde-images-host.onrender.com/ui.jpeg", "vidUrl", true) };
        }

        [HttpGet]
        public ActionResult<List<RecipeRESToutputDTO>> GetAllRecipes()         //Eerste connectie met de databank is geslaag whoop whoop 
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

        [Route("/api/Product")]
        [HttpGet]
        public ActionResult<List<ProductRESToutputDTO>> GetAllProduct()
        {
            try
            {
                return mapToDTO.MapProducs(manager.GetProducts());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }
        //[Route("https://localhost:7226/api/Recipe")]
        [HttpGet("({recipeId})")]
        public ActionResult<RecipeRESToutputDTO>GetRecipe(int recipeId)
        {
            try
            {
                return mapToDTO.MapFromRecipeDomain(manager.GetRecipe(recipeId));
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
/*            dummyDTOlist.Add(recipeRESToutputDTO);
            return recipeRESToutputDTO;*/
        }
        
        //
        [HttpPut("{id}")]
        public ActionResult<RecipeRESToutputDTO> EditRecipe(int id ,[FromBody] RecipeRESToutputDTO recipeRESToutputDTO)
        {
            int index = dummyDTOlist.IndexOf(dummyDTOlist.Where(r => r.RecipeId == id).First());
            dummyDTOlist[index] = recipeRESToutputDTO;
            return dummyDTOlist[index];
        }

        [HttpDelete("{id}")]
        public ActionResult<List<RecipeRESToutputDTO>> DeleteRecipe(int id)
        {
            int index = dummyDTOlist.IndexOf(dummyDTOlist.Where(r => r.RecipeId == id).First());
            dummyDTOlist.Remove(dummyDTOlist[index]);
            return dummyDTOlist;
        }

    }
}
