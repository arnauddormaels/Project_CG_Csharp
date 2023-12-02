namespace CG.API.Model.Input
{
    public class ProductRESTinputDTO
    {
        public ProductRESTinputDTO(string name,/* string category,*/ string imgUrl)
        {
            Name = name;
           /* Category = category;*/
            ImgUrl = imgUrl;
        }

        public string Name { get; set; }
       /* public string Category { get; set; }*/
        public string ImgUrl { get; set; }
        public BrandProductRESTinputDTO BrandProduct { get; set; }
    }
}
