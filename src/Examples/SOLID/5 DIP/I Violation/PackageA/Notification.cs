namespace bbv.Examples.SOLID._5_DIP.I_Violation.PackageA
{
    using PackageB;

    public class Notification
    {
        private readonly Email email;

        public Notification(Email email)
        {
            this.email = email;
        }

        public void Send()
        {
            this.email.SendMail();
        }
    }
}