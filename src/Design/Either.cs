namespace CleanCode.Naming;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public readonly struct Either<TLeft, TRight>
        where TLeft : class
        where TRight : class
    {
        private readonly IEnumerable<TLeft> valuesLeft;
        private readonly IEnumerable<TRight> valuesRight;

        private Either(IEnumerable<TLeft> valuesLeft, IEnumerable<TRight> valuesRight)
        {
            this.valuesLeft = valuesLeft;
            this.valuesRight = valuesRight;
        }

        /// <summary>
        /// Gibt an, ob dem Either ein Wert hinterlegt wurde oder nicht.
        /// </summary>
        public bool IsLeft => this.valuesLeft != null && this.valuesLeft.Any();

        /// <summary>
        /// Der hinterlegte Wert im Either. Ist kein Wert hinterlegt, wird eine <see cref="InvalidOperationException"/>
        /// geworfen.
        /// </summary>
        /// <returns>
        /// Der im Either hinterlegte Wert vom Typ <see cref="TLeft"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Wird geworfen, falls dem Either kein Wert hinterlegt wurde.
        /// </exception>
        public TLeft ValueLeft
        {
            get
            {
                if (!this.IsLeft)
                {
                    throw new InvalidOperationException("Either does not have a value");
                }

                return this.valuesLeft.Single();
            }
        }

        /// <summary>
        /// Der hinterlegte Wert im Either. Ist kein Wert hinterlegt, wird eine <see cref="InvalidOperationException"/>
        /// geworfen.
        /// </summary>
        /// <returns>
        /// Der im Either hinterlegte Wert vom Typ <see cref="TLeft"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Wird geworfen, falls dem Either kein Wert hinterlegt wurde.
        /// </exception>
        public TRight ValueRight
        {
            get
            {
                if (this.IsLeft)
                {
                    throw new InvalidOperationException("Either does not have a value");
                }

                return this.valuesRight.Single();
            }
        }

        /// <summary>
        /// Wrapped ein Objekt vom Typ <see cref="TLeft"/> in ein <see cref="Either{TLeft,TRight}"/>.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1000:DoNotDeclareStaticMembersOnGenericTypes",
            Justification = "Either is a struct with a private constructor.")]
        public static Either<TLeft, TRight> Left(TLeft nullableValue)
        {
            if (nullableValue == null)
            {
                throw new ArgumentNullException(nameof(nullableValue));
            }

            return new Either<TLeft, TRight>(
                new[] { nullableValue },
                null);
        }

        /// <summary>
        /// Legt ein neues Either vom Typ <see cref="TRight"/> an mit dem Wert <paramref name="value"/>.
        /// </summary>
        /// <param name="value">Wert, welcher mit dem Either gewrappt werden soll.</param>
        /// <exception cref="ArgumentNullException">
        /// Wird geworfen, falls <paramref name="value"/> <c>null</c> ist.
        /// </exception>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1000:DoNotDeclareStaticMembersOnGenericTypes",
            Justification = "Either is a struct with a private constructor.")]
        public static Either<TLeft, TRight> Right(TRight value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Either<TLeft, TRight>(
                null,
                new[] { value });
        }

        public TRight GetRightOrThrow(Func<TLeft, Exception> leftToException)
        {
            if (this.IsLeft)
            {
                throw leftToException(this.ValueLeft);
            }

            return this.ValueRight;
        }

        public Either<TLeft, TDestination> Map<TDestination>(
            Func<TRight, TDestination> mapper)
            where TDestination : class
        {
            if (this.IsLeft)
            {
                return Either<TLeft, TDestination>.Left(this.ValueLeft);
            }

            return Either<TLeft, TDestination>.Right(mapper(this.ValueRight));
        }
    }

