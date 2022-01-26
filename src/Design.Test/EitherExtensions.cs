namespace CleanCode.Naming
{
    public static class EitherExtensions
    {
        public static EitherAssertions<TLeft, TRight> Should<TLeft, TRight>(this Either<TLeft, TRight> instance)
            where TLeft : class
            where TRight : class
        {
            return new EitherAssertions<TLeft, TRight>(instance);
        }
    }
}
