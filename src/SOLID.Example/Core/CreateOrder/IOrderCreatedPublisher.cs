namespace CleanCode.Academy.Core.CreateOrder;

using System.Threading.Tasks;

public interface IOrderCreatedPublisher
{
    Task Publish(
        Order order);
}
