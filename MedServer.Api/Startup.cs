using MedServer.Domain.Repositories;
using MedServer.Domain.Services;
using MedServer.Infra.Context;
using MedServer.Infra.Repositories;
using MedServer.Infra.Transactions;
using MedServer.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            services.AddMvc()
             .AddJsonOptions(opt =>
             {
                 opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
             });     

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

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
        }

        public static IConfigurationRoot GetConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!String.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();
            
            return builder.Build();
        }
    }
}
