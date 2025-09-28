namespace NTA.Core.Models;

public class Payment:BaseEntity
{
    public int CustomerId { get; set; }
    public double Amount { get; set; }
    public Customer Customer { get; set; }
}