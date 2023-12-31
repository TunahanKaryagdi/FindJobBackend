﻿using FindJob.Application.Abstractions.Token;
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

        public Token CreateAccessToken(string userId)
        {
            Token token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            token.ExpirationTime = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["TokenOptions:AccessTokenExpiration"]));
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,userId),

                },
                audience: _configuration["TokenOptions:Audience"],
                issuer: _configuration["TokenOptions:Issuer"],
                expires: token.ExpirationTime,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            token.AccessToken = handler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
