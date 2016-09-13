using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using RESTier_DI_Sample.Models;
using System.Web.Http;
using System.Web.OData.Extensions;

namespace RESTier_DI_Sample
{
    public static class WebApiConfig
    {

        public static async void Register(HttpConfiguration config)
        {
            // Robert McLaws: Your samples forgot the includes, and you put extension methods in the namespace of the
            //                classes you are extending.
            config.Filter().Expand().Select().OrderBy().MaxTop(null).Count();
            await config.MapRestierRoute<EntityFrameworkApi<SampleDbContext>>("default", "", new RestierBatchHandler(GlobalConfiguration.DefaultServer));
        }

    }

}