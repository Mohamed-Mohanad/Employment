using Employment.Application.Authentication;
using Employment.Domain.Entities;
using Employment.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employment.Infrastructure.Authentication
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        private readonly UserManager<User> _userManager;

        public JwtProvider(
            IOptions<JwtOptions> options,
            UserManager<User> userManager)
        {
            _options = options.Value;
            _userManager = userManager;
        }

        public async Task<string> Generate(User user, Guid otherId)
        {

            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new("OtherId", otherId.ToString()!),
                new(JwtRegisteredClaimNames.Email, user.Email!.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName!.ToString()),
                new(ClaimTypes.Role, userRole!),
            };

            var dict = JwtSecurityTokenHandler.DefaultInboundClaimTypeMap;
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenValue;
        }
    }
}
