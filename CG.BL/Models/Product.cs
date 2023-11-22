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
        public BrandProduct BrandProduct { get; set; }


        public Product(string productName,string category ,string imgUrl, BrandProduct brandProduct)
        {
            ProductName = productName;
            Category = category;
            ImgUrl = imgUrl;
            BrandProduct = brandProduct;
        }

        public Product(int productId, string productName, string category, string imgUrl,BrandProduct brandProduct) : this(productName,category, imgUrl,brandProduct)
        {
            ProductId = productId;
        }
        //test dit mag aangepast worden als het nodig is! ik kon niet de producten weergeven wanneer brandproduct in de constructor zit
        public Product(int productId, string productName, string category,  string imgUrl)
        {
            Category = category;
            ProductName = productName;
            ProductId = productId;
            ImgUrl = imgUrl;
        }
        public Product(int productId)
        {
            ProductId = productId;
        }

        public string Category { get => _category; private set => _category = value; }
        public string ProductName { get => _productName; private set => _productName = value; }
        public int ProductId { get => _productId; private set => _productId = value; }
        public string ImgUrl { get => _imgUrl; set => _imgUrl = value; }

        public override string ToString()
        {
            return $"{ProductName}|{ImgUrl}|{BrandProduct.ToString()}";
        }
    }
}
