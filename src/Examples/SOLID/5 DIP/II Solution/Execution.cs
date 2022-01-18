namespace bbv.Examples.SOLID._5_DIP.II_Solution
{
    using System;
    using Implementations;
    using PackageA;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("DIP Solution Example");

            IMessage mail = new Email("sombody@example.com", "Testmessage", "Foo Bar");

            var notification = new Notification(new []{ mail });
            notification.Send();
        }
    }
}
