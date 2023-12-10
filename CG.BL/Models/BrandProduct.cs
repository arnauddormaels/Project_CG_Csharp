using CG.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CG.BL.Models
{
    public class BrandProduct
    {
        private int     _brandId;
        private string  _name;
        private decimal _price;
        private string  _description;
        private string  _imgUrl;

        public BrandProduct(string name, decimal price, string description, string imgUrl)
        {
            Name = name;
            Price = price;
            Description = description;
            ImgUrl = imgUrl;
        }

        public BrandProduct(int brandId, string name, decimal price, string description, string imgUrl)
        {
            BrandId = brandId;
            Name = name;
            Price = price;
            Description = description;
            ImgUrl = imgUrl;
        }

        public int BrandId { get => _brandId; private set
            {
                if (value <= 0)
                {
                    var ex = new DomainModelException("BrandProduct-SetBrandId-SmallerThanOne");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(BrandId)));
                    ex.Error = new Error("brandId is smaller than 1");
                    ex.Error.Values.Add(new PropertyInfo("BrandId", value));
                    throw ex;
                }
                _brandId = value;
            }
        }
        public string Name { get => _name; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("BrandProduct-SetName-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Name)));
                    ex.Error = new Error("name is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("Name", value));
                    throw ex;
                }
                _name = value;
            }
        }
        public decimal Price { get => _price; private set
            {
                if (value < 0)
                {
                    var ex = new DomainModelException("BrandProduct-SetPrice-SmallerThanZero");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Price)));
                    ex.Error = new Error("price is smaller than 0");
                    ex.Error.Values.Add(new PropertyInfo("Price", value));
                    throw ex;
                }
                _price = value;
            }
        }
        public string Description { get => _description; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("BrandProduct-SetDescription-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Description)));
                    ex.Error = new Error("description is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("Description", value));
                    throw ex;
                }
                _description = value;
            }
        }
        public string ImgUrl { get => _imgUrl; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var ex = new DomainModelException("BrandProduct-SetImgUrl-NullOrWhiteSpace");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ImgUrl)));
                    ex.Error = new Error("imgUrl is null or white space");
                    ex.Error.Values.Add(new PropertyInfo("ImgUrl", value));
                    throw ex;
                }
                _imgUrl = value;
            }
        }



        public override string ToString()
        {
            return $"{Name}|{Price}|{ImgUrl}|{Description}";
        }
    }
}
