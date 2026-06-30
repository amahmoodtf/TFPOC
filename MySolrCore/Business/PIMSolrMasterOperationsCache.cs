using SolrNet;
using SolrNet.Impl;
using System;
using System.Diagnostics;
using System.Net;
namespace MySolrCore
{
    public static class PIMSolrMasterOperationsCache //<T> where T : new()
    {        
        public static ISolrOperations<SolrIndexProduct> GetSolrMasterProductOperations(string core)
        {           
            //use latest tls version
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            //Trust All certificates
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            if (core == PIMSolrCore.PIMSolrProductCollection)
            {
                try
                {
                    return SolrConnections.SolrIndexProductConnection.Resolve<ISolrOperations<SolrIndexProduct>>();
                }
                catch (Exception e )
                {
                    Debug.WriteLine($"Solr init in GetSolrMasterProductOperations() due to error [{e.ToString()}]");


                    var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                    connectionFactory.AddIndex<SolrIndexProduct>(Config.PIMSolrProductCollection);
                    connectionFactory.Start<SolrIndexProduct>();
                    SolrConnections.SolrIndexProductConnection = connectionFactory;
                    //return connectionFactory as ISolrOperations<SolrIndexProduct>;
                    return connectionFactory.Resolve<ISolrOperations<SolrIndexProduct>>();

                }
            }            
            else
            {
                Debug.WriteLine("Solr Core requested has not been implemented " + core);
                throw new NotImplementedException("Solr Core requested has not been implemented " + core);
            }            
        }
        public static ISolrOperations<SolrIndexRecipeItem> GetSolrMasterRecipeOperations(string core)
        {            
            //use latest tls version
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            //Trust All certificates
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            if (core == PIMSolrCore.PIMSolrRecipeItemsCollection)
            {
                try
                {
                    return SolrConnections.SolrIndexRecipeItemsConnection.Resolve<ISolrOperations<SolrIndexRecipeItem>>();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Solr init in GetSolrMasterRecipeOperations() due to error [{e.ToString()}]");


                    var connectionFactory = new SolrConnectionFactory(Config.SolrCloudModeEnabled, Config.SolrZooKeeperConnectionString, Config.SolrUserName, Config.SolrPassword);
                    connectionFactory.AddIndex<SolrIndexRecipeItem>(Config.PIMSolrRecipeItemsCollection);
                    connectionFactory.Start<SolrIndexRecipeItem>();
                    SolrConnections.SolrIndexRecipeItemsConnection = connectionFactory;
                    return connectionFactory.Resolve<ISolrOperations<SolrIndexRecipeItem>>();

                }
            }
            else
            {
                Debug.WriteLine("Solr Core requested has not been implemented " + core);
                throw new NotImplementedException("Solr Core requested has not been implemented " + core);
            }            
        }
    }
}