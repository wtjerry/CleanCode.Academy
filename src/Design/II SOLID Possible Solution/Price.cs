// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public class Price
    {
        private const decimal ChfToEuro = 0.9120m;

        private readonly decimal valueInChf;

        private Price(decimal valueInChf)
        {
            this.valueInChf = valueInChf;
        }

        public static Price FromChf(decimal valueInChf)
        {
            return new Price(valueInChf);
        }

        public static Price FromEuro(decimal valueInEuro)
        {
            return new Price(valueInEuro / ChfToEuro);
        }

        public decimal InChf => this.valueInChf;

        public decimal InEuro => this.valueInChf * ChfToEuro;

        public override string ToString()
        {
            return $"{this.valueInChf} CHF";
        }
    }
}