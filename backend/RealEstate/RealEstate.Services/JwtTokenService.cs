using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealEstate.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        public JwtTokenService(IConfiguration configuration, IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            this._configuration = configuration;
            this._userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public string GenerateAccessToken(ApplicationUser user, DateTime expiryMinutes)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this._configuration["JwtSettings:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: expiryMinutes,
                signingCredentials: creds

            );

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> GenerateRefreshTokenAsync(ApplicationUser user, DateTime expiryMinutes)
        {
            var randomBytes = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            string token = Convert.ToBase64String(randomBytes);

            await this._userRefreshTokenRepository.AssignRefreshTokenAsync(user, token, expiryMinutes);
            return token;
        }

        public async Task<bool> ValidateRefreshTokenAsync(string userId, string token)
        {
            return await this._userRefreshTokenRepository.ValidateRefreshTokenAsync(userId, token);
        }

        public async Task<bool> LogoutSessionAsync(string userId, string refreshToken)
        {
            return await this._userRefreshTokenRepository.ValidateRefreshTokenAsync(userId, refreshToken);
        }
    }
}
