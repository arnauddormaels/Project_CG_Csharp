using CG.API.Model.Output;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingController : ControllerBase
    {
        private List<DummyTimingRESToutputDTO> dummyTimings = new List<DummyTimingRESToutputDTO>
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
            };


        // GET: api/Timing
        [HttpGet]
        public ActionResult<IEnumerable<DummyTimingRESToutputDTO>> GetTimings()
        {
            return dummyTimings;
        }

        // GET: api/Timing/{id}
        [HttpGet("{id}")]
        public ActionResult<DummyTimingRESToutputDTO> GetTiming(int id)
        {
            var timing = dummyTimings.FirstOrDefault(t => t.TimingId == id);
            if (timing == null)
            {
                return NotFound("Timing not found");
            }
            return timing;
        }

        // POST: api/Timing
        [HttpPost]
        public ActionResult<DummyTimingRESToutputDTO> PostTiming([FromBody] DummyTimingRESToutputDTO timingDTO)
        {
            if (dummyTimings.Any(t => t.TimingId == timingDTO.TimingId))
            {
                return Conflict("Timing with the same ID already exists");
            }

            dummyTimings.Add(timingDTO);
            return CreatedAtAction(nameof(GetTiming), new { id = timingDTO.TimingId }, timingDTO);
        }

        // PUT: api/Timing/{id}
        [HttpPut("{id}")]
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
        }
    }
}
