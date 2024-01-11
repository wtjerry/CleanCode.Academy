namespace CleanCode.Academy.ServiceHost;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/order")]
public class GetOrdersController : ControllerBase
{
    private readonly Factory factory;

    public GetOrdersController(Factory factory)
    {
        this.factory = factory;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var orders = await this.factory
            .CreateGetOrdersFeature()
            .GetOrders()
            .ConfigureAwait(false);

        return this.Ok(orders);
    }
}
