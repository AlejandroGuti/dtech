using dTech.Domain.Services;
using dTech.Domain.Services.Interfaces;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Repositories;
using dTech.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace dTech.Infrastructure.Ioc.DependenciesContainer
{
    public class DependenciesContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<SeedDb>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IPTaskRepository, PTaskRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProjectService, ProjectService>();

        }
    }
}
