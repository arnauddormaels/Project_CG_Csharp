using CG.API.Mappers;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CollectAndGO.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingController : ControllerBase
    {
        //bij timings geef je ook alle producten mee die daar bij horen!

/*        private List<DummyTimingRESToutputDTO> dummyTimings = new List<DummyTimingRESToutputDTO>
            {
                new DummyTimingRESToutputDTO(1, "https://jenzvandevelde-images-host.onrender.com/boter.jpeg", "https://jenzvandevelde-images-host.onrender.com/famaboter.webp", "Boter", "Fama", "00:34", "00:40"),
                new DummyTimingRESToutputDTO(2, "https://jenzvandevelde-images-host.onrender.com/ui.jpeg", "https://jenzvandevelde-images-host.onrender.com/uieneveryday.jpeg", "Uien", "Everyday", "00:34", "00:40"),
                new DummyTimingRESToutputDTO(3, "https://jenzvandevelde-images-host.onrender.com/look.jpeg", "https://jenzvandevelde-images-host.onrender.com/lookeveryday.jpeg", "Look", "Everyday", "00:34", "00:40"),
                new DummyTimingRESToutputDTO(4, "https://jenzvandevelde-images-host.onrender.com/varkensgehakt.jpeg", "https://jenzvandevelde-images-host.onrender.com/varkensgehaktbio.jpeg", "Varkensgehakt", "Bio Boni", "00:45", "00:50"),
                new DummyTimingRESToutputDTO(5, "https://jenzvandevelde-images-host.onrender.com/rundervleesgehakt.webp", "https://jenzvandevelde-images-host.onrender.com/rundervleesgehaktwahid.jpeg", "Rundervlees", "Wahid", "00:45", "00:50"),
                new DummyTimingRESToutputDTO(6, "https://jenzvandevelde-images-host.onrender.com/wortelen.jpeg", "https://jenzvandevelde-images-host.onrender.com/wortelenboni.jpeg", "Wortelen", "Boni", "00:52", "00:53"),
                new DummyTimingRESToutputDTO(7, "https://jenzvandevelde-images-host.onrender.com/selder.avif", "https://jenzvandevelde-images-host.onrender.com/selderbio.jpeg", "Selder", "Bio Boni", "00:52", "00:53" ),
                new DummyTimingRESToutputDTO(8, "https://jenzvandevelde-images-host.onrender.com/paprika.jpeg", "https://jenzvandevelde-images-host.onrender.com/paprika%20bio.jpeg", "Paprika", "Everyday", "00:52", "00:53"                 ),
                new DummyTimingRESToutputDTO(9, "https://jenzvandevelde-images-host.onrender.com/rodewijn.jpeg", "https://jenzvandevelde-images-host.onrender.com/rodewijnelvado.jpeg", "Rode Wijn", "Elvado", "00:59", "01:00"  ),
                new DummyTimingRESToutputDTO(10, "https://jenzvandevelde-images-host.onrender.com/pasata.jpeg", "https://jenzvandevelde-images-host.onrender.com/pasataelvea.avif", "Passata", "Elvea", "00:53", "00:54"),
                new DummyTimingRESToutputDTO(11, "https://jenzvandevelde-images-host.onrender.com/tomatenpuree.jpeg", "https://jenzvandevelde-images-host.onrender.com/tomatenpureeheinz.jpeg", "Tomatenpuree", "Heinz", "00:59", "01:00"),
                new DummyTimingRESToutputDTO(12, "https://jenzvandevelde-images-host.onrender.com/spaghetti.jpeg", "https://jenzvandevelde-images-host.onrender.com/spaghettibarilla.jpg", "Spaghetti", "Barilla", "01:36", "1:43"),
                new DummyTimingRESToutputDTO(13, "https://jenzvandevelde-images-host.onrender.com/gerasptekaas.jpeg", "https://jenzvandevelde-images-host.onrender.com/kaasspaghettimix.jpeg", "Gemalen Kaas", "Boni", "01:46", "01:50")
            };*/

        private DomainManager manager;
        private MapFromDTO mapFromDTO;
        private MapToDTO mapToDTO;

        public TimingController(DomainManager manager, MapFromDTO mapFromDTO, MapToDTO mapToDTO)
        {
            this.manager = manager;
            this.mapFromDTO = mapFromDTO;
            this.mapToDTO = mapToDTO;
        }


        // GET: api/Timing
        [HttpGet("({recipeId})")]
        public ActionResult<IEnumerable<TimingRESToutputDTO>> GetAllTimingsFromRecipe(int recipeId)
        {
            try
            {
               return mapToDTO.MapTimings(manager.GetTimingsFromRecipe(recipeId));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        // POST: api/Timing
        [HttpPost]
        public ActionResult<TimingRESTinputDTO> AddTimingToRecipe(int recipeId,[FromBody] TimingRESTinputDTO timingInputDTO)
        {
            try
            {
                //voorlopig zal dit de productId alleen gebruiken om de timing te linken met een bestaan product!
                manager.AddTiming(recipeId, mapFromDTO.MapToDomainTiming(timingInputDTO));
                return timingInputDTO;
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }

        }

        // PUT: api/Timing/{id}
        /*[HttpPut("{id}")]
        public IActionResult PutTiming(int id, [FromBody] DummyTimingRESToutputDTO timingDTO)
        {
            var timing = dummyTimings.FirstOrDefault(t => t.TimingId == id);
            if (timing == null)
            {
                return NotFound("Timing not found");
            }

            timing.BoterImgUrl = timingDTO.BoterImgUrl;
            timing.FamaImgUrl = timingDTO.FamaImgUrl;
            timing.BoterName = timingDTO.BoterName;
            timing.FamaName = timingDTO.FamaName;
            timing.BeginTime = timingDTO.BeginTime;
            timing.EndTime = timingDTO.EndTime;
            return NoContent();
        }

        // DELETE: api/Timing/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTiming(int id)
        {
            var timing = dummyTimings.FirstOrDefault(t => t.TimingId == id);
            if (timing == null)
            {
                return NotFound("Timing not found");
            }

            dummyTimings.Remove(timing);
            return NoContent();
        }*/
    }
}
