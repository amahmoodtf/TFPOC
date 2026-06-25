using System;
using SolrNet.Impl;
using HttpWebAdapters;
using SolrNet.Cloud.ZooKeeperClient;

namespace MySolrCore
{    

    public class SolrConnectionFactory
    {
       public bool AddIndex<T>(string indexName) where T : ISearchableDocument
        {
            if (cloudMode)
            {
                SolrNet.Cloud.Startup.InitAsync<T>(zkProvider, indexName, usePostConnection).Wait();
            }
            else
            {
                var fullUri = connectionString + "/" + indexName;
                var solrConnection = new SolrConnection(fullUri);
                if (usePostConnection)
                {
                    solrConnection.HttpWebRequestFactory = new BasicAuthHttpWebRequestFactory(userName, password);
                }
                else
                {                    
                    solrConnection.HttpWebRequestFactory = new HttpWebRequestFactory();                                        
                }
                SolrNet.Startup.Init<T>(solrConnection);
            }
            return true;
        }

        public void Start<T>()
        {
            // use basic auth or not?
            if (usePostConnection)
            {
                IHttpWebRequestFactory requestFactory = new BasicAuthHttpWebRequestFactory(userName, password);
                var existing = solrContainer.GetInstance<SolrNet.Cloud.ISolrOperationsProvider>();
                if (existing != null)
                {
                    solrContainer.RemoveAll<SolrNet.Cloud.ISolrOperationsProvider>();
                }
                solrContainer.Register<SolrNet.Cloud.ISolrOperationsProvider>(c =>
                    new SolrBasicAuthOperations(requestFactory, 120));
            }
        }

        public T Resolve<T>()
        {
            return this.solrContainer.GetInstance<T>();
        }

        private readonly SolrNet.Utils.IContainer solrContainer;
        private readonly string connectionString;
        private readonly bool cloudMode;
        private readonly SolrCloudStateProvider zkProvider;
        private readonly bool usePostConnection;
        private string userName;
        private string password;

       public SolrConnectionFactory(SolrServerSettings settings) :
            this(settings.IsCloud, settings.Url, settings.UserName, settings.Password)
        {}

        public SolrConnectionFactory(bool isCloud, string connectionString, string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            // cloud mode or not?
            if (isCloud)
            {
                cloudMode = true;
                this.connectionString = connectionString;
                zkProvider = new SolrCloudStateProvider(connectionString);                
            }
            else
            {
                cloudMode = false;
                if (!Uri.IsWellFormedUriString(connectionString, UriKind.Absolute))
                    throw new ArgumentException("Connection string must be a valid URL", nameof(connectionString));
                this.connectionString = connectionString;                
            }
            usePostConnection = !string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password);
            solrContainer = SolrNet.Cloud.Startup.Container;
        }
    }
    public class SolrServerSettings
    {
        /// <summary>
        /// If Cloud mode is enabled, the URL will be a semi-colon separated list of Zookeeper servers.
        /// </summary>
        public bool IsCloud { get; set; }
        /// <summary>
        /// If not cloud mode, the URL will be the base URL of the Solr server, like 'http://localhost:8983/solr'
        /// If cloud mode, the URL will be a semi-colon separated list of Zookeeper servers, like 'localhost:2181;localhost:2182'
        /// </summary>
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// If not empty, the client will use basic authentication with this username and password.
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// If not empty, the client will use basic authentication with this username and password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
   
    public interface ISearchableDocument
    {
        string Id { get; }
    }

}
