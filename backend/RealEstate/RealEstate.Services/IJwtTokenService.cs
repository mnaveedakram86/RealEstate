using RealEstate.Core.Entities;

namespace RealEstate.Services
{
    public interface IJwtTokenService
    {
        string  GenerateAccessToken(ApplicationUser user, DateTime expiryMinutes);
        Task<string> GenerateRefreshTokenAsync(ApplicationUser user, DateTime expiryMinutes);
        
        Task<bool> ValidateRefreshTokenAsync(string userId, string token);

        Task<bool> LogoutSessionAsync(string userId, string refreshToken);
    }
}
