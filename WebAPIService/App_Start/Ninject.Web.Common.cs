[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebAPIService.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebAPIService.App_Start.NinjectWebCommon), "Stop")]

namespace WebAPIService.App_Start
{
    using BusinessLayer;
    using BusinessLayer.Interfaces;
    using DataAccessLayer;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Repositories;
    using DataAccessLayer.Repositories.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    using Ninject.Web.WebApi;
    using System.Web.Http;
    using log4net;
    using System.Data.Entity;
    using DataAccessLayer.DataModel;
    using System.Configuration;

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
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

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
            // kernel.Bind<DbContext>().To<UsersManagementEntities>().InTransientScope().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["UsersManagementEntities"].ConnectionString);

            //log4net...
            kernel.Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Request.Target.Member.DeclaringType)).InTransientScope();

            //User dependencies
            kernel.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            kernel.Bind<IUserBusiness>().To<UserBusiness>().InSingletonScope();
            kernel.Bind<IUsersData>().To<UsersData>().InSingletonScope();


            //Role dependencies
            kernel.Bind<IRoleRepository>().To<RolesRepository>().InRequestScope();
            kernel.Bind<IRoleBusiness>().To<RoleBusiness>().InRequestScope();
            kernel.Bind<IRoleData>().To<RoleData>().InRequestScope();
           
        }        

    }
}