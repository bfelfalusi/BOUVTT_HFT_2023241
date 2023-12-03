using BOUVTT_HFT_2023241.Logic.Classes;
using BOUVTT_HFT_2023241.Logic.Interfaces;
using BOUVTT_HFT_2023241.Models;
using BOUVTT_HFT_2023241.Repository;
using BOUVTT_HFT_2023241.Repository.Interfaces;
using BOUVTT_HFT_2023241.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOUVTT_HFT_2023241.Endpoint
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

            services.AddTransient<PlayerDbContext>();

            services.AddTransient<IRepository<Player>, PlayerRepository>();
            services.AddTransient<IRepository<Team>, TeamRepository>();
            services.AddTransient<IRepository<Coach>, CoachRepository>();
            services.AddTransient<IRepository<Training>, TrainingRepository>();

            services.AddTransient<IPlayerLogic, PlayerLogic>();
            services.AddTransient<ITeamLogic, TeamLogic>();
            services.AddTransient<ICoachLogic, CoachLogic>();
            services.AddTransient<ITrainingLogic, TrainingLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BOUVTT_HFT_2023241.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BOUVTT_HFT_2023241.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
