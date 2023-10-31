using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Persistence.Model
{
    public class Recipe
    {
        public Recipe(string name, string category, bool active, string imgUrl, string videoUrl)
        {
            Name = name;
            Category = category;
            Active = active;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public List<Timing> Timings { get; set; }
    }
}
