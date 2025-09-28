namespace NTA.Core.Models;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public double UnitPrice { get; set; }
    public ICollection<Sale> Sales { get; set; }
}