using System.Text;
using DonutShop.Api.Shared.Database.Entities;

namespace DonutShop.Api.Features.Orders.Invoices;

public class TextInvoiceGenerator : IInvoiceGenerator
{
    public string FileExtension => ".txt";

    public string MimeType => "text/plain";

    public byte[] Create(Order order)
    {
        var sb = new StringBuilder();

        sb.AppendLine("-------- Order Invoice --------- ");
        sb.AppendLine();
        sb.AppendLine($"Order Id: {order.Id}");
        sb.AppendLine();

        var totalPrice = 0m;

        foreach (var orderDonut in order.OrderDonuts)
        {
            var price = orderDonut.Quantity * orderDonut.UnitPrice;
            totalPrice += price;
            
            sb.AppendLine($"{orderDonut.Donut.Name} x{orderDonut.Quantity} - £{price}");
        }

        sb.AppendLine();
        sb.AppendLine($"Total Price: £{totalPrice}");
        sb.AppendLine();
        sb.AppendLine("-------- Order Invoice --------- ");
        
        var invoice = sb.ToString();
        var invoiceBytes = Encoding.UTF8.GetBytes(invoice);

        return invoiceBytes;
    }
}