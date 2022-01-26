namespace CleanCode.Naming
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using FluentAssertions.Primitives;
    using Xunit.Sdk;

    public class MaybeAssertions<T> : ReferenceTypeAssertions<Maybe<T>, MaybeAssertions<T>>
    {
        public MaybeAssertions(Maybe<T> instance)
            : base(instance)
        {
        }

        protected override string Identifier => "maybe";

        /// <summary>
        /// Do NOT remove. VS / R# might show that this methods is unused. This is not true, it is used via <see cref="MaybeExtensions"/>.
        /// </summary>
        public AndConstraint<MaybeAssertions<T>> BeEquivalentTo(Maybe<T> otherMaybe, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject.HasValue == otherMaybe.HasValue)
                .FailWith("Expected both to be none or some, but they differ.")
                .Then
                .ForCondition(AreValuesEquivalentIfSome(this.Subject, otherMaybe))
                .FailWith("Expected both values to be equal, but they differ.");

            return new AndConstraint<MaybeAssertions<T>>(this);
        }

        public AndConstraint<MaybeAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!this.Subject.HasValue)
                .FailWith($"Expected subject to be None but was Some.");

            return new AndConstraint<MaybeAssertions<T>>(this);
        }

        public AndConstraint<MaybeAssertions<T>> BeSome(T other, string because = "", params object[] becauseArgs)
        {
            bool areEquivalent;
            var exceptionText = string.Empty;
            try
            {
                if (this.Subject.HasValue)
                {
                    this.Subject
                        .Value
                        .Should()
                        .BeEquivalentTo(other);
                    areEquivalent = true;
                }
                else
                {
                    areEquivalent = false;
                }
            }
            catch (XunitException ex)
            {
                areEquivalent = false;
                exceptionText = ex.ToString();
            }

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject.HasValue)
                .FailWith($"Expected subject to be Some but was None.")
                .Then
                .ForCondition(this.Subject.HasValue && this.Subject.Value.GetType() == other.GetType())
                .FailWith($"Expected subject and other to be of the same type. Subject: '{this.Subject.Value.GetType()}', other: '{other.GetType()}'")
                .Then
                .ForCondition(areEquivalent)
                .FailWith(exceptionText);

            return new AndConstraint<MaybeAssertions<T>>(this);
        }

        private static bool AreValuesEquivalentIfSome(Maybe<T> subject, Maybe<T> otherMaybe)
        {
            return !subject.HasValue || AreValuesEquivalent(subject.Value, otherMaybe.Value);
        }

        private static bool AreValuesEquivalent(T subject, T other)
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
