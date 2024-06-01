using System.Security.Claims;
using DonutShop.Api.Features.Orders.CreateOrder;
using DonutShop.Api.Features.Orders.GetOrder;
using DonutShop.Api.Features.Orders.Invoices.GetInvoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Api.Features.Orders;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateOrderCommand
        {
            Request = request,
            UserId = User.FindFirstValue(ClaimTypes.Sid),
        };
        
        var dto = await _mediator.Send(command, cancellationToken);
        
        var url = Url.Action("Get", new { dto.Id });

        return Created(url!, dto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var query = new GetOrderQuery
        {
            Id = id,
            UserId = User.FindFirstValue(ClaimTypes.Sid),
        };

        var dto = await _mediator.Send(query, cancellationToken);

        return dto == null ? NotFound() : Ok(dto);
    }
    
    [HttpGet("{id:int}/invoice")]
    public async Task<IActionResult> GetInvoice(int id, CancellationToken cancellationToken)
    {
        var query = new GetInvoiceQuery
        {
            OrderId = id,
            UserId = User.FindFirstValue(ClaimTypes.Sid),
        };

        var invoice = await _mediator.Send(query, cancellationToken);

        if (invoice == null)
        {
            return NotFound();
        }

        return File(invoice.Stream, invoice.MimeType, $"Order-{id}{invoice.FileExtension}");
    }
}