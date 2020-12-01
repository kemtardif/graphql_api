using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GraphQL_API.Entities;
using GraphQL_API.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphiQl;
using GraphQL;
using GraphQL.Types;









namespace GraphQL_API
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
            var connectionMSQL = Configuration.GetConnectionString("MSQL");
            var connectionPSQL = Configuration.GetConnectionString("PSQL");

            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            
            services.AddScoped<BuildingType>();
            services.AddScoped<AddressType>();
            services.AddScoped<FactInterventionType>();
            services.AddScoped<EmployeeType>();
            services.AddScoped<BuildingsDetailType>();
            services.AddScoped<CustomerType>();
            services.AddScoped<BatteryType>();
            services.AddScoped<ColumnType>();
            services.AddScoped<ElevatorType>();


            services.AddScoped<FactInterventionQuery>();


            services.AddScoped<ISchema, GraphQLSchema>();
        
            services.AddDbContext<cindy_okino_dbContext>(options =>
                options.UseMySql(connectionMSQL));

           services.AddDbContext<cindy_okino_warehouseContext>(options => 
                options.UseNpgsql(connectionPSQL));

            services.AddControllers();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL_API v1"));
            }
            app.UseGraphiQl("/graphql");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

 

            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
