using Coach.BAL.Services;
using Coach.Core.Interfaces;
using Coach.DAL;
using Coach.DAL.Repositories;
using Coach.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Coach_s_Log
{
    public static class RegisterServices
    {
        public static void RegisterAppServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<ISportsmenRepository, SportsmenRepository>();
            services.AddScoped<ISportsmenService, SportsmenService>();
            services.AddScoped<IJWTProvider, JWTProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IDataGenerator, DataGenerator>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonService, LessonService>();

            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.AddDbContext<CoachLogDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(CoachLogDbContext)));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                 {
                     options.TokenValidationParameters = new()
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateIssuerSigningKey = true,
                         ValidateLifetime = false,
                         IssuerSigningKey = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes(configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>().SecretKey))
                     };

                     options.Events = new JwtBearerEvents
                     {
                         OnMessageReceived = context =>
                         {
                             context.Token = context.Request.Cookies["token"];

                             return Task.CompletedTask;
                         }
                     };
                 });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("Admin", "true");
                });

                options.AddPolicy("Coach", policy =>
                {
                    policy.RequireClaim("Coach", "true");
                });
            });
        }
    }
}
