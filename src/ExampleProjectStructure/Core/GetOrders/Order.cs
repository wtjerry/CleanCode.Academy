namespace CleanCode.Academy.Core.GetOrders;

using System.Collections.Generic;

public record Order(
    int Id,
    string Address,
    IEnumerable<Position> Positions);
