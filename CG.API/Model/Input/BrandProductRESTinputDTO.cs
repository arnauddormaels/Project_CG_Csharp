namespace CG.API.Model.Input
{
    public class BrandProductRESTinputDTO
    {
        public BrandProductRESTinputDTO(string name, decimal price, string description, string imgUrl)
        {
            Name = name;
            Price = price;
            Description = description;
            ImgUrl = imgUrl;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
