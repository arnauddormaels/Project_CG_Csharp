using CG.API.Model.Output;
using Xunit;

namespace CG.PresentationLayer.Tests
{
    public class RecipeRESToutputDTOTests
    {
        [Fact]
        public void RecipeRESToutputDTO_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int recipeId = 1;
            string name = "Recipe Name";
            string imgUrl = "recipe_image_url";
            string videoUrl = "recipe_video_url";
            string category = "recipe category";
            bool isActive = true;

            // Act
            var dto = new RecipeRESToutputDTO(recipeId, name, category,imgUrl, videoUrl, isActive);

            // Assert
            Assert.Equal(recipeId, dto.RecipeId);
            Assert.Equal(name, dto.Name);
            Assert.Equal(imgUrl, dto.ImgUrl);
            Assert.Equal(videoUrl, dto.VideoUrl);
            Assert.True(dto.IsActive);
        }

        [Fact]
        public void RecipeRESToutputDTO_Properties_CanBeSetIndependently()
        {
            // Arrange
            var dto = new RecipeRESToutputDTO(1, "Recipe Name", "recipe category", "recipe_image_url", "recipe_video_url", true);

            // Act
            dto.Name = "New Recipe Name";
            dto.ImgUrl = "new_recipe_image_url";
            dto.VideoUrl = "new_recipe_video_url";
            dto.IsActive = false;

            // Assert
            Assert.Equal("New Recipe Name", dto.Name);
            Assert.Equal("new_recipe_image_url", dto.ImgUrl);
            Assert.Equal("new_recipe_video_url", dto.VideoUrl);
            Assert.False(dto.IsActive);
        }

        [Fact]
        public void RecipeRESToutputDTO_Equality_Test()
        {
            // Arrange
            var dto1 = new RecipeRESToutputDTO(1, "Recipe Name", "recipe category", "recipe_image_url", "recipe_video_url", true);
            var dto2 = new RecipeRESToutputDTO(1, "Recipe Name", "recipe category", "recipe_image_url", "recipe_video_url", true);

            // Act

            // Assert
            Assert.Equal(dto1.RecipeId, dto2.RecipeId);
            Assert.Equal(dto1.Name, dto2.Name);
            Assert.Equal(dto1.ImgUrl, dto2.ImgUrl);
            Assert.Equal(dto1.VideoUrl, dto2.VideoUrl);
            Assert.Equal(dto1.IsActive, dto2.IsActive);
        }



        [Fact]
        public void RecipeRESToutputDTO_Inequality_Test()
        {
            // Arrange
            var dto1 = new RecipeRESToutputDTO(1, "Recipe Name", "recipe category", "recipe_image_url", "recipe_video_url", true);
            var dto2 = new RecipeRESToutputDTO(2, "Other Recipe", "recipe category", "other_image_url", "other_video_url", false);

            // Assert
            Assert.NotEqual(dto1, dto2);
            Assert.False(dto1.Equals(dto2));
        }

        [Fact]
        public void RecipeRESToutputDTO_NullEquality_Test()
        {
            // Arrange
            RecipeRESToutputDTO dto1 = null;
            RecipeRESToutputDTO dto2 = null;

            // Assert
            Assert.Equal(dto1, dto2);
        }
    }
}
