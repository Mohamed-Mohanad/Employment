using Employment.Application.Behaviors;
using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.Types;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract;
using Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Types;
using Employment.Application.Features.Auth.Commands.Register.Abstract;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Employment.Application
{
    public static class Bootstrap
    {
        public static IServiceCollection AddApplicationStrapping(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            services.AddScoped<BaseRegister, EmployerRegisterType>();
            services.AddScoped<BaseRegister, ApplicantRegisterType>();

            services.AddScoped<BaseLogin, EmployerLoginType>();
            services.AddScoped<BaseLogin, ApplicantLoginType>();

            return services;
        }
    }
}
