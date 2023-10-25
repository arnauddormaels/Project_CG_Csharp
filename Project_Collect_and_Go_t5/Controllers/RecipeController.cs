using CG.API.Model.Output;
using CG.Application.Models;
using CollectAndGO.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private RecipeRESToutputDTO dummyDTO = new RecipeRESToutputDTO(1, "pasta", "imgUrl", "vidUrl", true); 
        private List<RecipeRESToutputDTO> dummyDTOlist ;
        private DomainManager manager ;
        private string url = "http://localhost:5209";

        public RecipeController(DomainManager manager)
        {
            this.manager = manager;
            dummyDTOlist = new List<RecipeRESToutputDTO> { dummyDTO,new RecipeRESToutputDTO(2,"lasagne","imgUrl","vidUrl",true) };
        }

        [HttpGet("({recipeId})")]
        public ActionResult<RecipeRESToutputDTO>GetRecipe(int recipeId)
        {
            try
            {
                return dummyDTOlist.Where(r => r.RecipeId == recipeId).First();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult<RecipeRESToutputDTO>AddRecipe([FromBody] RecipeRESToutputDTO recipeRESToutputDTO)
        {
            dummyDTOlist.Add(recipeRESToutputDTO);
            return recipeRESToutputDTO;
        }

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
