using Core.Domain.Context;
using Core.Interfaces.IRepository;
using Infrastructure.Data.Repository;
using Services.BaseService;
using Services.BaseService.CoreService.User;
using Services.Interfaces.IBaseServices;
using Services.InterFaces.ICoreService.User;
using System.Data.Entity;
using System.Web.Mvc;
using UnitOfWork.Interfaces.IUnitOfWork;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Web.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
         
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType<IUnitOfWork, UnitOfWork.Data.UnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}