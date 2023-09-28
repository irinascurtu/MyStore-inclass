using FluentAssertions;
using MyStore.Tests.Unit.Classes;

namespace MyStore.Tests.Unit
{
    public class CalculatorTests
    {
        private readonly Calculator subjectUnderTest;

        public CalculatorTests()
        {
            subjectUnderTest = new Calculator();
        }

        [Fact]
        public void SumShouldReturn_CorectNumber()
        {
            // Arrange
            var x = 1;
            var y = 2;
            var expectedResult = 3;
            //Act
            var actualResult = subjectUnderTest.Sum(x, y);

            //Assert
            expectedResult.Should().Be(actualResult);

            ////v2
            //var actualResult = subjectUnderTest.Sum(1, 2);
            //actualResult.Should().Be(3);
        }

        [Fact]
        public void Multiply_Should_Return_Correct()
        {
            // Arrange
            var x = 1;
            var factor = 2;
            var expectedResult = 2;
            //Act
            var actualResult = subjectUnderTest.Multiply(x, factor);

            //Assert
            expectedResult.Should().Be(actualResult);

        }
    }
}