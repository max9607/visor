using PLVISORTELERIK.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLVISORTELERIK.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken userToken);
        Task<bool> Login(string token);
        Task Logout();
        Task ManejarRenovacionToken();
        Task<bool> existeToken();
    }
}
