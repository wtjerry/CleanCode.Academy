namespace CleanCode.Academy.ServiceHost;

using System.Threading.Tasks;
using Core.CreateOrder;

public class OrderCreatedPublisher : IOrderCreatedPublisher
{
    public Task Publish(
        Order order)
    {
        // pretend to publish an OrderCreated Event via some messaging system. (eg Azure Service Bus)
        return Task.CompletedTask;
    }
}
