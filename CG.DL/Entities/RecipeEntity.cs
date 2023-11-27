using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Entities
{
    public class RecipeEntity
    {
        public RecipeEntity(string name, /*string category,*/ bool active, string imgUrl, string videoUrl)
        {
            Name = name;
            /*Category = category;*/
            Active = active;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        /*public string Category { get; set; }*/
        public bool Active { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public List<TimingEntity> Timings { get; set; }
        public DateTime? TimeLog { get; set; }

    }
}
