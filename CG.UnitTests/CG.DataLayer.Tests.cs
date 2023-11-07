using Xunit;
using CG.Persistence.Model;

namespace CG.Persistence.Model.Tests
{
    public class DataLayerTests
    {
        [Fact]
        public void Brand_Constructors_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "BrandName";
            decimal price = 10.99m;
            string description = "BrandDescription";
            string imgUrl = "brand_image_url";

            // Act
            var brand = new BrandEntity(name, price, description, imgUrl);

            // Assert
            Assert.Equal(name, brand.Name);
            Assert.Equal(price, brand.Price);
            Assert.Equal(description, brand.Description);
            Assert.Equal(imgUrl, brand.ImgUrl);
        }

        [Fact]
        public void Product_Constructors_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "ProductName";
            string category = "ProductCategory";
            string imgUrl = "product_image_url";

            // Act
            var product = new ProductEntity(name, category, imgUrl);

            // Assert
            Assert.Equal(name, product.Name);
            Assert.Equal(category, product.Category);
            Assert.Equal(imgUrl, product.ImgUrl);
        }

        [Fact]
        public void Recipe_Constructors_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "RecipeName";
            string category = "RecipeCategory";
            bool active = true;
            string imgUrl = "recipe_image_url";
            string videoUrl = "recipe_video_url";

            // Act
            var recipe = new RecipeEntity(name, category, active, imgUrl, videoUrl);

            // Assert
            Assert.Equal(name, recipe.Name);
            Assert.Equal(category, recipe.Category);
            Assert.Equal(active, recipe.Active);
            Assert.Equal(imgUrl, recipe.ImgUrl);
            Assert.Equal(videoUrl, recipe.VideoUrl);
        }
        //Classname Timing veranderen naar TimingEntity + TimeSpan veranderd naar int
        //[Fact]
        //public void Timing_Constructors_SetsPropertiesCorrectly()
        //{
        //    // Arrange
        //    var startTime = TimeSpan.FromHours(10);
        //    var endTime = TimeSpan.FromHours(11);

        //    // Act
        //    var timing = new Timing(startTime, endTime);

        //    // Assert
        //    Assert.Equal(startTime, timing.StartTijd);
        //    Assert.Equal(endTime, timing.EndTijd);
        //    Assert.Null(timing.Product);
        //}
        //[Fact]
        //public void Timing_AssignProduct_SetsProductCorrectly()
        //{
        //    // Arrange
        //    var startTime = TimeSpan.FromHours(10);
        //    var endTime = TimeSpan.FromHours(11);
        //    var product = new ProductEntity("TestProduct", "TestCategory", "test_product_image_url");
        //    var timing = new Timing(startTime, endTime);

        //    // Act
        //    timing.Product = product; // Assign the product to the Timing object

        //    // Assert
        //    Assert.NotNull(timing.Product);
        //    Assert.Equal(product, timing.Product);
        //}

        //[Fact]
        //public void Timing_AssignProduct_ClearsPreviousProduct()
        //{
        //    // Arrange
        //    var startTime = TimeSpan.FromHours(10);
        //    var endTime = TimeSpan.FromHours(11);
        //    var initialProduct = new ProductEntity("InitialProduct", "InitialCategory", "initial_product_image_url");
        //    var newProduct = new ProductEntity("NewProduct", "NewCategory", "new_product_image_url");
        //    var timing = new Timing(startTime, endTime);

        //    // Act
        //    timing.Product = initialProduct; // Assign the initial product
        //    timing.Product = newProduct;     // Assign a new product

        //    // Assert
        //    Assert.NotNull(timing.Product);
        //    Assert.Equal(newProduct, timing.Product);
        //}
    }
}
