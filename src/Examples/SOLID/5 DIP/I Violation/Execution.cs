namespace bbv.Examples.SOLID._5_DIP.I_Violation
{
    using System;
    using PackageA;
    using PackageB;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("DIP Violation Example");

            var mail = new Email("sombody@example.com", "Testmessage", "Foo Bar");

            var notification = new Notification(mail);
            notification.Send();
        }
    }
}
