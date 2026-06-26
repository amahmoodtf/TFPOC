using SolrNet;
using SolrNet.Impl;
using System;


namespace MySolrCore
{
    public static class MYTFSolrOperationsCache<T>
            where T : new()
    {
        public static ISolrOperations<T> GetSolrOperations(string core)
        {
            try
            {
                return (ISolrOperations<T>)SolrConnections.SolrMYTFConnection.Resolve<ISolrOperations<IndexItem>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resolving ISolrOperations, re initializing: {ex.ToString()}");

                var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                connectionFactory.AddIndex<IndexItem>(Config.MyTfSolrCollection);
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
                return SolrConnections.SolrMYTFConnection.Resolve<ISolrOperations<IndexItem>>() as SolrQueryExecuter<T>; ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resolving SolrQueryExecuter, re initializing: {ex.ToString()}");
                var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                connectionFactory.AddIndex<IndexItem>(Config.MyTfSolrCollection);
                connectionFactory.Start<IndexItem>();
                SolrConnections.SolrMYTFConnection = connectionFactory;

                var solrOperations = connectionFactory.Resolve<ISolrOperations<IndexItem>>();
                return solrOperations as SolrQueryExecuter<T>;
            }
        }
    }
}