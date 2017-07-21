[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ORA.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ORA.App_Start.NinjectWebCommon), "Stop")]

namespace ORA.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Lib.Interfaces;
    using Lib.InterfacesLogic;
    using BusinessLogic.ORALogic;
    using Repository.Repositories;

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
            kernel.Bind<IAssessmentLogic>().To<AssessmentLogic>();
            kernel.Bind<IAssessmentRepository>().To<AssessmentRepository>();
            kernel.Bind<IAssignmentLogic>().To<AssignmentLogic>();
            kernel.Bind<IAssignmentRepository>().To<AssignmentRepository>();
            kernel.Bind<IClientLogic>().To<ClientLogic>();
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<IEmployeeLogic>().To<EmployeeLogic>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IKPILogic>().To<KPILogic>();
            kernel.Bind<IKPIRepository>().To<KPIRepository>();
            kernel.Bind<IPositionLogic>().To<PositionLogic>();
            kernel.Bind<IPositionRepository>().To<PositionRepository>();
            kernel.Bind<IProjectLogic>().To<ProjectLogic>();
            kernel.Bind<IProjectRepository>().To<ProjectRepository>();
            kernel.Bind<IRoleLogic>().To<RoleLogic>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ISprintLogic>().To<SprintLogic>();
            kernel.Bind<ISprintRepository>().To<SprintRepository>();
            kernel.Bind<IStoryLogic>().To<StoryLogic>();
            kernel.Bind<IStoryRepository>().To<StoryRepository>();
            kernel.Bind<ITeamLogic>().To<TeamLogic>();
            kernel.Bind<ITeamRepository>().To<TeamRepository>();
        }        
    }
}
