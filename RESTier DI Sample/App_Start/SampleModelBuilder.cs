using Microsoft.OData.Edm;
using Microsoft.Restier.Core.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Web.OData.Builder;

namespace RESTier_DI_Sample
{


    // @robertmclaws: In real-world code, the model builder should be a separate public or internal class, so it can be 
    //                tested independently of aything else.
    //                This should probably actually inherit from the built-in model builder, allowing you to override only
    //                certain points in the process, instead of an all-or-nothing approach.
    public class SampleModelBuilder : IModelBuilder
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
}