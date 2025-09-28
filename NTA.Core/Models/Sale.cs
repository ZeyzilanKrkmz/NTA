namespace NTA.Core.Models;

public class Sale:BaseEntity
{
    
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public double TotalPrice { get; set; }

    public Customer Customer { get; set; }
    public Product Product { get; set; }
    
}