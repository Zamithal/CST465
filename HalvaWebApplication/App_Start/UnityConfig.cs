using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

using HalvaWebApplication.Code.Interfaces;
using HalvaWebApplication.Code.Repositories;

namespace HalvaWebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IDataEntityRepository<HalvaWebApplication.Code.DataObjects.BlogPost>, BlogFileRepository>();

			//IDENTITY
			container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
			container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>(new HierarchicalLifetimeManager());
			container.RegisterType<AccountController>(new InjectionConstructor());

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
    }
}