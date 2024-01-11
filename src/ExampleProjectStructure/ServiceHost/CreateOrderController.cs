namespace CleanCode.Academy.ServiceHost;

using Microsoft.AspNetCore.Mvc;
using Parsing.Extensions;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/order")]
public class CreateOrderController : ControllerBase
{
    private readonly Factory factory;

    public CreateOrderController(
        Factory factory)
    {
        this.factory = factory;
    }

    [HttpPost("")]
    public async Task<IActionResult> Post(
        [FromBody] OrderDto item)
    {
        var order = item.ToOrder()
            .GetRightOrThrow(
                errors => new ArgumentException(
                    string.Join(
                        ",",
                        errors)));

        await this.factory
            .CreateCreateOrderFeature()
            .CreateOrder(order)
            .ConfigureAwait(false);

        return this.Ok();
    }
}
