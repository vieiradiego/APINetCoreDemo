using APINetCoreDemo.Model.Context;
using APINetCoreDemo.Services;
using APINetCoreDemo.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace APINetCoreDemo
{
    public class Startup
    {
        public IHostEnvironment _environment { get; }
        public IConfiguration _configuration { get; }
        private ILogger _logger;
        public Startup(IConfiguration configuration, IHostEnvironment environment, ILogger <Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionStriong"];

            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));
            
            // Migration do Banco de Dados
            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new[] { "db/migrations" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {

                    _logger.LogCritical("Database migration failed ",ex);
                    throw;
                }

            }

            services.AddApiVersioning();
            services.AddControllers();
            
            // Dependency
            services.AddScoped<IPersonService, PersonServiceImpl>();
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IGroupService, GroupServiceImpl>();
            services.AddScoped<IDomainService, DomainServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
