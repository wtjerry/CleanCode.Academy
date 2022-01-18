// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System.Net.Mail;

    public class MailSender : IMailSender
    {
        private readonly SmtpClient smtpClient = new SmtpClient("localhost");

        public void SendOrderMail(MailMessage orderMail)
        {
            this.smtpClient.Send(orderMail);
        }

        public void Dispose()
        {
            this.smtpClient?.Dispose();
        }
    }
}