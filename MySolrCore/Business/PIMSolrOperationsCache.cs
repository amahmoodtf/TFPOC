using SolrNet;
using SolrNet.Impl;
using System;
using System.Diagnostics;
using System.Net;
using System.Web.UI.WebControls;


namespace MySolrCore
{
    public static class PIMSolrOperationsCache<T>
                where T : new()
    {
        private static string recipeCollection = PIMSolrCore.PIMSolrRecipeItemsCollection; //"recipeItems";

        public static ISolrOperations<T> GetSolrOperations(string core)
        {
            //use latest tls version
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            //Trust All certificates
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            if (core == recipeCollection)
            {
                return (ISolrOperations<T>)GetSolrRecipeOperations(core);
            }
            else
            {
                return (ISolrOperations<T>)GetSolrProductOperations(core);
            }

        }
        public static ISolrOperations<SolrProduct> GetSolrProductOperations(string core)
        {
            //string solrUrl = Path.Combine(Helpers.Config.SolrMasterUrl, core).Replace("\\", "/");
            if (core == PIMSolrCore.PIMSolrProductCollection)
            {
                try
                {
                    return SolrConnections.SolrProductConnection.Resolve<ISolrOperations<SolrProduct>>();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Solr init in GetSolrProductOperations() due to error [{e.ToString()}]");


                    var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                    connectionFactory.AddIndex<SolrProduct>(Config.PIMSolrProductCollection);
                    connectionFactory.Start<SolrProduct>();
                    SolrConnections.SolrProductConnection = connectionFactory;
                    return connectionFactory.Resolve<ISolrOperations<SolrProduct>>();

                }
            }
            else
            {
                Debug.WriteLine("Solr Core requested has not been implemented " + core);
                throw new NotImplementedException("Solr Core requested has not been implemented " + core);
            }
        }
        public static ISolrOperations<SolrRecipeItem> GetSolrRecipeOperations(string core)
        {
            if (core == PIMSolrCore.PIMSolrRecipeItemsCollection)
            {
                try
                {
                    return SolrConnections.SolrProductConnection.Resolve<ISolrOperations<SolrRecipeItem>>();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Solr init in GetSolrRecipeOperations() due to error [{e.ToString()}]");


                    var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                    connectionFactory.AddIndex<SolrRecipeItem>(Config.PIMSolrRecipeItemsCollection);
                    connectionFactory.Start<SolrRecipeItem>();
                    SolrConnections.SolrProductConnection = connectionFactory;
                    return connectionFactory.Resolve<ISolrOperations<SolrRecipeItem>>();

                }
            }
            else
            {
                Debug.WriteLine("Solr Core requested has not been implemented " + core);
                throw new NotImplementedException("Solr.Dup Core requested has not been implemented " + core);
            }
        }

        public static SolrQueryExecuter<T> GetSolrSuggestExecuter(string core)
        {
            if (core == recipeCollection)
            {
                try
                {
                    return SolrConnections.SolrProductConnection.Resolve<ISolrOperations<SolrRecipeItem>>() as SolrQueryExecuter<T>; ;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Solr init in GetSolrRecipeExecuter() due to error [{e.ToString()}]");


                    var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                    connectionFactory.AddIndex<SolrRecipeItem>(Config.PIMSolrRecipeItemsCollection);
                    connectionFactory.Start<SolrRecipeItem>();
                    SolrConnections.SolrProductConnection = connectionFactory;
                    return connectionFactory.Resolve<ISolrOperations<SolrRecipeItem>>() as SolrQueryExecuter<T>; ;

                }
            }
            else
            {
                try
                {
                    return SolrConnections.SolrProductConnection.Resolve<ISolrOperations<SolrProduct>>() as SolrQueryExecuter<T>; ;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Solr init in GetSolrProductExecuter() due to error [{e.ToString()}]");


                    var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                    connectionFactory.AddIndex<SolrProduct>(Config.PIMSolrProductCollection);
                    connectionFactory.Start<SolrProduct>();
                    SolrConnections.SolrProductConnection = connectionFactory;
                    return connectionFactory.Resolve<ISolrOperations<SolrProduct>>() as SolrQueryExecuter<T>; ;

                }
            }
        }
    }
}