using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository : IUserRefreshTokenRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRefreshTokenRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task AssignRefreshTokenAsync(IdentityUser user, string newToken, DateTime expiryMinutes)
        {
            var refreshToken = new UserRefreshToken
            {
                UserId = user.Id,
                RefreshToken = newToken,
                ExpiryDate = expiryMinutes
            };
            this._appDbContext.UserRefreshTokens.Add(refreshToken);
            await this._appDbContext.SaveChangesAsync();
        }
        public async Task<bool> ValidateRefreshTokenAsync(string userId, string token)
        {
            var storedToken = await this._appDbContext.UserRefreshTokens
                                        .FirstOrDefaultAsync(x => x.UserId == userId && x.RefreshToken == token);

            if (storedToken == null) return false;
            if (storedToken.RefreshToken != token) return false;
            if (storedToken.ExpiryDate < DateTime.UtcNow) return false;

            return true;
        }

        public async Task<bool> LogOutSessionAsync(string userId, string refreshToken)
        {
            var session = await this._appDbContext.UserRefreshTokens
                .FirstOrDefaultAsync(s => s.UserId == userId && s.RefreshToken == refreshToken);

            if (session != null)
            {
                this._appDbContext.UserRefreshTokens.Remove(session);
                await this._appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
