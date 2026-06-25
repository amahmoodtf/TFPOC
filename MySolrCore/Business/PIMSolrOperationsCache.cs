using SolrNet;
using SolrNet.Impl;
using System;
using System.Diagnostics;
using System.Web.UI.WebControls;


namespace MySolrCore
{
    public static class PIMSolrOperationsCache<T>
            where T : new()
    {
        private static bool isCloundMode = true;
        private static string zookeeperConnectionString = "aci-pimsolrc01.teleflora.org:2181";
        private static string userName = "dev-user1";
        private static string password = "SolrRocks";
        private static string ProductSolrCollection = "product";
        private static string RecipeSolrCollection = "recipe";

        private static ISolrOperations<SolrProduct> solrProductOperations;
        private static ISolrOperations<SolrRecipeItem> solrRecipeOperations;

        internal static ISolrOperations<T> GetSolrOperations(string core)
        {
            if (core == RecipeSolrCollection)
            {
                return (ISolrOperations<T>)GetSolrRecipeOperations(core);
            }
            else
            {
                return (ISolrOperations<T>)GetSolrProductOperations(core);
            }

        }
        internal static ISolrOperations<SolrProduct> GetSolrProductOperations(string core)
        {
            if (core == ProductSolrCollection)
            {
                try
                {
                    if (solrProductOperations == null)
                    {
                        var connectionFactory = new SolrConnectionFactory(isCloundMode, zookeeperConnectionString, userName, password);
                        connectionFactory.AddIndex<SolrProduct>(ProductSolrCollection);
                        connectionFactory.Start<SolrProduct>();

                        solrProductOperations = connectionFactory.Resolve<ISolrOperations<SolrProduct>>();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Solr.Dup init error in GetSolrProductOperations() error [{ex.ToString()}]");

                }
            }
            else
            {
                Debug.WriteLine("Solr.Dup Core requested has not been implemented " + core);
                throw new NotImplementedException("Solr.Dup Core requested has not been implemented " + core);
            }
            return solrProductOperations;
        }
        internal static ISolrOperations<SolrRecipeItem> GetSolrRecipeOperations(string core)
        {
            //string solrUrl = Path.Combine(Helpers.Config.SolrMasterUrl, core).Replace("\\", "/");

            if (core == RecipeSolrCollection)
            {
                try
                {
                    if (solrRecipeOperations == null)
                    {
                        var connectionFactory = new SolrConnectionFactory(isCloundMode, zookeeperConnectionString, userName, password); 
                        connectionFactory.AddIndex<SolrRecipeItem>(RecipeSolrCollection);
                        connectionFactory.Start<SolrRecipeItem>();

                        solrRecipeOperations = connectionFactory.Resolve<ISolrOperations<SolrRecipeItem>>();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Solr.Dup init error in GetSolrRecipeOperations() error [{ex.ToString()}]");
                }
            }
            else
            {
                Debug.WriteLine("Solr.Dup Core requested has not been implemented " + core);
                throw new NotImplementedException("Solr.Dup Core requested has not been implemented " + core);
            }
            return solrRecipeOperations;
        }

        internal static SolrQueryExecuter<T> GetSolrSuggestExecuter(string core)
        {
            ///TODO: This method is probably not used
            ///will need to be removed
            if (core == RecipeSolrCollection)
            {

                var connectionFactory = new SolrConnectionFactory(isCloundMode, zookeeperConnectionString, userName, password); 
                connectionFactory.AddIndex<SolrRecipeItem>(RecipeSolrCollection);
                connectionFactory.Start<SolrRecipeItem>();

                var solrOperations = connectionFactory.Resolve<ISolrOperations<SolrRecipeItem>>();

                return solrOperations as SolrQueryExecuter<T>;
            }
            else
            {
                var connectionFactory = new SolrConnectionFactory(isCloundMode, zookeeperConnectionString, userName, password); 
                connectionFactory.AddIndex<SolrProduct>(ProductSolrCollection);
                connectionFactory.Start<SolrProduct>();

                var solrOperations = connectionFactory.Resolve<ISolrOperations<SolrProduct>>();

                return solrOperations as SolrQueryExecuter<T>;
            }


        }
    }
}