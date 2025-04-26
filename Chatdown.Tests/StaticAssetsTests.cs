using System.IO;
using Xunit;

namespace Chatdown.Tests
{
    public class StaticAssetsTests
    {
        [Fact]
        public void AllStaticAssetsAreInPlace()
        {
            // Arrange
            string[] requiredAssets = new[]
            {
                "wwwroot/app.css",
                "wwwroot/index.html",
                "wwwroot/favicon.png",
                "wwwroot/bootstrap/"
            };

            string projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Chatdown.Web");

            // Act & Assert
            foreach (var asset in requiredAssets)
            {
                string assetPath = Path.Combine(projectRoot, asset);
                Assert.True(File.Exists(asset) || Directory.Exists(assetPath), $"Missing static asset: {assetPath}");
            }
        }
    }
}