using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using pdouelle.GenericController.Api.Debug.Data;
using pdouelle.GenericMediatR;

namespace pdouelle.GenericController.Api.Debug
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddGenericMediatR(typeof(Startup).Assembly);
            services.AddGenericControllers(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);

            var connectionString = Configuration.GetConnectionString("Database");
            services.AddDbContext<DatabaseService>(options => { options.UseSqlServer(connectionString); });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "GenericControllerTest", Version = "v1"});
                c.ResolveConflictingActions(resolver => resolver.First());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericControllerTest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureContainer(typeof(DatabaseService));
        }
    }
}