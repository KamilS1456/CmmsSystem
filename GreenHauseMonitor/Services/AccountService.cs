using AutoMapper;
using Cmms;
using Cmms.Authorization;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Excepction;
using Cmms.Models;
using Cmms.Models.Respones;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Services
{
    public class AccountService : IAccountService
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IAuthorizationService _authorizationService;
        public AccountService(CmmsDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IUserContextService userContextService, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
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
        public LoginRespone Login(LoginDto loginDto)
        {           
            var user = _dbContext.Users.Include(i => i.Role).FirstOrDefault(f => f.Email == loginDto.Email);
            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                //throw new BadRequestException("Invalid username or password");
            }            

            var loginResponse = new LoginRespone();
            loginResponse.IsLoggedIn = true;
            loginResponse.JWTToken = GenerateTokenString(user);
            loginResponse.RefreshToken = GenerateRefreshTokenString();
            user.RefreshToken = loginResponse.RefreshToken;
            user.RefreshTokenExpiry = DateTime.Now.AddHours(12);
            _dbContext.SaveChanges();
            return loginResponse;
        }

        string GenerateTokenString(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}" ),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
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

        string GenerateRefreshTokenString()
        {
            var rundomNumber = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
            { 
                numberGenerator.GetBytes(rundomNumber);
            }
            return Convert.ToBase64String(rundomNumber);
        }

        ClaimsPrincipal? GetTokenPrincipal(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));

            var validation = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                
            };
            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
        public LoginRespone RefreshToken(RefreshTokenModel refreshTokenModel)
        {
            var loginResponse = new LoginRespone();
            var principal = GetTokenPrincipal(refreshTokenModel.JWTToken);
            var userID = principal.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier).Value;
            if (userID != null) {
                var user = _dbContext.Users.FirstOrDefault(f => f.Id.ToString() == userID);//nie przez to string
                if (user is null || user.RefreshToken == refreshTokenModel.RefreshToken || user.RefreshTokenExpiry > DateTime.Now) {
                    return loginResponse;
                }
                if (user != null && user.RefreshToken == refreshTokenModel.RefreshToken){
                    loginResponse.IsLoggedIn = true;
                    loginResponse.JWTToken = GenerateTokenString(user);
                    loginResponse.RefreshToken = GenerateRefreshTokenString();
                    user.RefreshToken = loginResponse.RefreshToken;
                    user.RefreshTokenExpiry = DateTime.Now.AddHours(12);
                    _dbContext.SaveChanges();
                }
            }            
            return loginResponse;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(f => f.Id == id);
            if (user is null)
            {
                throw new NotFoundException("User not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, user, new ResourcesOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
