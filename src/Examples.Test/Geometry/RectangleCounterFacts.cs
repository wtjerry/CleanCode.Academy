namespace CleanCode.Academy.Examples.Test.Geometry
{
    using bbv.Examples.Geometry;
    using FluentAssertions;
    using Xunit;

    public class RectangleCounterFacts
    {
        private ICountRectangles testee;

        public RectangleCounterFacts()
        {
            this.testee = new StructuralRectangleCounter();
        }

        [Fact]
        public void ReturnsZeroIfNoRectanglesCouldBeFound()
        {
            var result = this.testee.CountIn(new int[0, 0]);

            result.Should().Be(0, "no rectangles could be found");
        }

        /// <example>
        ///  X (0,5)    X (5,5)
        ///
        ///  X (0,0)    X (5,0)
        /// </example>>
        [Fact]
        public void FindsASingleRectangle()
        {
            var pointSequence = new[,] { { 0, 0 }, { 0, 5 }, { 5, 5 }, { 5, 0 } };

            var result = this.testee.CountIn(pointSequence);

            result.Should().Be(1);
        }

        /// <example>
        ///  X (-2, 3)    X (2, 3)     X (7, 3)
        ///
        ///  X (-2,-2)                 X (7,-2)
        ///
        ///               X (2,-8)     X (7,-8)
        /// </example>>
        [Fact]
        public void FindsTwoRectangles()
        {
            var pointSequence = new[,]
            {
                { -2, 3 }, { 2, 3 }, { 7, 3 },
                { -2, -2 }, { 7, -2 },
                { 2, -8 }, { 7, -8 }
            };

            var result = this.testee.CountIn(pointSequence);

            result.Should().Be(2);
        }

        /// <example>
        ///  X (-2, 3)    X (2, 3)     X (7, 3)
        ///
        ///  X (-2,-2)    X (2,-2)     X (7,-2)
        ///
        ///               X (2,-8)     X (7,-8)
        /// </example>>
        [Fact]
        public void FindsFiveRectangles()
        {
            var pointSequence = new[,]
            {
                { -2, 3 }, { 2, 3 }, { 7, 3 },
                { -2, -2 }, { 2, -2}, { 7, -2 },
                { 2, -8 }, { 7, -8 }
            };

            var result = this.testee.CountIn(pointSequence);

            result.Should().Be(5);
        }
    }
}
