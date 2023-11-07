using System.Xml.Linq;

namespace CG.API.Model.Output
{
    public class RecipeRESToutputDTO
    {

        public RecipeRESToutputDTO(int recipeId, string name, string imgUrl, string videoUrl, bool isActive)
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
