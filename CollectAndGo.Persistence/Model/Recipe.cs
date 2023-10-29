using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public List<Timing> Timings { get; set; }
    }
}
