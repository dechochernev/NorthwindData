using Access.EntityFramework;
using Access.EntityFramework.CommandHandlers;
using Access.EntityFramework.Models;
using Access.EntityFramework.QueryHandlers;
using BusinessLayer.Access.Commands;
using BusinessLayer.Access.Queries;
using BusinessLayer.Usecases;
using BusinessLayer.Usecases.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NorthwindApp
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
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            //Commands
            services.AddScoped<IUpdateEmployeeNotesCommand, UpdateEmployeeNotesCommandHandler>();

            //Queries
            services.AddScoped<IGetAllRegionsQuery, GetAllRegionsQueryHandler>();
            services.AddScoped<IGetTerritoriesForRegionQuery, GetTerritoriesForRegionQueryHandler>();
            services.AddScoped<IGetEmployeesForTerritoryQuery, GetEmployeesForTerritoryQueryHandler>();
            services.AddScoped<IGetMostExpensiveProductsQuery, GetMostExpensiveProductsQueryHandler>();

            //Usecases
            services.AddScoped<IGetAllRegions, GetAllRegions>();
            services.AddScoped<IGetTerritoriesForRegion, GetTerritoriesForRegion>();
            services.AddScoped<IGetEmployeesForTerritory, GetEmployeesForTerritory>();
            services.AddScoped<IUpdateEmployeeNotes, UpdateEmployeeNotes>();
            services.AddScoped<IGetMostExpensiveProducts, GetMostExpensiveProducts>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
