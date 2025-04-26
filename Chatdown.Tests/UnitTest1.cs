using Xunit;

namespace Chatdown.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int a = 5;
            int b = 10;

            // Act
            int result = a + b;

            // Assert
            Assert.Equal(15, result);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(-1, 1, 0)]
        [InlineData(0, 0, 0)]
        public void TestAddition(int a, int b, int expected)
        {
            // Act
            int result = a + b;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
