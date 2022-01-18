// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public class Pen : Item
    {
        public Pen(int id, string title, Price price, PenColor color)
            : base(id, title, price)
        {
            this.Color = color;
        }

        public PenColor Color { get; }

        public override string GetString()
        {
            return $"Pen: {this.Title} in {this.Color}\t> {this.Price}";
        }
    }
}