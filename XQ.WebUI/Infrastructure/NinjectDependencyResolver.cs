using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Moq;
using XQ.Domain.Abstract;
using XQ.Domain.Concrete;
using System.Web.Mvc;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Infrastructure.Concrete;

namespace XQ.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel KernelParam)
        {
            kernel = KernelParam;
            AddBinding();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object>GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBinding()
		{
			kernel.Bind<IAuthProvider>().To<AuthProvider>();
			kernel.Bind<IMenuRepository>().To<MenuRepository>();
			kernel.Bind<IReportInitiator>().To<ReportInitiator>();
			kernel.Bind<IEntityRepository>().To<EntityRepository>();

			kernel.Bind<IWorksRepository>().To<WorksRepository>();
			kernel.Bind<IStaffsRepository>().To<StaffsRepository>();
			kernel.Bind<IProjectsRepository>().To<ProjectsRepository>();
            kernel.Bind<ICustomersRepository>().To<CustomersRepository>();
            kernel.Bind<IWorkReportRepository>().To<WorkReportRepository>();
			kernel.Bind<IDepartmentsRepository>().To<DepartmentsRepository>();
        }
    }
}