using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Application.Models
{
    public class Product
    {
        private string _productName; 
        private DateTime _startTime;
        private DateTime _endTime;
        private int _productId;
        private int _brandId;
        private int recipeId;

        public Product(string productName, DateTime startTime, DateTime endTime, int productId, int brandId)
        {
            ProductName = productName;
            StartTime = startTime;
            EndTime = endTime;
            ProductId = productId;
            BrandId = brandId;
        }

        public Product(string productName, DateTime startTime, DateTime endTime, int productId, int brandId, int recipeId) : this(productName, startTime, endTime, productId, brandId)
        {
            this.recipeId = recipeId;
        }

        public DateTime StartTime { get => _startTime; private set => _startTime = value; }
        public string ProductName { get => _productName; private set => _productName = value; }
        public DateTime EndTime { get => _endTime; private set => _endTime = value; }
        public int ProductId { get => _productId; private set => _productId = value; }
        public int BrandId { get => _brandId; private set => _brandId = value; }
        public int RecipeId { get => recipeId; private set => recipeId = value; }

        public string ToString()
        {
            return $"product : {ProductName} \n" +
                $"startTime : {StartTime} \n" +
                $"endTime : {EndTime} \n" +
                $"recipeId : {RecipeId} \n" +
                $"pId : {ProductId} \n" +
                $"brandId : {BrandId}";
        }
    }
}
