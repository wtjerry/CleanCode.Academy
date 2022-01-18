// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidExercise
{
    using FluentAssertions;

    using Xunit;

    /// <summary>
    /// Verifies the functionality of some classes within the solid example.
    /// However, if you apply a redesign in the source folder you may apply some changes
    /// in this class as well.
    /// </summary>
    public class SolidTest
    {
        [Fact]
        public void ReturnsAllKnownItems()
        {
            // Arrange
            var testee = new ItemCollection();

            // Act
            testee.Initialize();
            var result = testee.GetAllItems();

            // Assert
            result.Should().HaveCountGreaterThan(5);
        }
    }
}
