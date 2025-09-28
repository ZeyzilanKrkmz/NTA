using System.Security.Claims;
using Microsoft.Identity.Client;
using NTA.Core.Models;

namespace NTA.Core.Services;

public interface ITokenHandler
{
    Token CreateToken(User user, List<Role> roles);

    string CreateRefreshToken();

    IEnumerable<Claim> SetClaims(User user, List<Role> roles)
    {
        throw new NotImplementedException();
    }
}