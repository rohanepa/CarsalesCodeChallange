using Microsoft.Extensions.DependencyInjection;

namespace CarSales.CodingChallenge.Api.Config
{
    public class CorsConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CodingChallengeCorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }
    }
}
