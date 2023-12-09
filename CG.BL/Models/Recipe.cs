using CG.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
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
        private Category _category;
        private string _imgUrl;
        private string _videoUrl;
        private List<Timing> _timings;
        private bool _isActive = false;


        public Recipe(int recipeId, string name, string category ,string imgUrl, string videoUrl, bool isActive, List<Timing> timings)
        {
            RecipeId = recipeId;
            Name = name;
            Category = (Category)Enum.Parse(typeof(Category), category);
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            IsActive = isActive;
            Timings = timings;
        }

        public Recipe(string name, string category ,string imgUrl, string videoUrl, bool isActive)
        {
            Name = name;
            Category = (Category)Enum.Parse(typeof(Category), category);
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            IsActive = isActive;
        }

        public Timing GetTimingById(int timingid)
        {
            if (_timings.Any(timing => timing.TimingId == timingid))
            {
                return _timings.First(t => t.TimingId == timingid);
            }else
            {
                throw new RecipeException("No timing found with this Id");
            }
            
        }

        public void AddTiming(Timing timing)
        {
            if (timing != null)
            {
                _timings.Add(timing);
            }
            else
            {
                throw new RecipeException("Can't Add timing in Recipe.timings => timing is null");
            }
        }

        public int RecipeId { get { return _recipeId; } private set { _recipeId = value; } }
        public string Name { get { return _name;} private set { _name = value; } }
        public Category Category { get { return _category; } private set { _category = value; } }
        public string ImgUrl { get { return _imgUrl;} private set { _imgUrl = value; } }
        public string VideoUrl { get { return _videoUrl;} private set {_videoUrl = value; } }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public List<Timing> Timings { get { return _timings; } set { _timings = value; } }

        public override string? ToString()
        {
            return "Recipe : " + Name + $"\nimg url : {ImgUrl}";
        }
    }
}
