namespace bbv.Examples.SOLID._5_DIP.II_Solution.Implementations
{
    using System;
    using PackageA;

    public class Email : IMessage
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

        public void Send()
        {
            Console.WriteLine(
                "Sending mail to {0} [{1}] > {2}",
                this.toAddress,
                this.subject,
                this.content);
        }
    }
}