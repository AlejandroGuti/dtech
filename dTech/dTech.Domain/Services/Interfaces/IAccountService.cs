using dTech.Common.DTOs;
using dTech.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response> CreateUser(UserRequest SearchString);
        Task<Response> Login(TokenRequest SearchString);
    }
}
