using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.BL.Contracts;
using Taller.BL.Implementations;
using Taller.DAL.Models;
using Taller.DAL.Repository.Contracts;
using Taller.DAL.Repository.Implements;

namespace Taller.API
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
            services.AddControllers();

            // Inyección de dependecias
            // Contexto
            services.AddDbContext<tallerContext>(opts => opts.UseMySql(Configuration["ConnectionString:TallerDB"]));

            // Interfaz - Clase
            // Usuario (Empleado)
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            // Propuesta
            services.AddScoped<IPropositionBL, PropositionBL>();
            services.AddScoped<IRepositoryProposition, RepositoryProposition>();
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
