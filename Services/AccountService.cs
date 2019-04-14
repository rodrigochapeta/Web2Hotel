using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web2Hotel.Models;
using Web2Hotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace Web2Hotel.Services
{
    public class AccountService
    { 
        private readonly IConfiguration _configuration;
        private readonly Web2HotelContext _context;
        public AccountService(IConfiguration configuration,  Web2HotelContext  context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Usuario Login(LoginDto loginDto)
        {
            var user = _context.Usuario.Where(x => x.Username == loginDto.Username && x.Password == loginDto.Password).SingleOrDefault();

            if (user == null)
            {
                return null;
            }

            var signingKey = Convert.FromBase64String(_configuration["Jwt:SigningSecret"]);
            var expiryDuration = int.Parse(_configuration["Jwt:ExpiryDuration"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(expiryDuration),
                Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            user.Password = token;
            return user;
        }
    }
}