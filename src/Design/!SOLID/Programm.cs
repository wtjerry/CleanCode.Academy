// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidExercise
{
    public static class Programm
    {
        /// <summary>
        /// Runs the sample program.
        /// </summary>
        public static int Main()
        {
            var itemCollection = new ItemCollection();
            itemCollection.Initialize();

            var basket = new ShoppingBasket();
            basket.Add(itemCollection.GetBook());
            basket.Add(itemCollection.GetNotebook(ItemColor.Yellow));
            basket.Add(itemCollection.GetPen(ItemColor.Blue));
            basket.Add(itemCollection.GetPen(ItemColor.Green));

            basket.PrintToConsole();
            basket.SendOrderMail("myself@sample.ch");

            return 0;
        }
    }
}