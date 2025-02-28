using Microsoft.AspNetCore.Identity;
using TaekwondoCompetition.Core.Entities;
using TaekwondoCompetition.Persistence.Services;
using TaekwondoCompetition.Application.Services;
using TaekwondoCompetition.Application.Interfaces.Services;
using TaekwondoCompetition.Application.Interfaces.Persistence.Services;
using TaekwondoCompetition.Persistence.Services.Authentication;

namespace TaekwondoCompetition.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: policyName,
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin();
                    corsPolicyBuilder.AllowAnyMethod();
                    corsPolicyBuilder.AllowAnyHeader();
                });
        });
        return services;
    }

    public static void AddPersistenceLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(
            configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<ITokenProvider, TokenProvider>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IPasswordHelper, PasswordHelper>();

        services.AddScoped<IAuthenticationManager, AuthenticationManager>();
    }

    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}