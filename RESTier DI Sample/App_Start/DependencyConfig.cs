using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Restier.Core.Model;
using Microsoft.Restier.Providers.EntityFramework;
using RESTier_DI_Sample.Models;
using System.Reflection;
using System.Web.Http;

namespace RESTier_DI_Sample
{

    // @robertmclaws: This class demonstrates how you would register dependencies with Autofac, another DI system
    //                That is compatible with the DI library you are using.
    public static class DependencyConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register dependencies.
            RegisterDependencies(builder);

            // Build the container.
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            config.DependencyResolver = resolver;
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<SampleModelBuilder>().As<IModelBuilder>().SingleInstance();
            // @robertmclaws: THIS is where RESTier should fill in the gaps from what the user has already registered, so that
            //                the system can work automagically. No ridiculousness. Simple, clean, effective.
            //EntityFrameworkApi<SampleDbContext>.RegisterDependencies(builder);
        }


    }
}