namespace CleanCode.Academy.Parsing.Extensions;

using System.Collections.Generic;

public record PositionDto(
    string Name,
    int Amount);

public record OrderDto(
    string Address,
    IEnumerable<PositionDto> Positions);
