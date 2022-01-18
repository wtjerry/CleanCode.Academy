namespace CleanCode.Academy.CleanCode.Academy
{
    using System;
    using System.Threading.Tasks;

    public static class Program
    {
        public static Task Main(string[] args)
        {
            return Console.Error.WriteLineAsync($"Got {args.Length - 1} arguments");
        }
    }
}
