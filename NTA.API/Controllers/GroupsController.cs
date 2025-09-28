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

public class GroupsController : CustomBaseController
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public GroupsController(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = _groupService.GetAllAsync();
        var groupDtos = _mapper.Map<List<GroupDto>>(groups);

        return CreateActionResult(CustomResponseDto<List<GroupDto>>.Success(200, groupDtos));
    }
    
    
    [ServiceFilter(typeof(NotFoundFilter<Group>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var group = await _groupService.GetByIdAsync(id);
        var groupDto = _mapper.Map<GroupDto>(group);

        return CreateActionResult(CustomResponseDto<GroupDto>.Success(200, groupDto));
    }

    [ServiceFilter(typeof(NotFoundFilter<Group>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = 1;
        var group = await _groupService.GetByIdAsync(id);

        group.UpdatedBy = userId;
        _groupService.ChangeStatus(group);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    public async Task<IActionResult> Create(GroupDto groupDto)
    {
        int userId = 1;

        var group = _mapper.Map<Group>(groupDto);
        group.CreatedBy = userId;
        group.UpdatedBy = userId;

        var newGroup = await _groupService.AddAsync(group);
        var newGroupDto = _mapper.Map<GroupDto>(newGroup);

        return CreateActionResult(CustomResponseDto<GroupDto>.Success(201, newGroupDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(GroupUpdateDto groupUpdateDto)
    {
        int userId = 1;
        var group = await _groupService.GetByIdAsync(groupUpdateDto.Id);

        group.UpdatedBy = userId;
        group.Name = groupUpdateDto.Name; // GroupUpdateDto'daki property’lere göre uyarlaman gerekebilir.

        _groupService.Update(group);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
    
    
}