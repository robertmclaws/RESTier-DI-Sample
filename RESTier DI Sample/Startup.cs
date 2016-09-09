using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RESTier_DI_Sample.Startup))]

namespace RESTier_DI_Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }

        // @robertmclaws: If you create a new AspNetCore project, this function gets called by the framework
        //                to register services for the application. THIS is where RESTier would be registered
        //                in a .NET Core app.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SampleModelBuilder>();
            // @robertmclaws: THIS is where RESTier should fill in the gaps from what the user has already registered, so that
            //                the system can work automagically. No ridiculousness. Simple, clean, effective.
            //EntityFrameworkApi<SampleDbContext>.RegisterDependencies(services);
        }


    }
}
