using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using RESTier_DI_Sample.Models;
using System.Web.Http;

namespace RESTier_DI_Sample
{
    public static class WebApiConfig
    {


        public static async void Register(HttpConfiguration config)
        {
            // Robert McLaws: I'm not sure why you guys put the call below in the samples and docs, because it doesn't work.
            //                Also: your samples forgot the includes, and you put extension methods in the namespace of the
            //                classes you are extending.

            //config.Filter().Expand().Select().OrderBy().MaxTop(null).Count();
            await config.MapRestierRoute<EntityFrameworkApi<SampleDbContext>>("default", "", new RestierBatchHandler(GlobalConfiguration.DefaultServer));
        }

    }

}