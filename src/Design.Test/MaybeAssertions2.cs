using System;

namespace CleanCode.Naming
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using FluentAssertions.Primitives;
    using Xunit.Sdk;

    public class MaybeAssertions2<T> : ReferenceTypeAssertions<Maybe2<T>, MaybeAssertions2<T>>
    {
        public MaybeAssertions2(Maybe2<T> instance)
            : base(instance)
        {
        }

        protected override string Identifier => "maybe";

        /// <summary>
        /// Do NOT remove. VS / R# might show that this methods is unused. This is not true, it is used via <see cref="MaybeExtensions"/>.
        /// </summary>
        public AndConstraint<MaybeAssertions2<T>> BeEquivalentTo(Maybe2<T> otherMaybe, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject.GetType() == otherMaybe.GetType())
                .FailWith("Expected both to be none or some, but they differ.")
                .Then
                .ForCondition(AreValuesEquivalentIfSome(this.Subject, otherMaybe))
                .FailWith("Expected both values to be equal, but they differ.");

            return new AndConstraint<MaybeAssertions2<T>>(this);
        }

        public AndConstraint<MaybeAssertions2<T>> BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject is Maybe2<T>.Nothing<T>)
                .FailWith($"Expected subject to be None but was Some.");

            return new AndConstraint<MaybeAssertions2<T>>(this);
        }

        public AndConstraint<MaybeAssertions2<T>> BeSome(T other, string because = "", params object[] becauseArgs)
        {
            bool areEquivalent;
            var exceptionText = string.Empty;
            try
            {
                switch (this.Subject)
                {
                    case Maybe2<T>.Just<T> just:
                        just
                            .Value
                            .Should()
                            .BeEquivalentTo(other);
                        areEquivalent = true;
                        break;
                    case Maybe2<T>.Nothing<T> nothing:
                        areEquivalent = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Subject));
                }

            }
            catch (XunitException ex)
            {
                areEquivalent = false;
                exceptionText = ex.ToString();
            }

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(this.Subject is Maybe2<T>.Just<T>)
                .FailWith($"Expected subject to be Some but was None.")
                .Then
                .ForCondition(AreBothSubjectsOfSameType(other))
                .FailWith($"Expected subject and other to be of the same type. Subject: '{((Maybe2<T>.Just<T>)this.Subject).Value.GetType()}', other: '{other.GetType()}'")
                .Then
                .ForCondition(areEquivalent)
                .FailWith(exceptionText);

            return new AndConstraint<MaybeAssertions2<T>>(this);
        }

        private bool AreBothSubjectsOfSameType(T other) =>
            this.Subject switch
            {
                Maybe2<T>.Just<T> just => just.Value.GetType() == other.GetType(),
                Maybe2<T>.Nothing<T> => false,
                _ => throw new ArgumentOutOfRangeException(nameof(Subject))
            };

        private static bool AreValuesEquivalentIfSome(Maybe2<T> subject, Maybe2<T> otherMaybe)
        {
            return (subject, otherMaybe) switch
            {
                (Maybe2<T>.Just<T> a, Maybe2<T>.Just<T> b) => AreValuesEquivalent(a.Value, b.Value),
                (Maybe2<T>.Nothing<T>, Maybe2<T>.Nothing<T>) => true,
                _ => false
            };
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
