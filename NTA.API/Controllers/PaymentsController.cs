using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTA.Core.DTOs;
using NTA.Core.DTOs.UpdateDTOs;
using NTA.Core.Models;
using NTA.Core.Services;
using NTA.Filters;

namespace NTA.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : CustomBaseController
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;

    public PaymentsController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payments = _paymentService.GetAllAsync();
        var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);

        return CreateActionResult(CustomResponseDto<List<PaymentDto>>.Success(200, paymentDtos));
    }

    [ServiceFilter(typeof(NotFoundFilter<Payment>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await _paymentService.GetByIdAsync(id);
        var paymentDto = _mapper.Map<PaymentDto>(payment);

        return CreateActionResult(CustomResponseDto<PaymentDto>.Success(200, paymentDto));
    }

    [ServiceFilter(typeof(NotFoundFilter<Payment>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = 1;
        var payment = await _paymentService.GetByIdAsync(id);

        payment.UpdatedBy = userId;
        _paymentService.ChangeStatus(payment);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    public async Task<IActionResult> Create(PaymentDto paymentDto)
    {
        int userId = 1;

        var payment = _mapper.Map<Payment>(paymentDto);
        payment.CreatedBy = userId;
        payment.UpdatedBy = userId;

        var newPayment = await _paymentService.AddAsync(payment);
        var newPaymentDto = _mapper.Map<PaymentDto>(newPayment);

        return CreateActionResult(CustomResponseDto<PaymentDto>.Success(201, newPaymentDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(PaymentUpdateDto paymentUpdateDto)
    {
        int userId = 1;
        var payment = await _paymentService.GetByIdAsync(paymentUpdateDto.Id);

        payment.UpdatedBy = userId;
        payment.Amount = paymentUpdateDto.Amount; // PaymentUpdateDto’daki alanlara göre uyarlaman gerekebilir.
        payment.Status = paymentUpdateDto.Status;

        _paymentService.Update(payment);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}
