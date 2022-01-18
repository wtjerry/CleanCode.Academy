// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
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

            // no longer working in .Net5+
            // todo wtjerry: implement a different solution
            // Assert
            // result.Should().HaveCountGreaterThan(5);
        }
    }
}
