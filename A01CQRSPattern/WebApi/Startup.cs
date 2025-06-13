using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Interfaces;
using Application.Queries;
using Infrastructure.Persistence;
using CommandsMediatR = Application.CommandsMediatR;
using QueriesMediatR = Application.QueriesMediatR;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WebApi
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

            services.AddHttpContextAccessor();

            //CQRS PAttern
            services.AddSingleton<IApplicationContext, ApplicationContext>()
                    //Add commands handlers
                    .AddScoped<ICommandHandler<AddNewProductCommand>, AddNewProductCommandHandler>()
                    .AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>()
                    .AddScoped<ICommandHandler<UpdateProductCurrentStockCommand>, UpdateProductCurrentStockCommandHandler>()
                    .AddScoped<ICommandHandler<UpdateProductUnitPriceCommand>, UpdateProductUnitPriceCommandHandler>()
                    // Add queries handlers
                    .AddScoped<IQueryHandler<FindOutOfStockProductsQuery>, FindOutOfStockProductsQueryHandler>()
                    .AddScoped<IQueryHandler<GetProductsByNameQuery>, GetProductsByNameQueryHandler>()

                    .AddScoped<ICommandDispatcher, CommandDispatcher>()
                    .AddScoped<IQueryDispatcher, QueryDispatcher>();

            //CQRS Pattern with MediatR

            services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<ApplicationContextInMemoryDB>(opt => opt.UseInMemoryDatabase(databaseName: "CQRS-MediatR"), ServiceLifetime.Singleton)
                    .AddSingleton<IApplicationContextInMemoryDB>(p => p.GetService<ApplicationContextInMemoryDB>());
            services.AddMediatR(new Type[] 
            { 
                typeof(CommandsMediatR.AddNewProductCommand),
                typeof(CommandsMediatR.UpdateProductUnitPriceCommand),
                typeof(CommandsMediatR.UpdateProductCurrentStockCommand),
                typeof(QueriesMediatR.GetProductsByNameQuery),
                typeof(QueriesMediatR.FindOutOfStockProductsQuery)
            });

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
