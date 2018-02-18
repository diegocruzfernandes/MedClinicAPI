using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MedServer.Api.Shared
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Swashbuckle.AspNetCore.Swagger.ApiKeyScheme()
                {
                    Description = "Authorization format : Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0.2",
                    Title = "MedClinic",
                    Description = "Servidor API para o controle de consultórios médicos, permitindo cadastro e controle de consultas, - Projeto de Teste para MazzaTech/Fevereiro de 2018",
                    Contact = new Contact { Name = "MedClinic-Github", Email = "diegocruzfernandes@hotmail.com", Url = "https://github.com/diegocruzfernandes/MedClinicAPI" },
                    License = new License { Name = "MedClinic - Application", Url = "https://example.com/license" }

                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedClinic");
                c.ConfigureOAuth2("swaggerui", "", "", "Swagger UI");
            });
            return app;
        }
    }
}
