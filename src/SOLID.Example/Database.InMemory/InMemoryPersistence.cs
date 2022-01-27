namespace CleanCode.Academy.Database.InMemory;

using System.Collections.Generic;
using Core.GetOrders;

public class InMemoryPersistence
{
    public InMemoryPersistence()
    {
        this.Orders = new List<Order>();
    }

    public List<Order> Orders { get; }
}
