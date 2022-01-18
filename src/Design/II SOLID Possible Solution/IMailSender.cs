// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidSolution
{
    using System;
    using System.Net.Mail;

    /// <summary>
    /// Provides functionality for sending mails. The purpose of this interface is to decouple infrastructure
    /// logic from business logic.
    /// </summary>
    public interface IMailSender : IDisposable
    {
        void SendOrderMail(MailMessage orderMail);
    }
}