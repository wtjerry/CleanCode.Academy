namespace Examples
{
    using FluentAssertions;
    using Xunit;

    public static class FibonacciInSequence
    {
        public static int ValueOf(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n <= 2)
            {
                return 1;
            }

            int a = 0, b = 1, c = 0;
            for (int i = 1; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }
    }

    public static class FibonacciWithRecursion
    {
        public static int ValueOf(int n)
        {
            return Recursion(n);
        }

        private static int Recursion(int i)
        {
            if (i < 2)
            {
                return i;
            }

            return Recursion(i - 1) + Recursion(i - 2);
        }
    }

    public class FibonacciFacts
    {
        [Fact]
        public void CalculatesFibonacciSequence()
        {
            FibonacciInSequence.ValueOf(0).Should().Be(0);
            FibonacciInSequence.ValueOf(1).Should().Be(1);
            FibonacciInSequence.ValueOf(2).Should().Be(1);
            FibonacciInSequence.ValueOf(3).Should().Be(2);
            FibonacciInSequence.ValueOf(4).Should().Be(3);
            FibonacciInSequence.ValueOf(5).Should().Be(5);
            FibonacciInSequence.ValueOf(6).Should().Be(8);

            FibonacciInSequence.ValueOf(10).Should().Be(55);
        }

        [Fact]
        public void CalculatesFibonacciUsingRecursion()
        {
            FibonacciWithRecursion.ValueOf(0).Should().Be(0);
            FibonacciWithRecursion.ValueOf(1).Should().Be(1);
            FibonacciWithRecursion.ValueOf(2).Should().Be(1);
            FibonacciWithRecursion.ValueOf(3).Should().Be(2);
            FibonacciWithRecursion.ValueOf(4).Should().Be(3);
            FibonacciWithRecursion.ValueOf(5).Should().Be(5);
            FibonacciWithRecursion.ValueOf(6).Should().Be(8);

            FibonacciWithRecursion.ValueOf(10).Should().Be(55);
        }
    }
}
