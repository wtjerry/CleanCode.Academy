namespace CleanCode.Academy.ServiceHost;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Get(
        string id)
    {
        var orders = await this.factory
            .CreateGetOrdersFeature()
            .GetOrders()
            .ConfigureAwait(false);

        return this.Ok(orders);
    }
}
