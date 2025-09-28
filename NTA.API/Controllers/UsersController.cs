using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTA.Core.DTOs;
using NTA.Core.DTOs.UpdateDTOs;
using NTA.Core.Models;
using NTA.Core.Services;
using NTA.Filters;
using NTA.Service.Hashing;

namespace NTA.Controllers;

[Route("api/[controller]/{userUpdateDto}")]
[ApiController]
public class UsersController : CustomBaseController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = _userService.GetAllAsync();
        var userDtos = _mapper.Map<List<UserDto>>(users);

        return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, userDtos));
    }

    [ServiceFilter(typeof(NotFoundFilter<User>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var userDto = _mapper.Map<UserDto>(user);

        return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
    }

    [ServiceFilter(typeof(NotFoundFilter<User>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = 1;
        var user = await _userService.GetByIdAsync(id);

        user.UpdatedBy = userId;
        _userService.ChangeStatus(user);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto userDto)
    {
        int userId = 1;

        var user = _mapper.Map<User>(userDto);
        user.CreatedBy = userId;
        user.UpdatedBy = userId;

        var newUser = await _userService.AddAsync(user);
        var newUserDto = _mapper.Map<UserDto>(newUser);

        return CreateActionResult(CustomResponseDto<UserDto>.Success(201, newUserDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
    {
        int userId = 1;
        var processedEntity = _mapper.Map<User>(userDto);

        processedEntity.UpdatedBy = userId;
        processedEntity.Name = userUpdateDto.Name;

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePassword(userDto.Password,out passwordHash,out passwordSalt);
        processedEntity.PasswordHash = passwordHash;
        processedEntity.PasswordSalt = passwordSalt;

        var user = await _userService.AddAsync(processedEntity);
        var userResponseDto = _mapper.Map<UserDto>(user);

        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}
