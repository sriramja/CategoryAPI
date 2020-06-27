using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TariningApp.Service.Contracts;
using TariningApp.Service.Implementation;
using TrainingApp.DataAccess;
using TrainingApp.DataAccess.Contract;
using TrainingApp.DataAccess.Implementation;
using TrainingApp.DataAccess.UnitOfWork.Contract;
using TrainingApp.DataAccess.UnitOfWork.Implementation;
using TrainingApp.Domain;

namespace TrainingApp
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
            services.AddDbContext<ApplicationContext>(options =>
            {
            options.UseSqlServer(Configuration.GetConnectionString("myconn"),

              x => x.MigrationsAssembly("TrainingApp.DataAccess"));
            });
            
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWorkRepo<>));
            services.AddScoped<ICategoryService, CategoryRepository>();
            services.AddScoped<ApplicationContext>();
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
