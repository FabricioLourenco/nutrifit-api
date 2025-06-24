using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using nutrifit.Infra.Data.Context;
using Nutrifit.Infra.CrossCutting.DI;
using Nutrifit.Infra.CrossCutting.Handlers.Jwt;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Scrutor;
using System.Reflection;
using System.Text;
using Nutrifit.Infra.CrossCutting.Handlers.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Infra.Data.Data;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Service.Services;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.Data.Repositories;

namespace nutrifit.Infra.CrossCutting.Ioc
{
    public static class ContainerService
    {
        public static IServiceCollection AddApplicationCollections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNotificationHandlers();

            services.AddValidatorHandlers();

            services.RegisterAutomaticDependencies(assembly => assembly.FullName.StartsWith("Nutrifit.Service"));

            services.RegisterAutomaticDependencies(assembly => assembly.FullName.StartsWith("Nutrifit.Infra.Data"));

            services.AddValidators();

            services.AddJwtHandlers();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(ILoggerService), typeof(LoggerService));

            services.AddScoped(typeof(INotificationHandler), typeof(NotificationHandler));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<INutricionistaRepository, NutricionistaRepository>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();


            return services;
        }

        #region Automatic Dependencies

        public static void RegisterAutomaticDependencies(this IServiceCollection services, Func<Assembly, bool> assemblyFilter)
        {
            services.Scan(delegate (ITypeSourceSelector selector)
            {
                selector.FromApplicationDependencies(assemblyFilter).AddClasses(delegate (IImplementationTypeFilter typeFilter)
                {
                    typeFilter.AssignableTo<IScopedDependency>();
                }).AsImplementedInterfaces()
                    .WithScopedLifetime();
                selector.FromApplicationDependencies(assemblyFilter).AddClasses(delegate (IImplementationTypeFilter typeFilter)
                {
                    typeFilter.AssignableTo<ISingletonDependency>();
                }).AsImplementedInterfaces()
                    .WithSingletonLifetime();
                selector.FromApplicationDependencies(assemblyFilter).AddClasses(delegate (IImplementationTypeFilter typeFilter)
                {
                    typeFilter.AssignableTo<ITransientDependency>();
                }).AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        #endregion

        #region Authentication

        public static IServiceCollection AddApplicationAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtHandler:PrivateKey").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     RequireExpirationTime = true,
                     ClockSkew = TokenValidationParameters.DefaultClockSkew
                 };
             });
            return services;
        }

        #endregion

        #region Context

        public static IServiceCollection AddApplicationContext(this IServiceCollection services, string queryString)
        {
            services.AddDbContext<NutrifitContext>(
                options => options.UseNpgsql(queryString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
                }));
            return services;
        }

        #endregion

        #region JwtHandler

        public static IServiceCollection AddJwtHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IJwtHandler), typeof(JwtHandler));
            return services;
        }

        #endregion

        #region Notification

        public static IServiceCollection AddNotificationHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(INotificationHandler), typeof(NotificationHandler));
            return services;
        }

        #endregion

        #region Validators

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.Load("Nutrifit.Service"));
            return services;
        }

        #endregion

        #region Validator Handlers

        public static IServiceCollection AddValidatorHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IValidatorHandler), typeof(ValidatorHandler));
            return services;
        }

        #endregion
    }
}
