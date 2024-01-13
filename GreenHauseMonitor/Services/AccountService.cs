using AutoMapper;
using Cmms;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Excepction;
using Cmms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Services
{
    public class AccountService : IAccountService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(CmmsDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
        public string GenerateJwt(LoginDto loginDto)
        {
            var user = _dbContext.Users.Include(i => i.Role).FirstOrDefault(f => f.Email == loginDto.Email);
            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}" ),
                new Claim(ClaimTypes.Role, $"{user.Role.Id}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-mm-dd")),
            };

            if (!string.IsNullOrEmpty(user.Nationality))
            {
                claims.Add(
                    new Claim("Nationality", user.Nationality)
                    );
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenExpirationDate = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: tokenExpirationDate, signingCredentials: credential);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
