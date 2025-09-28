using NTA.Core.Models;

namespace NTA.Core.DTOs;

public class ProductDto:BaseDto
{
    public string Name { get; set; }
    public double UnitPrice { get; set; }
    public List<Sale> Sales { get; set; }
}