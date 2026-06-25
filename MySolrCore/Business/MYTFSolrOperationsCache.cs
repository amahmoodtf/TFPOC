using SolrNet;
using SolrNet.Impl;
using System;


namespace MySolrCore
{
    public static class MYTFSolrOperationsCache<T>
            where T : new()
    {
        private static bool isCloundMode = true;
        private static string zookeeperConnectionString = "aci-mtfsolrc01.teleflora.org:2181";
        private static string userName = "dev-user1";
        private static string password = "SolrRocks";
        private static string MyTfSolrCollection = "myteleflora";

        public static ISolrOperations<T> GetSolrOperations(string core)
        {

            try
            {
                return (ISolrOperations<T>)SolrConnections.SolrMYTFConnection.Resolve<ISolrOperations<IndexItem>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error resolving ISolrOperations: " + ex.Message);

                var connectionFactory = new SolrConnectionFactory(isCloundMode, zookeeperConnectionString, userName, password);
                connectionFactory.AddIndex<IndexItem>(MyTfSolrCollection);
                connectionFactory.Start<IndexItem>();
                var solrOperations = connectionFactory.Resolve<ISolrOperations<IndexItem>>();
                SolrConnections.SolrMYTFConnection = connectionFactory;
                return (ISolrOperations<T>)solrOperations;
            }
        }


        internal static SolrQueryExecuter<T> GetSolrSuggestExecuter(string core)
        {
            try
            {
                return (ISolrOperations<T>)SolrConnections.SolrMYTFConnection.Resolve<ISolrOperations<IndexItem>>() as SolrQueryExecuter<T>;

                //return Global.MYTFSolrConnection.Resolve<ISolrOperations<IndexItem>>() as SolrQueryExecuter<T>;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error resolving SolrQueryExecuter: " + ex.Message);
                var connectionFactory = new SolrConnectionFactory(isCloundMode, zookeeperConnectionString, userName, password);
                connectionFactory.AddIndex<IndexItem>(MyTfSolrCollection);
                connectionFactory.Start<IndexItem>();

                var solrOperations = connectionFactory.Resolve<ISolrOperations<IndexItem>>();

                //SolrQueryExecuter<IndexItem> solrQueryExecuter = ServiceLocator.Current.GetInstance<ISolrQueryExecuter<IndexItem>>() as SolrQueryExecuter<IndexItem>;
                //return solrQueryExecuter as SolrQueryExecuter<T>;
                SolrConnections.SolrMYTFConnection = connectionFactory;
                return solrOperations as SolrQueryExecuter<T>;
            }
        }
    }
}