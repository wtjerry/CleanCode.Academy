namespace CleanCode.Design.SolidSolution
{
    using System;
    using System.Linq;
    using System.Net.Mail;

    public static class OrderMailFormatter
    {
        /// <summary>
        /// Formats the mail message with the content of <paramref name="basket"/> for <paramref name="toAddress"/>.
        /// </summary>
        public static MailMessage FormatFor(ShoppingBasket basket, string toAddress)
        {
            var total = Price.FromChf(basket.Items.Sum(i => i.Price.InChf));
            var orderItemList = string.Join(
                Environment.NewLine,
                basket.Items.Select(i => $"{i.Id}\t{i.GetType()}\t{i.Title}\t{i.Price}"));
            var mailContent = $@"Your Order:
---------------------
{orderItemList}
---------------------
Total Price: {total}

Kind Regards,
Clean Code Academy";

            return new MailMessage("noreply@bbv.ch", toAddress, "Your Order", mailContent);
        }
    }
}