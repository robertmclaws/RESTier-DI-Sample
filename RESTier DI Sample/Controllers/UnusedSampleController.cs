using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.Restier.Core;
using Microsoft.Restier.Core.Model;
using Microsoft.Restier.Providers.EntityFramework;
using RESTier_DI_Sample.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.OData.Builder;

namespace RESTier_DI_Sample.Controllers
{

    // @robertmclaws: This is *NOT* how DI is supposed to work. Classes don't register *themselves*... 
    //                They are supposed to be registered by their container. That's what makes them more
    //                testable than other solutions. If a class is registering itself, what is the point?
    public class UnusedSampleController : EntityFrameworkApi<SampleDbContext>
    {

        protected static new IServiceCollection ConfigureApi(Type apType, IServiceCollection services)
        {
            return EntityFrameworkApi<SampleDbContext>.ConfigureApi(apType, services)
                .AddService<IModelBuilder, SpatialModelExtender>();
        }

        // @robertmclaws: Putting private classes inside public classes is a *horrible* practice.
        //                One class per file. No exceptions.
        private class SpatialModelExtender : IModelBuilder
        {
            public Task<IEdmModel> GetModelAsync(ModelContext context, CancellationToken cancellationToken)
            {
                var builder = new ODataConventionModelBuilder();

                //builder.EntitySet<Person>("People");
                //var entityConfiguration = builder.StructuralTypes.First(t => t.ClrType == typeof(Person));
                //entityConfiguration.AddProperty(typeof(Person).GetProperty("PointLocation"));
                //entityConfiguration.AddProperty(typeof(Person).GetProperty("LineString"));
                //entityConfiguration.AddProperty(typeof(Person).GetProperty("FullName"));

                //var person = builder.EntityType<Person>();
                //person.Ignore(t => t.DbLocation);
                //person.Ignore(t => t.DbLineString);
                //person.Ignore(t => t.FirstName);
                //person.Ignore(t => t.LastName);
                return Task.FromResult(builder.GetEdmModel());
            }
        }

        // @robertmclaws: Constructor injection is supposed to dump in the services you need to make the class work,
        //                NOT inject the service container to manipulate. This is totally wrong.
        public UnusedSampleController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

    }

}