using NTA.Core.DTOs;
using NTA.Core.Models;

namespace NTA.Core.Services;

public interface IUserService:IService<User>
{
    User GetByEmail(string email);
    Task<Token> Login(UserLoginDto userLoginDto);
}