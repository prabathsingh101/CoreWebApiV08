using CoreWebApiV08.API.Models.DTO;
using System.Security.Claims;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
