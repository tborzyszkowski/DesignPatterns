using CarsCms.ApiConsumer;
using CarsCms.ApiConsumer.Interfaces;
using CarsCms.Builders;
using CarsCms.Interfaces;
using CarsCms.Repository.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarsCms.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CarsCms.App_Start.NinjectWebCommon), "Stop")]

namespace CarsCms.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Repository;
    using BusinessLogic;
    using ApiConsumer.Adapter;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //repo
            kernel.Bind<ICarsRepository>().To<CarsRepository>();
            kernel.Bind<ICarBusinessLogic>().To<CarBusinessLogic>();
            kernel.Bind<IEngineRepository>().To<EngineRepository>();
            //client
            kernel.Bind<IEmailClient>().To<EmailClient>();
            kernel.Bind<IPerformanceClient>().To<PerformaceClient>();
            //adapters
            kernel.Bind<IEmailAdapter>().To<EmailAdapter>();
            //builders
            kernel.Bind<ICarVMBuilder>().To<CarVMBuilder>();
        }        
    }
}
