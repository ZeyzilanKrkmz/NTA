using NTA.Core.Models;

namespace NTA.Core.DTOs;

public class CustomerDto:BaseDto
{
    public string Name { get; set; }
    public List<Payment> Payments { get; set; }
    public List<Sale> Sales { get; set; }
}