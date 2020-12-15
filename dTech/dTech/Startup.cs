using AutoMapper;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Ioc.DependenciesContainer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace dTech
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            RegisterServices(services);
            services.AddDbContext<DTechContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("dTechConnection")));

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling =
                     Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Project, Project>()
                .ReverseMap();
                configuration.CreateMap<PTask, PTask>()
                .ReverseMap();
                configuration.CreateMap<Attachment, Attachment>()
                .ReverseMap();
            }, typeof(Startup));


            services.AddCors(options =>
            {
                options.AddPolicy("FullPages", builder =>
                builder
                //.WithOrigins("http://localhost:4200/")
                .WithOrigins("*")
                .WithMethods("*")
                .WithHeaders("*"));
            });
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                cfg.SignIn.RequireConfirmedEmail = true;
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
            })
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<DTechContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                });


        }
        private static void RegisterServices(IServiceCollection services)
        {
            DependenciesContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
