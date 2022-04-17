using AareonTechnicalTest.DataLogger;
using AareonTechnicalTest.DataServices;
using AareonTechnicalTest.DataServices.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoviesApi.Middleware;
using System.Reflection;


namespace AareonTechnicalTest
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
            
            // mediatR config
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // automapper configuration
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // repository class
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            // HttpContext
            //services.AddScoped<HttpContext>();
            
            // datalogger
            services.AddScoped<IDataLoggerRepository, SqlLiteDataLogger>();

            // fluent validation 
            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            services.AddDbContext<ApplicationContext>(c => c.UseSqlite());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AareonTechnicalTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // global error handler & logging
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AareonTechnicalTest v1"));
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
