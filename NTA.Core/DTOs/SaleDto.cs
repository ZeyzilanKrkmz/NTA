using NTA.Core.Models;

namespace NTA.Core.DTOs;

public class SaleDto:BaseDto
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public double TotalPrice { get; set; }

    public CustomerDto Customer { get; set; }
    public ProductDto Product { get; set; }
}