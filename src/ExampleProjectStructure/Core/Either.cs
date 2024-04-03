namespace CleanCode.Academy.Core;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public readonly struct Either<TLeft, TRight> : IEquatable<Either<TLeft, TRight>>
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
    /// Der im Either hinterlegte Wert vom Typ TLeft.
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
    /// Der im Either hinterlegte Wert vom Typ TRight.
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
    /// Wrapped ein Objekt vom Typ TLeft in ein <see cref="Either{TLeft,TRight}"/>.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Design",
        "CA1000:DoNotDeclareStaticMembersOnGenericTypes",
        Justification = "Either is a struct with a private constructor.")]
    public static Either<TLeft, TRight> Left(TLeft nullableValue)
    {
        ArgumentNullException.ThrowIfNull(nullableValue);

        return new Either<TLeft, TRight>(
            [nullableValue],
            null);
    }

    /// <summary>
    /// Legt ein neues Either vom Typ TRight an mit dem Wert <paramref name="value"/>.
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
        ArgumentNullException.ThrowIfNull(value);

        return new Either<TLeft, TRight>(
            null,
            [value]);
    }

    public TRight GetRightOrThrow(Func<TLeft, Exception> leftToException)
    {
        return this.IsLeft
            ? throw leftToException(this.ValueLeft)
            : this.ValueRight;
    }

    public Either<TLeft, TDestination> Map<TDestination>(
        Func<TRight, TDestination> mapper)
        where TDestination : class
    {
        return this.IsLeft
            ? Either<TLeft, TDestination>.Left(this.ValueLeft)
            : Either<TLeft, TDestination>.Right(mapper(this.ValueRight));
    }

    public override bool Equals(object obj)
    {
        return obj is Either<TLeft, TRight> other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            this.valuesLeft,
            this.valuesRight);
    }

    public static bool operator ==(Either<TLeft, TRight> left, Either<TLeft, TRight> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Either<TLeft, TRight> left, Either<TLeft, TRight> right)
    {
        return !(left == right);
    }

    public bool Equals(Either<TLeft, TRight> other)
    {
        return Equals(
                   this.valuesLeft,
                   other.valuesLeft)
               && Equals(
                   this.valuesRight,
                   other.valuesRight);
    }
}
