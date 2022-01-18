// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System;
    using System.Linq;
    using System.Net.Mail;

    /// <summary>
    /// For testing purposes.
    /// </summary>
    public class FakeMailSender : IMailSender
    {
        public void SendOrderMail(MailMessage orderMail)
        {
            Console.WriteLine($"Sending mail to: {orderMail.To.First()}");
        }

        public void Dispose()
        {
            // The fact, that we have to implement the dispose methode is a violation of the ISP.
            // Nevertheless we have to accept it, as this class is only meant for testing purposes.
            // Otherwise one could forget to put a the real object within a 'using' statement.
        }
    }
}