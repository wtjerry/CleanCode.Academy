namespace CleanCode.Academy.Core.GetOrders;

using System.Collections.Generic;
using System.Threading.Tasks;

public class GetOrdersFeature
{
    private readonly IQuery query;

    public GetOrdersFeature(IQuery query)
    {
        this.query = query;
    }

    public Task<IEnumerable<Order>> GetOrders()
    {
        var orders = this.query.GetAll();
        return orders;
    }
}
