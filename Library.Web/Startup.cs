using TecnicalTestPersonas.Data;
using TecnicalTestPersonas.Data.Repository;
using TecnicalTestPersonas.Data.Repository.Interface;
using TecnicalTestPersonas.Domain.Service;
using TecnicalTestPersonas.Domain.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TecnicalTestPersonas.Web
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
            #region Sqlserver

            services.AddDbContext<DataContext>(cfg =>
                        {
                            cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                        });
            #endregion

            #region InjeccionDeDependencias
           
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ITerceroRepository, TerceroRepository>();

            services.AddTransient<ITercero, TerceroServices>();

            #endregion

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Tercero}/{action=Index}/{id?}");
            });
        }
    }
}
