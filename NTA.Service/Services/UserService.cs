using NTA.Core.DTOs;
using NTA.Core.Models;
using NTA.Core.Repositories;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;
using NTA.Service.Hashing;

namespace NTA.Service.Services;

public class UserService:Service<User>,IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHandler _tokenHandler;
    public UserService(IGenericRepository<User> repository, IUnitOfWorks unitOfWorks,IUserRepository userRepository) : base(repository, unitOfWorks)
    {
        _userRepository = userRepository;
    }

    public User GetByEmail(string email)
    {
        User user = _userRepository.Where(x => x.Email == email).FirstOrDefault();

        return user ?? user;
    }

    public async Task<Token> Login(UserLoginDto userLoginDto)
    {
        Token token = new Token();
        var user = GetByEmail(userLoginDto.Email);

        if (user == null)
        {
            return null;
        }

        var result = false;
        result = HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt);

        List<Role> roles = new List<Role>();

        if (result)
        {
            token = _tokenHandler.CreateToken(user, roles);
            return token;
        }

        return null;
    }
}