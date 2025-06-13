using Application.Commands;
using CommandsMediatR = Application.CommandsMediatR;
using Application.Interfaces;
using Application.Queries;
using QueriesMediatR = Application.QueriesMediatR;

using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test CQRS Pattern!");

            #region MediatR
            RunCQRSMediatR();
            #endregion

            #region CQRS Pattern
            RunCQRS();
            #endregion
            
            Console.ReadKey();   

        }


        private static void RunCQRSMediatR()
        {
            try
            {
                var mediator = BuildMediator();

                //Add new Product
                var product = new CommandsMediatR.AddNewProductCommand { Id = Guid.NewGuid(), Name = "iPhone 11", Description = "Apple iphone 11" };
                var res = mediator.Send(product);

                //Update Product Unit Price
                mediator.Send(new CommandsMediatR.UpdateProductUnitPriceCommand { Id = product.Id, UnitPrice = 200 });

                //Update Product Current Stock
                mediator.Send(new CommandsMediatR.UpdateProductCurrentStockCommand { Id = product.Id, CurrentStock = 600 });


                //Fine Products By Name
                var productsByName = mediator.Send(new QueriesMediatR.GetProductsByNameQuery { Name = "iPhone" });
                foreach (var item in productsByName.Result)
                {
                    Console.WriteLine(item.ToString());
                }

                //Fine Products By Name
                var outOfStockProducts = mediator.Send(new QueriesMediatR.FindOutOfStockProductsQuery());
                foreach (var item in outOfStockProducts.Result)
                {
                    Console.WriteLine(item.ToString());
                }

                //Delete Product
                mediator.Send(new CommandsMediatR.DeleteProductCommand { Id = product.Id });

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        static void RunCQRS()
        {
            var serviceProvider = BuildServiceProvider();

            try
            {
                var commandDispatcher = new CommandDispatcher(serviceProvider);
                var queryDispatcher = new QueryDispatcher(serviceProvider);

                //Add new Product
                var product = new AddNewProductCommand { Id = Guid.NewGuid(), Name = "iPhone 11", Description = "Apple iphone 11" };
                commandDispatcher.Send(product);

                //Update Product Unit Price
                commandDispatcher.Send(new UpdateProductUnitPriceCommand { Id = product.Id, UnitPrice = 800 });

                //Update Product Current Stock
                commandDispatcher.Send(new UpdateProductCurrentStockCommand { Id = product.Id, CurrentStock = 500 });


                //Fine Products By Name
                var productsByName = queryDispatcher.Send(new GetProductsByNameQuery { Name = "iPhone" });
                foreach (var item in productsByName)
                {
                    Console.WriteLine(item.ToString());
                }

                //Fine Products By Name
                var outOfStockProducts = queryDispatcher.Send(new FindOutOfStockProductsQuery());
                foreach (var item in outOfStockProducts)
                {
                    Console.WriteLine(item.ToString());
                }

                //Delete Product
                commandDispatcher.Send(new DeleteProductCommand { Id = product.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }


        #region Private Builders
        private static IServiceProvider BuildServiceProvider()      
        {
            return new ServiceCollection()
                    // Add data base context
                    .AddSingleton<IApplicationContext, ApplicationContext>()
                    // Add commands handlers
                    .AddScoped<ICommandHandler<AddNewProductCommand>, AddNewProductCommandHandler>()
                    .AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>()
                    .AddScoped<ICommandHandler<UpdateProductCurrentStockCommand>, UpdateProductCurrentStockCommandHandler>()
                    .AddScoped<ICommandHandler<UpdateProductUnitPriceCommand>, UpdateProductUnitPriceCommandHandler>()
                    // Add queries handlers
                    .AddScoped<IQueryHandler<FindOutOfStockProductsQuery>, FindOutOfStockProductsQueryHandler>()
                    .AddScoped<IQueryHandler<GetProductsByNameQuery>, GetProductsByNameQueryHandler>()

                    //Creat service
                    .BuildServiceProvider();
        }

        //https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.AspNetCore/Program.cs
        private static IMediator BuildMediator()
        {
            
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationContextInMemoryDB>(opt => opt.UseInMemoryDatabase(databaseName:"CQRS-MediatR"), ServiceLifetime.Singleton);
            services.AddSingleton<IApplicationContextInMemoryDB>(p => p.GetService<ApplicationContextInMemoryDB>());
            services.AddMediatR(new Type[] { typeof(CommandsMediatR.AddNewProductCommand),
            typeof(CommandsMediatR.UpdateProductUnitPriceCommand),
            typeof(CommandsMediatR.UpdateProductCurrentStockCommand),
            typeof(QueriesMediatR.GetProductsByNameQuery),
            typeof(QueriesMediatR.FindOutOfStockProductsQuery)
            
            });


            var serilogLogger = new LoggerConfiguration()
                        .WriteTo.File($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}Logs{Path.DirectorySeparatorChar}application.log")
                        .CreateLogger();

            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddSerilog(logger: serilogLogger, dispose: true);
            });


            var provider = services.BuildServiceProvider();
            return provider.GetRequiredService<IMediator>();
        }
        #endregion

        


    }
}
