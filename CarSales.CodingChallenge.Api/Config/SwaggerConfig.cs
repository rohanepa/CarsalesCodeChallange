using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CarSales.CodingChallenge.Api.Config
{
    public class SwaggerConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car sales coding challenge Api", Version = "v1.0" });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car sales coding challenge");
                c.OAuthClientId("swagger");
                c.OAuthAppName("Swagger UI");
            });
        }
    }
}
