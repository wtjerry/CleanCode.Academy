namespace CleanCode.Academy.Database.InMemory;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Core.CreateOrder;

public class Modifier : IModifier
{
    private readonly InMemoryPersistence inMemoryPersistence;
    private readonly Random random;

    public Modifier(
        InMemoryPersistence inMemoryPersistence,
        Random random)
    {
        this.inMemoryPersistence = inMemoryPersistence;
        this.random = random;
    }

    [SuppressMessage(
        "Security",
        "CA5394:DoNotUseInsecureRandomness",
        Justification = "We do not need true randomness here. It's only used for testing purposes.")]
    public Task Save(
        Order order)
    {
        var orderToSave = new Core.GetOrders.Order(
            this.random.Next(),
            order.Address,
            order.Positions.Select(
                x => new Core.GetOrders.Position(
                    x.ItemName,
                    x.Amount)));

        this.inMemoryPersistence.Orders.Add(orderToSave);

        return Task.CompletedTask;
    }
}
