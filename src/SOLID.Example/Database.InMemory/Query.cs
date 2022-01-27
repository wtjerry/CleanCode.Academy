namespace CleanCode.Academy.Database.InMemory;

using System.Collections.Generic;
using System.Threading.Tasks;
using Core.GetOrders;

public class Query : IQuery
{
    private readonly InMemoryPersistence inMemoryPersistence;

    public Query(InMemoryPersistence inMemoryPersistence)
    {
        this.inMemoryPersistence = inMemoryPersistence;
    }

    public Task<IEnumerable<Order>> GetAll()
    {
        IEnumerable<Order> orders = this.inMemoryPersistence.Orders;
        return Task.FromResult(orders);
    }
}
