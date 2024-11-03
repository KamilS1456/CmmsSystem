using Cmms.Models;
using Cmms.Models.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Services
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
        public LoginRespone Login(LoginDto loginDto);
        public LoginRespone RefreshToken(RefreshTokenModel refreshTokenModel);
        public void Delete(int id);
    }
}
