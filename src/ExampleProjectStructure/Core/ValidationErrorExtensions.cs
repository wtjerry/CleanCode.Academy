namespace CleanCode.Academy.Core;

using System;
using System.Collections.Generic;

public static class MaybeExtensions
{
    public static Either<IReadOnlyCollection<TLeft>, TRight> ToEitherFromErrors<TLeft, TRight>(
        this IReadOnlyCollection<TLeft> collection,
        Func<TRight> createRight)
        where TLeft : class
        where TRight : class =>
        collection.Count > 0
            ? Either<IReadOnlyCollection<TLeft>, TRight>.Left(collection)
            : Either<IReadOnlyCollection<TLeft>, TRight>.Right(createRight());
}
