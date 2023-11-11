using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DL.Entities
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
        [Column(TypeName = "decimal(18,2)")] //
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
