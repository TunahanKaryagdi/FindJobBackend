using FindJob.Application.Abstractions.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJob.Infrastructure.Services
{
    public class TokenHelper : ITokenHelper
    {
        private IConfiguration _configuration { get; set; }

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateAccessToken(string userId, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                audience: _configuration["TokenOptions:Audience"],
                issuer: _configuration["TokenOptions:Issuer"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["TokenOptions:AccessTokenExpiration"])),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string accessToken = handler.WriteToken(jwtSecurityToken);
            return accessToken;
        }
    }
}
