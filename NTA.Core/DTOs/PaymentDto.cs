namespace NTA.Core.DTOs;

public class PaymentDto:BaseDto
{
    public int CustomerId { get; set; }
    public double Amount { get; set; }
    public CustomerDto Customer { get; set; }
}