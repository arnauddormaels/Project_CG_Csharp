namespace CG.API.Model.Input
{
    public class ProductRESTinputDTO
    {
        public ProductRESTinputDTO(string name, string category, string imgUrl, int brandId)
        {
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
            BrandId = brandId;
        }

        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public int BrandId { get; set; }
    }
}
