namespace CleanCode.Academy.CleanCode.Academy
{
    using FluentAssertions;
    using Xunit;

    public class SampleTest
    {
        [Fact]
        public void OneShouldBeOne()
        {
            1.Should().Be(1);
        }
    }
}
