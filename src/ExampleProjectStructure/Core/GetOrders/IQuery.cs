namespace CleanCode.Academy.Core.GetOrders;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IQuery
{
    Task<IEnumerable<Order>> GetAll();
}
