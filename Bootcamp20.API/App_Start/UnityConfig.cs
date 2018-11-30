using Bootcamp20.API.BussinessLogic.Interface;
using Bootcamp20.API.BussinessLogic.Interface.Master;
using Bootcamp20.API.Common.Repository;
using Bootcamp20.API.Common.Repository.Master;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Bootcamp20.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<ISuplierService, SupplierService>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}