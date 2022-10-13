namespace CleanCode.Academy.Parsing.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.CreateOrder;

    public static class OrderDtoExtensionMethods
    {
        public static Either<IReadOnlyCollection<string>, Order> ToOrder(
            this OrderDto dto) =>
            Validate(dto)
                .ToEitherFromErrors(() => CreateOrder(dto));

        private static Order CreateOrder(
            OrderDto dto) =>
            new(
                dto.Address,
                dto.Positions.Select(
                    x => new Position(
                        x.Name,
                        x.Amount)));

        private static IReadOnlyCollection<string> Validate(
            OrderDto dto)
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrEmpty(dto.Address))
            {
                validationErrors.Add("Address cannot be empty.");
            }

            if (!dto.Positions.Any())
            {
                validationErrors.Add("Order has to have at least one position.");
            }

            if (dto.Positions.Any(x => x.Amount < 1))
            {
                validationErrors.Add("All Positions must be of a positive amount.");
            }

            return validationErrors;
        }
    }
}
