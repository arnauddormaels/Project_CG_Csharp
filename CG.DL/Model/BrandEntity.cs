using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Model
{
    public class BrandEntity
    {
        public BrandEntity(string name, decimal price, string description, string imgUrl)
        {
            Name = name;
            Price = price;
            Description = description;
            ImgUrl = imgUrl;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
