using BaseApiWithSwagger.Actions;
using BaseApiWithSwagger.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace BaseApiWithSwagger
{
    public class Startup
    {
        private const string InMemoryDbIndicator = "InMemory";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddTransient<IDummyActions, DummyActions>();

                services.AddDbContext<Context>(SetDbContext);

                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseApiWithSwagger", Version = "v1" });
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseMvc();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Base Api With Swagger V1");
                    c.RoutePrefix = string.Empty;
                });

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
                    if (!context.Database.IsInMemory())
                    {
                        context.Database.Migrate();
                    }
                    else
                    {
                        context.Seed();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetDbContext(DbContextOptionsBuilder options)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            if (connection.Equals(InMemoryDbIndicator, StringComparison.InvariantCultureIgnoreCase))
            {
                options.UseInMemoryDatabase(InMemoryDbIndicator);
            }
            else
            {
                //Data Source=Stats.db
                options.UseSqlite(connection);
            }
        }
    }
}
