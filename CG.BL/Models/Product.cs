using CG.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public int ProductId
        {
            get => _productId; private set
            {
                if (value <= 0)
                {
                    var ex = new DomainModelException("Product-SetProductId-SmallerThanOne");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ProductId)));
                    ex.Error = new Error("productId is smaller than 1");
                    ex.Error.Values.Add(new PropertyInfo("ProductId", value));
                    throw ex;
                }
                ProductId = value;
            }
        }
        public string ProductName { get => _productName; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Product-SetProductName-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ProductName)));
                    ex.Error = new Error("productName null or white space");
                    ex.Error.Values.Add(new PropertyInfo("ProductName", value));
                    throw ex;
                }
                ProductName = value;
            }
        }
        public string Category{ get => _category; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Product-SetCategory-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Category)));
                    ex.Error = new Error("category null or white space");
                    ex.Error.Values.Add(new PropertyInfo("Category", value));
                    throw ex;
                }
                Category = value;
            }
        }
        public string ImgUrl { get => _imgUrl; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("Product-SetImgUrl-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ImgUrl)));
                    ex.Error = new Error("imgUrl is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("ImgUrl", value));
                    throw ex;
                }
                ImgUrl = value;
            }
        }
        public BrandProduct BrandProduct { get => _brandProduct; private set
            {
                if (value == null)
                {
                    var ex = new DomainModelException("Product-SetBrandProduct-Null");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(BrandProduct)));
                    ex.Error = new Error("brandProduct is null ");
                    ex.Error.Values.Add(new PropertyInfo("BrandProduct", value));
                    throw ex;
                }
                BrandProduct = value;
            }
        }

        public override string ToString()
        {
            return $"{ProductName}|{ImgUrl}|{BrandProduct.ToString()}";
        }
    }
}
