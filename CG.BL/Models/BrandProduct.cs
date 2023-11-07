using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Models
{
    public class BrandProduct
    {
        private int     _brandId;
        private string  _name;
        private decimal _price;
        private string  _description;
        private string  _imgUrl;

        public BrandProduct(int ID, string name, decimal price, string discription, string imgUrl)
        {
            _brandId = ID;
            _name = name;
            _price = price;
            _description = discription;
            _imgUrl = imgUrl;
        }

        public int BrandId { get => _brandId; private set => _brandId = value; }
        public string Name { get => _name; private set => _name = value; }
        public decimal Price { get => _price; private set => _price = value; }
        public string Description { get => _description; private set => _description = value; }
        public string ImgUrl { get => _imgUrl; private set => _imgUrl = value; }

        public override string ToString()
        {
            return $"{Name}|{Price}|{ImgUrl}|{Description}";
        }
    }
}
