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
public class DepartmentsController : CustomBaseController
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var departments = _departmentService.GetAllAsync();
        var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);

        return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.Success(200, departmentDtos));
    }

    [ServiceFilter(typeof(NotFoundFilter<Department>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        var departmentDto = _mapper.Map<DepartmentDto>(department);

        return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmentDto));
    }

    [ServiceFilter(typeof(NotFoundFilter<Department>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = 1;
        var department = await _departmentService.GetByIdAsync(id);

        department.UpdatedBy = userId;
        _departmentService.ChangeStatus(department);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentDto departmentDto)
    {
        int userId = 1;

        var department = _mapper.Map<Department>(departmentDto);
        department.CreatedBy = userId;
        department.UpdatedBy = userId;

        var newDepartment = await _departmentService.AddAsync(department);
        var newDepartmentDto = _mapper.Map<DepartmentDto>(newDepartment);

        return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(201, newDepartmentDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(DepartmentUpdateDto departmentUpdateDto)
    {
        int userId = 1;
        var department = await _departmentService.GetByIdAsync(departmentUpdateDto.Id);

        department.UpdatedBy = userId;
        department.Name = departmentUpdateDto.Name;

        _departmentService.Update(department);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}
