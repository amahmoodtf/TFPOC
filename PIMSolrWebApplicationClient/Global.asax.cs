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
                var connectionFactory1 = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);

                connectionFactory1.AddIndex<SolrProduct>("products");                
                connectionFactory1.Start<SolrProduct>();
                SolrConnections.SolrProductConnection = connectionFactory1;

                var connectionFactory2 = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                connectionFactory2.AddIndex<SolrRecipeItem>("recipeItems");
                connectionFactory2.Start<SolrRecipeItem>();
                SolrConnections.SolrRecipeConnection = connectionFactory2;

                
            }
            catch
            {
                // Log the exception or handle it as needed

            }
        }
    }
}