namespace CG.API.Model.Output
{
    public class BrandProductRESToutputDTO
    {
        public BrandProductRESToutputDTO(int brandId, string name, string description, decimal price, string imgUrl)
        {
            BrandId = brandId;
            Name = name;
            Description = description;
            Price = price;
            ImgUrl = imgUrl;
        }

        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
