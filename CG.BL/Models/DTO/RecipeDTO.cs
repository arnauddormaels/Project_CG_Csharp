using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Models.DTO
{
    public class RecipeDTO
    {
        public RecipeDTO(int recipeId, string name, string imgUrl, string videoUrl, bool isActive)
        {
            RecipeId = recipeId;
            Name = name;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            IsActive = isActive;
        }

        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
