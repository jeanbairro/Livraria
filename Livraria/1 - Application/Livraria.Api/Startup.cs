using Livraria.Database.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Livraria.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            Migrate(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ILivrariaContext, LivrariaContext>(opts =>
            {
                var connectionString = _configuration.GetConnectionString(nameof(LivrariaContext));
                opts.UseNpgsql(connectionString, x => x.MigrationsAssembly(typeof(LivrariaContext).Assembly.FullName));
            });
        }

        public void Migrate(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ILivrariaContext>();
            context.Database.Migrate();
        }
    }
}