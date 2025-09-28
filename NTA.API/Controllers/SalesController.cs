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
public class SalesController : CustomBaseController
{
    private readonly ISaleService _saleService;
    private readonly IMapper _mapper;

    public SalesController(ISaleService saleService, IMapper mapper)
    {
        _saleService = saleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sales = _saleService.GetAllAsync();
        var saleDtos = _mapper.Map<List<SaleDto>>(sales);

        return CreateActionResult(CustomResponseDto<List<SaleDto>>.Success(200, saleDtos));
    }

    [ServiceFilter(typeof(NotFoundFilter<Sale>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sale = await _saleService.GetByIdAsync(id);
        var saleDto = _mapper.Map<SaleDto>(sale);

        return CreateActionResult(CustomResponseDto<SaleDto>.Success(200, saleDto));
    }

    [ServiceFilter(typeof(NotFoundFilter<Sale>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = 1;
        var sale = await _saleService.GetByIdAsync(id);

        sale.UpdatedBy = userId;
        _saleService.ChangeStatus(sale);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaleDto saleDto)
    {
        int userId = 1;

        var sale = _mapper.Map<Sale>(saleDto);
        sale.CreatedBy = userId;
        sale.UpdatedBy = userId;

        var newSale = await _saleService.AddAsync(sale);
        var newSaleDto = _mapper.Map<SaleDto>(newSale);

        return CreateActionResult(CustomResponseDto<SaleDto>.Success(201, newSaleDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(SaleUpdateDto saleUpdateDto)
    {
        int userId = 1;
        var sale = await _saleService.GetByIdAsync(saleUpdateDto.Id);

        sale.UpdatedBy = userId;
        sale.ProductId = saleUpdateDto.ProductId; // SaleUpdateDto’daki alanlara göre uyarlaman gerekebilir
        sale.Quantity = saleUpdateDto.Quantity;
        sale.TotalPrice = saleUpdateDto.TotalPrice;

        _saleService.Update(sale);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        Token token = await _userService.Login(userLoginDto);

        if (token == null)
        {
            CreateActionResult(CustomResponseDto<NoContentDto>.Fail(401, "Bilgiler uyuşmuyor."));
        }

        return CreateActionResult(CustomResponseDto<Token>.Success(200, token));
    }
}
