using ManageAmericaAPI.Data;
using ManageAmericaAPI.Data.Services;
using ManageAmericaAPI.DataAccess.Repository;
using ManageAmericaAPI.DataAccess.Repository.Availablity;
using ManageAmericaAPI.DataAccess.Repository.Manager;
using ManageAmericaAPI.DataAccess.Repository.Property;
using ManageAmericaAPI.DataAccess.Repository.ScheduledTour;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ManageAmericaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>

        public void ConfigureServices(IServiceCollection services)
        {
            /// <summary>
            ///  CongigurationOfDbContext
            /// </summary>

            services.AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));


            /// <summary>
            ///  AddingServices
            /// </summary>

            services.AddTransient<ManagerService>();
            services.AddTransient<AvailablityService>();
            services.AddTransient<PropertyService>();
            services.AddTransient<ScheduledTourService>();

            /// <summary>
            ///  Repository
            /// </summary>

            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<IAvailablityRepository, AvailablityRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IScheduledTourRepository, ScheduledTourRepository>();

            /// <summary>
            ///  AddingSwagger
            /// </summary>

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ManageAmericaAPI",
                    Version = "v2",
                    Description = "Developing phase",
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

          
                
            services.AddCors();


        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManageAmericaAPI v1"));

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseMiddleware(typeof(ExceptionHandling));

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
