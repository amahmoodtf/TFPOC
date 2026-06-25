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
                var connectionFactory = new SolrConnectionFactory(true, "aci-mtfsolrc01.teleflora.org:2181", "dev-user1", "SolrRocks");
                connectionFactory.AddIndex<IndexItem>("myteleflora");
                connectionFactory.Start<IndexItem>();
                
                SolrConnections.SolrMYTFConnection = connectionFactory;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed

            }
        }
    }
}