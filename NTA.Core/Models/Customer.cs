namespace NTA.Core.Models;

public class Customer:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Sale> Sales { get; set; }
}