using dTech.Common.DTOs;
using dTech.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(TokenRequest model);

        Task LogoutAsync();

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<bool> DeleteUserAsync(string email);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);
        Task<IList<string>> GetRolesAsync(User usuario);
    }
}
