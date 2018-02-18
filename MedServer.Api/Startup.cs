using MedServer.Api.Security;
using MedServer.Api.Shared;
using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Domain.Shared;
using MedServer.Infra.Context;
using MedServer.Infra.Repositories;
using MedServer.Infra.Transactions;
using MedServer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace MedServer.Api
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
             .AddJsonOptions(opt =>
             {
                 opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 opt.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                 opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
             });

            JwtAuthenticationOptions.Configure(services, Configuration);                                

            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IUow, Uow>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ISecretaryService, SecretaryService>();
            services.AddTransient<ISecretaryRepository, SecretaryRepository>();
            services.AddTransient<ITypeConsultRepository, TypeConsultRepository>();
            services.AddTransient<ITypeConsultService, TypeConsultService>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IScheduleService, ScheduleService>();

            services.AddSwaggerDocumentation();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                .Build());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            app.UseSwagger();

            app.UseSwaggerDocumentation();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                builder.AddUserSecrets<Startup>();
            }

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseMvc();

            ConfigsAppSettings.SQLConnectionString = Configuration.GetConnectionString("myConnectionString");   
        }        
    }
}
