namespace bbv.Examples.SOLID._5_DIP.II_Solution.PackageA
{
    public class Notification
    {
        private readonly IMessage[] messages;

        public Notification(IMessage[] messages)
        {
            this.messages = messages;
        }

        public void Send()
        {
            foreach (var message in this.messages)
            {
                message.Send();
            }
        }
    }
}