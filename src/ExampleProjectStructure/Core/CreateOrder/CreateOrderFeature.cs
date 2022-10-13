namespace CleanCode.Academy.Core.CreateOrder;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CreateOrderFeature
{
    private readonly CreateOrderFeatureFlagConfig config;
    private readonly IModifier modifier;
    private readonly IOrderCreatedPublisher orderCreatedPublisher;

    public CreateOrderFeature(
        CreateOrderFeatureFlagConfig config,
        IModifier modifier,
        IOrderCreatedPublisher orderCreatedPublisher)
    {
        this.config = config;
        this.modifier = modifier;
        this.orderCreatedPublisher = orderCreatedPublisher;
    }

    public async Task CreateOrder(
        Order order)
    {
        var updatedOrder = this.config.IsFeatureCombinePositionsEnabled
            ? order with { Positions = CombinePositions(order) }
            : order;

        await this.modifier
            .Save(updatedOrder)
            .ConfigureAwait(false);

        await this.orderCreatedPublisher
            .Publish(updatedOrder)
            .ConfigureAwait(false);
    }

    private static IEnumerable<Position> CombinePositions(
        Order order) =>
        order
            .Positions
            .GroupBy(
                p => p.ItemName,
                (
                    itemName,
                    positions) => (itemName, sum: positions.Sum(x => x.Amount)))
            .Select(
                x => new Position(
                    x.itemName,
                    x.sum));
}
