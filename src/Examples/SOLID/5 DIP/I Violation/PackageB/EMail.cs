namespace bbv.Examples.SOLID._5_DIP.I_Violation.PackageB
{
    using System;

    public class Email
    {
        private readonly string content;
        private readonly string subject;
        private readonly string toAddress;

        public Email(string toAddress, string subject, string content)
        {
            this.toAddress = toAddress;
            this.subject = subject;
            this.content = content;
        }

        public void SendMail()
        {
            Console.WriteLine(
                "Sending mail to {0} [{1}] > {2}",
                this.toAddress,
                this.subject,
                this.content);
        }
    }
}