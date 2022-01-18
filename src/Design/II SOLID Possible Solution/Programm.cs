// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    public static class Programm
    {
        // /// <summary>
        // /// Runs the sample program.
        // /// </summary>
        // public static int Main()
        // {
        //     var itemCollection = ItemCollectionFactory.GetInitializedCollection();
        //
        //     var basket = new ShoppingBasket();
        //     basket.Add(itemCollection.GetBook());
        //     basket.Add(itemCollection.GetNotebook(NotebookColor.Yellow));
        //     basket.Add(itemCollection.GetPen(PenColor.Blue));
        //     basket.Add(itemCollection.GetPen(PenColor.Green));
        //
        //     ConsolePrinter.PrintToConsole(basket.Items);
        //     var mailMessage = OrderMailFormatter.FormatFor(basket, "myself@sample.ch");
        //     var mailSenderFactory = new MailSenderFactory(testingMode: true);
        //     using (var sender = mailSenderFactory.Create())
        //     {
        //         sender.SendOrderMail(mailMessage);
        //     }
        //
        //     return 0;
        // }
    }
}
