namespace CleanCode.Naming;

public static class MaybeExtensions2
{
    public static MaybeAssertions2<T> Should2<T>(this Maybe2<T> instance)
    {
        return new MaybeAssertions2<T>(instance);
    }
}
