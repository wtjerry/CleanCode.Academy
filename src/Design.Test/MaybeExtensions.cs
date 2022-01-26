namespace CleanCode.Naming;

public static class MaybeExtensions
{
    public static MaybeAssertions<T> Should<T>(this Maybe<T> instance)
    {
        return new MaybeAssertions<T>(instance);
    }
}
