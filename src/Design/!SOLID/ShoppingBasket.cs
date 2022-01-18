// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;

    public class ShoppingBasket : IDisposable
    {
        private readonly List<Item> itemsInBasket = new List<Item>();
        private readonly SmtpClient smtpClient = new SmtpClient("localhost");

        public void Add(Item item)
        {
            this.itemsInBasket.Add(item);
        }

        public void PrintToConsole()
        {
            var total = this.itemsInBasket.Sum(i => i.PriceInChf);
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    this.itemsInBasket.Select(i => i.GetString())));
            Console.WriteLine($"Total: {total} CHF");
        }

        public void SendOrderMail(string toAddress)
        {
            var total = this.itemsInBasket.Sum(i => i.PriceInChf);
            var orderItemList = string.Join(
                Environment.NewLine,
                this.itemsInBasket.Select(i => $"{i.Id}\t{i.Type}\t{i.Title}\t{i.PriceInChf} CHF"));
            string mailContent = $@"Your Order:
---------------------
{orderItemList}
---------------------
Total Price: {total} CHF

Kind Regards,
Clean Code Academy";

            var mail = new MailMessage("noreply@bbv.ch", toAddress, "Your Order", mailContent);

            // the content of the shopping basket could be sent over mail,
            // but because we don't have a working SMTP Server we will only write a note in the console output.
            /*
            this.smtpClient.Send(mail);
            */
            Console.WriteLine($"Sending mail to: {toAddress}");
        }

        public void Dispose()
        {
            this.smtpClient?.Dispose();
        }
    }
}