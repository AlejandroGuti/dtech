using dTech.Common.DTOs;
using dTech.Common.Responses;
using dTech.Domain.Services.Interfaces;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AccountService(
            IConfiguration configuration,
            IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;

        }
        public async Task<Response> CreateUser(UserRequest model)
        {
            User user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Document = model.Document,
                UserType = model.UserType
            };
            var info = await _userRepository.GetUserByEmailAsync(user.Email);
            if (info != null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "User email exist"
                };
            }
            IdentityResult result = await _userRepository.AddUserAsync(user, model.Password);
            await _userRepository.AddUserToRoleAsync(user, model.UserType.ToString());

            if (result.Succeeded)
            {
                string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
                await _userRepository.ConfirmEmailAsync(user, token);

                return new Response
                {

                    Result = BuildToken(model.Email, new List<string>()),
                    IsSuccess = true,
                    Message = "User Created"
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Username or password invalid"
                };
            }
        }

        public async Task<Response> Login(TokenRequest model)
        {
            SignInResult result = await _userRepository.LoginAsync(model);
            if (result.Succeeded)
            {
                User user = await _userRepository.GetUserByEmailAsync(model.Email);
                IList<string> roles = await _userRepository.GetRolesAsync(user);
                return new Response
                {
                    Result = BuildToken(model.Email, roles),
                    IsSuccess = true,
                };

            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Invalid login attempt."
                };

            }
        }

        private UserToken BuildToken(string email, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (string rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiration = DateTime.UtcNow.AddYears(1);
            JwtSecurityToken token = new JwtSecurityToken(
                _configuration["Tokens:Issuer"],
                _configuration["Tokens:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }


    }
}
