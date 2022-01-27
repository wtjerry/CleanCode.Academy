namespace CleanCode.Academy.Core.CreateOrder;

using System.Collections.Generic;

public record Order(
    string Address,
    IEnumerable<Position> Positions);
