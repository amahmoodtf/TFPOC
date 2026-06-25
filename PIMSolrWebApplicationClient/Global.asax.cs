using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using MySolrCore;

namespace SolrWebApplicationClient
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                var connectionFactory1 = new SolrConnectionFactory(true, "aci-pimsolrc01.teleflora.org:2181", "dev-user1", "SolrRocks");

                connectionFactory1.AddIndex<SolrProduct>("product");                
                connectionFactory1.Start<SolrProduct>();
                SolrConnections.SolrProductConnection = connectionFactory1;

                var connectionFactory2 = new SolrConnectionFactory(true, "aci-pimsolrc01.teleflora.org:2181", "dev-user1", "SolrRocks");
                connectionFactory2.AddIndex<SolrRecipeItem>("recipeitem");
                connectionFactory2.Start<SolrRecipeItem>();
                SolrConnections.SolrRecipeConnection = connectionFactory2;

                
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed

            }
        }
    }
}