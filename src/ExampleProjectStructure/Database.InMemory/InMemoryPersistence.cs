namespace CleanCode.Academy.Database.InMemory;

using Core.GetOrders;
using System.Collections.Generic;

public class InMemoryPersistence
{
    public InMemoryPersistence()
    {
        this.Orders = [];
    }

    public List<Order> Orders { get; }
}
