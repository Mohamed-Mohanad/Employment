using Employment.Application.Abstractions;
using Employment.Infrastructure.BackgroundJobs;
using Employment.Infrastructure.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Employment.Infrastructure
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInfrastructureStrapping(this IServiceCollection services)
        {
            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            services.AddScoped<VacancyArchiverJob>();

            return services;
        }
    }
}
