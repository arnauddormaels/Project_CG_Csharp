using CG.BL.Exceptions;
using CG.BL.OldExceptions;
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

        public Recipe(string name, string category, string imgUrl, string videoUrl, bool isActive)
        {
            Name = name;
            Category = (Category)Enum.Parse(typeof(Category), category);
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            IsActive = isActive;
        }

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

        public int RecipeId { get => _recipeId; private set
            {
                if (value <= 0)
                {
                    var ex = new DomainModelException("Recipe-SetRecipeId-SmallerThanOne");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RecipeId)));
                    ex.Error = new Error("recipeId is smaller than 1");
                    ex.Error.Values.Add(new PropertyInfo("RecipeId", value));
                    throw ex;
                }
                RecipeId = value;
            }
        }
        public string Name { get => _name; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Recipe-SetName-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Name)));
                    ex.Error = new Error("name is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("Name", value));
                    throw ex;
                }
                Name = value;
            }
        }
        public Category Category { get => _category; private set
            {
                if (Enum.IsDefined(value))
                {
                    var ex = new DomainModelException("Recipe-SetCategory-IsDefined");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Category)));
                    ex.Error = new Error("category is not a valid category");
                    ex.Error.Values.Add(new PropertyInfo("Category", value));
                    throw ex;
                }
                Category = value;
            }
        }
        public string ImgUrl { get => _imgUrl; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Recipe-SetImgUrl-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ImgUrl)));
                    ex.Error = new Error("imgUrl is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("ImgUrl", value));
                    throw ex;
                }
                ImgUrl = value;
            }
        }
        public string VideoUrl { get => _videoUrl; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Recipe-SetVideoUrl-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(VideoUrl)));
                    ex.Error = new Error("videoUrl is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("VideoUrl", value));
                    throw ex;
                }
                VideoUrl = value;
            }
        }
        public bool IsActive { get => _isActive; private set
            {
                if (value == null)
                {
                    var ex = new DomainModelException("Recipe-SetIsActive-Null");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(IsActive)));
                    ex.Error = new Error("ksActive is null ");
                    ex.Error.Values.Add(new PropertyInfo("IsActive", value));
                    throw ex;
                }
                IsActive = value;
            }
        }
        public List<Timing> Timings { get => _timings; set { _timings = value; } }


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


        public override string? ToString()
        {
            return "Recipe : " + Name + $"\nimg url : {ImgUrl}";
        }
    }
}
