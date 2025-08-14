using Microsoft.AspNetCore.Identity;

namespace RealEstate.Infrastructure.Repositories
{
    public interface IUserRefreshTokenRepository
    {
        Task<bool> ValidateRefreshTokenAsync(string userId, string token);
        Task AssignRefreshTokenAsync(IdentityUser user, string newToken, DateTime expiryMinutes);

        Task<bool> LogOutSessionAsync(string userId, string refreshToken);
    }
}
