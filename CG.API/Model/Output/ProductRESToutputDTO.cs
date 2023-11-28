namespace CG.API.Model.Output
{
    public class ProductRESToutputDTO
    {
        //brandproductoutput moet nog toegepast worden! die heeft de timing nodig!
        public ProductRESToutputDTO(int productId, string name, string category, string imgUrl, BrandProductRESToutputDTO brandProduct)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            ImgUrl = imgUrl;
            BrandProduct = brandProduct;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        public BrandProductRESToutputDTO BrandProduct {  get; set; }
    }
}
