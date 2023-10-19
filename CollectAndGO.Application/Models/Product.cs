using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Application.Models
{
    public class Product
    {
        private int _productId;
        private string _productName;
        private string _imgUrl;
        private BrandProduct BrandProduct { get; set; }

        public Product( string productName,BrandProduct brandProduct, string imgUrl)
        {
            ProductName = productName;
            BrandProduct = brandProduct;
            ImgUrl = imgUrl;
        }

        public Product(int productId,string productName, BrandProduct brandProduct,string imgUrl) : this(productName,brandProduct, imgUrl)
        {
            ProductId = productId;
        }

        public string ProductName { get => _productName; private set => _productName = value; }
        public int ProductId { get => _productId; private set => _productId = value; }
        public string ImgUrl { get => _imgUrl; set => _imgUrl = value; }

        public override string ToString()
        {
            return $"{ProductName}|{ImgUrl}|{BrandProduct.ToString()}";
        }
    }
}
