using CG.BL.Models;

namespace CG.API.Model.Output
{
    public class RecipeDtoRESToutputDTO
    {
        public RecipeDtoRESToutputDTO(int recipeId, string name, string category, string imgUrl, string videoUrl, bool isActive)
        {
            RecipeId = recipeId;
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            IsActive = isActive;
        }

        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
