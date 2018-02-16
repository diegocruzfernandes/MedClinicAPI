using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedServer.Api.Security
{
    public class JwtAuthenticationOptions
    {
        public static void Configure(IServiceCollection services, IConfiguration config)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
                options.AddPolicy("Doctors", policy => policy.RequireClaim("medclinic", "doctor"));
                options.AddPolicy("Secretaries", policy => policy.RequireClaim("medclinic", "secretary"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(options =>
                     {
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidateLifetime = true,
                             ValidateIssuerSigningKey = true,
                             ValidIssuer = config["issuer"],
                             ValidAudience = config["audience"],
                             IssuerSigningKey = JwtSecurityKey.Create(config["secretyKey"])
                         };

                         options.Events = new JwtBearerEvents
                         {
                             OnAuthenticationFailed = context =>
                             {
                                 Console.BackgroundColor = ConsoleColor.Red;
                                 Console.ForegroundColor = ConsoleColor.Black;
                                 Console.WriteLine("OnAuthenticationFailed: ");
                                 Console.ResetColor();
                                 Console.WriteLine(context.Exception.Message);
                                 return Task.CompletedTask;
                             },
                             OnTokenValidated = context =>
                             {
                                 Console.BackgroundColor = ConsoleColor.Green;
                                 Console.ForegroundColor = ConsoleColor.Black;
                                 Console.WriteLine("OnTokenValidated: ");
                                 Console.ResetColor();
                                 Console.WriteLine(context.SecurityToken);
                                 return Task.CompletedTask;
                             }
                         };
                     });
        }

    }
}
