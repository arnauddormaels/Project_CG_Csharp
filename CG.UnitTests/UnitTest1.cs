using Xunit;
using CG.Application.Models;
using CG.Application.Exceptions;

namespace CG.UnitTests
{
    public class BrandProductTests
    {
        [Fact]
        public void BrandProduct_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int brandId = 1;
            string name = "Product Name";
            decimal price = 10.99m;
            string description = "Product Description";
            string imgUrl = "image_url";

            // Act
            var product = new BrandProduct(brandId, name, price, description, imgUrl);

            // Assert
            Assert.Equal(brandId, product.BrandId);
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(description, product.Description);
            Assert.Equal(imgUrl, product.ImgUrl);
        }

        [Fact]
        public void BrandProduct_ToString_ReturnsExpectedString()
        {
            // Arrange
            int brandId = 1;
            string name = "Product Name";
            decimal price = 10.99m;
            string description = "Product Description";
            string imgUrl = "image_url";
            var product = new BrandProduct(brandId, name, price, description, imgUrl);

            // Act
            string result = product.ToString();

            // Assert
            string expected = $"{name}|{price}|{imgUrl}|{description}";
            Assert.Equal(expected, result);
        }
    }

    public class RecipeTests
    {
        [Fact]
        public void Recipe_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int recipeId = 1;
            string name = "Recipe Name";
            string imgUrl = "recipe_image_url";
            string videoUrl = "recipe_video_url";

            // Act
            var recipe = new Recipe(recipeId, name, imgUrl, videoUrl);

            // Assert
            Assert.Equal(recipeId, recipe.RecipeId);
            Assert.Equal(name, recipe.Name);
            Assert.Equal(imgUrl, recipe.ImgUrl);
            Assert.Equal(videoUrl, recipe.VideoUrl);
        }

        [Fact]
        public void Recipe_GetTiming_ThrowsExceptionWhenTimingNotFound()
        {
            // Arrange
            var recipe = new Recipe("Recipe Name", "recipe_image_url", "recipe_video_url");

            // Act & Assert
            Assert.Throws<RecipeException>(() => recipe.GetTiming(1));
        }

        [Fact]
        public void Recipe_AddTiming_AddsTimingToList()
        {
            // Arrange
            var recipe = new Recipe("Recipe Name", "recipe_image_url", "recipe_video_url");
            var timing = new Timing(1, TimeSpan.FromHours(0), TimeSpan.FromHours(1), null);

            // Act
            recipe.AddTiming(timing);

            // Assert
            Assert.Single(recipe.GetTimings());
            Assert.Equal(timing, recipe.GetTimings()[0]);
        }

        [Fact]
        public void Recipe_AddTiming_ThrowsExceptionWhenTimingIsNull()
        {
            // Arrange
            var recipe = new Recipe("Recipe Name", "recipe_image_url", "recipe_video_url");

            // Act & Assert
            Assert.Throws<RecipeException>(() => recipe.AddTiming(null));
        }

        [Fact]
        public void Recipe_ToString_ReturnsExpectedString()
        {
            // Arrange
            string name = "Recipe Name";
            string imgUrl = "recipe_image_url";
            var recipe = new Recipe(name, imgUrl, "recipe_video_url");

            // Act
            string result = recipe.ToString();

            // Assert
            string expected = $"Recipe : {name}\nimg url : {imgUrl}";
            Assert.Equal(expected, result);
        }
    }

    public class TimingTests
    {
        [Fact]
        public void Timing_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int timingId = 1;
            var startTime = TimeSpan.FromHours(10);
            var endTime = TimeSpan.FromHours(11);
            var product = new Product("Product Name", null, "product_image_url");

            // Act
            var timing = new Timing(timingId, startTime, endTime, product);

            // Assert
            Assert.Equal(timingId, timing.TimingId);
            Assert.Equal(startTime, timing.StartTime);
            Assert.Equal(endTime, timing.EndTime);
            Assert.Equal(product, timing.Product);
        }

        [Fact]
        public void Timing_Constructor_WithoutTimingId_SetsPropertiesCorrectly()
        {
            // Arrange
            var startTime = TimeSpan.FromHours(10);
            var endTime = TimeSpan.FromHours(11);
            var product = new Product("Product Name", null, "product_image_url");

            // Act
            var timing = new Timing(startTime, endTime, product);

            // Assert
            Assert.Equal(default(int), timing.TimingId);
            Assert.Equal(startTime, timing.StartTime);
            Assert.Equal(endTime, timing.EndTime);
            Assert.Equal(product, timing.Product);
        }
        public class ProductTests
        {
            [Fact]
            public void Product_Constructor_SetsPropertiesCorrectly()
            {
                // Arrange
                int productId = 1;
                string productName = "Product Name";
                decimal brandProductPrice = 10.99m;
                string brandProductDescription = "Brand Product Description";
                string brandProductImgUrl = "brand_image_url";
                var brandProduct = new BrandProduct(2, "Brand Product", brandProductPrice, brandProductDescription, brandProductImgUrl);
                string imgUrl = "product_image_url";

                // Act
                var product = new Product(productId, productName, brandProduct, imgUrl);

                // Assert
                Assert.Equal(productId, product.ProductId);
                Assert.Equal(productName, product.ProductName);
                Assert.Equal(imgUrl, product.ImgUrl);
            }

            [Fact]
            public void Product_ToString_ReturnsExpectedString()
            {
                // Arrange
                string productName = "Product Name";
                decimal brandProductPrice = 10.99m;
                string brandProductDescription = "Brand Product Description";
                string brandProductImgUrl = "brand_image_url";
                var brandProduct = new BrandProduct(2, "Brand Product", brandProductPrice, brandProductDescription, brandProductImgUrl);
                string imgUrl = "product_image_url";
                var product = new Product(productName, brandProduct, imgUrl);

                // Act
                string result = product.ToString();

                // Assert
                string expected = $"{productName}|{imgUrl}|{brandProduct.ToString()}";
                Assert.Equal(expected, result);
            }

            [Fact]
            public void Product_SetImgUrl_ChangesImgUrl()
            {
                // Arrange
                string productName = "Product Name";
                string initialImgUrl = "initial_image_url";
                var brandProduct = new BrandProduct(2, "Brand Product", 10.99m, "Brand Product Description", "brand_image_url");
                var product = new Product(productName, brandProduct, initialImgUrl);
                string newImgUrl = "new_image_url";

                // Act
                product.ImgUrl = newImgUrl;

                // Assert
                Assert.Equal(newImgUrl, product.ImgUrl);
            }
        }
    }
}

