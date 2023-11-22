namespace CG.API.Model.Output
{
    public class ProductRESToutputDTO
    {
        //brandproductoutput moet nog toegepast worden! die heeft de timing nodig!
        public ProductRESToutputDTO(int productId, string name, string category, string imgUrl)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public int BrandId { get; set; }
    }
}
