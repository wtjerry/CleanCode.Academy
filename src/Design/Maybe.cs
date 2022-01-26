namespace CleanCode.Naming;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

public struct Maybe<T> : IEquatable<Maybe<T>>
{
    private readonly IEnumerable<T> values;

    private Maybe(IEnumerable<T> values)
    {
        this.values = values;
    }

    public bool HasValue => this.values != null && this.values.Any();

    public T Value
    {
        get
        {
            if (!this.HasValue)
            {
                throw new InvalidOperationException("Maybe does not have a value");
            }

            return this.values.Single();
        }
    }

    public static bool operator ==(Maybe<T> left, Maybe<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Maybe<T> left, Maybe<T> right)
    {
        return !left.Equals(right);
    }

    [SuppressMessage(
        "Microsoft.Design",
        "CA1000:DoNotDeclareStaticMembersOnGenericTypes",
        Justification = "Maybe is a struct with a private constructor.")]
    public static Maybe<T> Some(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new Maybe<T>(new[] { value });
    }

    [SuppressMessage(
        "Microsoft.Design",
        "CA1000:DoNotDeclareStaticMembersOnGenericTypes",
        Justification = "Maybe is a struct with a private constructor.")]
    public static Maybe<T> None() => new Maybe<T>(Array.Empty<T>());

    public Maybe<TDestination> Map<TDestination>(Func<T, TDestination> mapper)
    {
        return this.HasValue
            ? Maybe<TDestination>.Some(mapper(this.Value))
            : Maybe<TDestination>.None();
    }

    public T ValueOrThrow(Exception noneException)
    {
        if (this.HasValue)
        {
            return this.Value;
        }

        throw noneException;
    }

    public T ValueOr(T orValue)
    {
        return this.HasValue ? this.Value : orValue;
    }

    public bool Equals(Maybe<T> other)
    {
        var myValue = this.values.FirstOrDefault();
        var otherValue = other.values.FirstOrDefault();

        if (this.HasValue == false && other.HasValue == false)
        {
            return true;
        }

        if (myValue == null || otherValue == null)
        {
            return false;
        }

        return Equals(myValue, otherValue);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return this.HasValue ? this.Value.ToString() : string.Empty;
    }

    public override bool Equals(object obj)
    {
        return obj is Maybe<T> other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.values != null ? this.values.GetHashCode() : 0;
    }
}
