using CG.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Models
{
    /// <summary>
    /// Recepenten klas commentaar!!!!
    /// </summary>
    public class Recipe
    {
        private int _recipeId;
        private string _name;
        private string _category;
        private string _imgUrl;
        private string _videoUrl;
        private List<Timing> timings;
        private bool _isActive = false;

        public Recipe(int id, string name,string category,string imgUrl, string videoUrl) : this(name,category,imgUrl,videoUrl)
        {
            RecipeId = id;           
        }
        public Recipe(string name, string category, string imgUrl, string videoUrl)
        {
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            timings= new List<Timing>();
            
        }
       
        public List<Timing> GetTimings()
        {
            return timings;
        }
        public Timing GetTiming(int timingid)
        {
            if (timings.Any(timing => timing.TimingId == timingid))
            {
                return timings.First(t => t.TimingId == timingid);
            }else
            {
                throw new RecipeException("No timing found with this Id");
            }
            
        }


        public void AddTiming(Timing timing)
        {
            if (timing != null)
            {
                timings.Add(timing);
            }
            else
            {
                throw new RecipeException("Can't Add timing in Recipe.timings => timing is null");
            }
        }

        public int RecipeId { get { return _recipeId; } private set { _recipeId = value; } }
        public string Name { get { return _name;} private set { _name = value; } }
        public string Category { get { return _category; } private set { _category = value; } }
        public string ImgUrl { get { return _imgUrl;} private set { _imgUrl = value; } }
        public string VideoUrl { get { return _videoUrl;} private set {_videoUrl = value; } }
        public bool IsActive { get => _isActive; set => _isActive = value; }

        public override string? ToString()
        {
            return "Recipe : " + Name + $"\nimg url : {ImgUrl}";
        }
    }
}
