using System.Security.Claims;

namespace NTA.Service.Extensions;

public static class ClaimsExtensions
{
    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(ClaimTypes.Name,name));
        //claims.Add(new Claim(ClaimTypes.Uri));
    }

    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
    }
}