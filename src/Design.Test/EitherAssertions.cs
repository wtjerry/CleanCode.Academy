namespace CleanCode.Naming
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using FluentAssertions.Primitives;
    using Xunit.Sdk;

    public class EitherAssertions<TLeft, TRight> : ReferenceTypeAssertions<Either<TLeft, TRight>, EitherAssertions<TLeft, TRight>>
        where TLeft : class
        where TRight : class
    {
        public EitherAssertions(Either<TLeft, TRight> instance)
            : base(instance)
        {
        }

        protected override string Identifier => "either";

        /// <summary>
        /// Do NOT remove. VS / R# might show that this methods is unused. This is not true, it is used via <see cref="EitherExtensions"/>.
        /// </summary>
        public AndConstraint<EitherAssertions<TLeft, TRight>> BeEquivalentTo(Either<TLeft, TRight> otherEither, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject.IsLeft == otherEither.IsLeft)
                .FailWith("Expected both to be left or right, but they differ.")
                .Then
                .ForCondition(AreValuesEquivalent(this.Subject, otherEither))
                .FailWith("Expected both values to be equal, but they differ.");

            return new AndConstraint<EitherAssertions<TLeft, TRight>>(this);
        }

        public AndConstraint<EitherAssertions<TLeft, TRight>> BeLeft(TLeft otherLeft, string because = "", params object[] becauseArgs)
        {
            var failWith = Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject.IsLeft)
                .FailWith($"Expected subject to be Left but was Right.");
            failWith
                .Then
                .ForCondition(AreValuesEquivalent(this.Subject.ValueLeft, otherLeft))
                .FailWith($"Expected Value to be {this.Subject.ValueLeft} but was {otherLeft}.");

            return new AndConstraint<EitherAssertions<TLeft, TRight>>(this);
        }

        public AndConstraint<EitherAssertions<TLeft, TRight>> BeRight(TRight other, string because = "", params object[] becauseArgs)
        {
            var failWith = Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!this.Subject.IsLeft)
                .FailWith($"Expected subject to be Right but was Left.");
            failWith
                .Then
                .ForCondition(AreValuesEquivalent(this.Subject.ValueRight, other))
                .FailWith($"Expected Value to be {this.Subject.ValueRight} but was {other}.");

            return new AndConstraint<EitherAssertions<TLeft, TRight>>(this);
        }

        private static bool AreValuesEquivalent(Either<TLeft, TRight> subject, Either<TLeft, TRight> otherEither)
        {
            return subject.IsLeft
                ? AreValuesEquivalent(
                    subject.ValueLeft,
                    otherEither.ValueLeft)
                : AreValuesEquivalent(
                    subject.ValueRight,
                    otherEither.ValueRight);
        }

        private static bool AreValuesEquivalent<T>(T subject, T other)
        {
            try
            {
                subject
                    .Should()
                    .BeEquivalentTo(other);
            }
            catch (XunitException)
            {
                return false;
            }

            return true;
        }
    }
}
