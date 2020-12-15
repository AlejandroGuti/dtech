using dTech.Common.Enums;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Contexts
{
    public class SeedDb
    {
        private readonly DTechContext _context;
        private readonly IUserRepository _userRepository;

        public SeedDb(
           DTechContext context,
           IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            await CheckUserAsync("115245684", "Ale", "Ale", "Alejandro@hotmail.com", UserType.Admin);
        }

        private async Task CheckRoles()
        {
            await _userRepository.CheckRoleAsync("Admin");
            await _userRepository.CheckRoleAsync("Customer");
        }

        private async Task<User> CheckUserAsync(
           string document,
           string firstName,
           string lastName,
           string email,
           UserType role)
        {
            User user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    Document = document,
                    UserType = role
                };

                await _userRepository.AddUserAsync(user, "123456");
                await _userRepository.AddUserToRoleAsync(user, role.ToString());

                string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
                await _userRepository.ConfirmEmailAsync(user, token);
            }

            return user;
        }

    }
}
