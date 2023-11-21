namespace CG.API.Model.Input
{
    public class RecipeRESTinputDTO
    {
        public RecipeRESTinputDTO(int recipeId, string name, string category, string imgUrl, string videoUrl, bool isActive)
        {
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
            IsActive = isActive;
        }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
