namespace CleanCode.Academy.ServiceHost;

using Core.CreateOrder;
using System.Threading.Tasks;

public class OrderCreatedPublisher : IOrderCreatedPublisher
{
    public Task Publish(
        Order order)
    {
        // pretend to publish an OrderCreated Event via some messaging system. (eg Azure Service Bus)
        return Task.CompletedTask;
    }
}
