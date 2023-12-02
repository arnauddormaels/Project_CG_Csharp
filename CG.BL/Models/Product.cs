using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.BL.Models
{
    public class Product
    {
        private int _productId;
        private string _productName;
        private string _imgUrl;
        private string _category;
        private BrandProduct _brandProduct;

        public Product(string productName, string imgUrl, BrandProduct brandProduct)
        {
            ProductName = productName;
            ImgUrl = imgUrl;
            BrandProduct = brandProduct;
        }

        public Product(int productId, string productName, string imgUrl, BrandProduct brandProduct) 
        {
            ProductId = productId;
            ProductName = productName;
            ImgUrl = imgUrl;
            BrandProduct = brandProduct;
        }

        public string Category { get => _category; private set => _category = value; }
        public string ProductName { get => _productName; private set => _productName = value; }
        public int ProductId { get => _productId; set => _productId = value; }
        public string ImgUrl { get => _imgUrl; set => _imgUrl = value; }
        public BrandProduct BrandProduct { get => _brandProduct; set => _brandProduct = value; }

        public override string ToString()
        {
            return $"{ProductName}|{ImgUrl}|{BrandProduct.ToString()}";
        }
    }
}
