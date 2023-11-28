using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TaskDbContext>();

            services.AddTransient<IPriorityRepository<Priority>, PriorityRepository>();
            services.AddTransient<ITaskRepository<Models.Task>, TaskRepository>();
            services.AddTransient<IWorkerRepository<Worker>, WorkerRepository>();

            services.AddTransient<IPriorityLogic, PriorityLogic>();
            services.AddTransient<ITaskLogic, TaskLogic>();
            services.AddTransient<IWorkerLogic, WorkerLogic>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
