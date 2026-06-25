using System;
using SolrNet;
using HttpWebAdapters;

namespace MySolrCore
{
    public class SolrBasicAuthOperations : SolrNet.Cloud.ISolrOperationsProvider
    {
        private readonly IHttpWebRequestFactory _requestFactory;
        private readonly int _timeOutSeconds;

        public SolrBasicAuthOperations(IHttpWebRequestFactory requestFactory, int timeOutSeconds)
        {
            _requestFactory = requestFactory;
            _timeOutSeconds = timeOutSeconds;
        }

        public ISolrBasicOperations<T> GetBasicOperations<T>(string url, bool isPostConnection = false)
        {
            var connection = new SolrNet.Impl.SolrConnection(url);
            connection.HttpWebRequestFactory = _requestFactory;
            connection.Timeout = (int)TimeSpan.FromSeconds(_timeOutSeconds).TotalMilliseconds;

            if (!isPostConnection)
            {
                return SolrNet.SolrNet.GetBasicServer<T>(connection);
            }
            else
            {
                var postConnection = new SolrNet.Impl.PostSolrConnection(connection, url);
                postConnection.HttpWebRequestFactory = _requestFactory;
                return SolrNet.SolrNet.GetBasicServer<T>(postConnection);
            }
        }

        public ISolrOperations<T> GetOperations<T>(string url, bool isPostConnection = false)
        {
            var connection = new SolrNet.Impl.SolrConnection(url);
            connection.HttpWebRequestFactory = _requestFactory;
            connection.Timeout = (int)TimeSpan.FromSeconds(_timeOutSeconds).TotalMilliseconds;

            if (!isPostConnection)
            {
                return SolrNet.SolrNet.GetServer<T>(connection);
            }
            else
            {
                var postConnection = new SolrNet.Impl.PostSolrConnection(connection, url);
                postConnection.HttpWebRequestFactory = _requestFactory;
                return SolrNet.SolrNet.GetServer<T>(postConnection);
            }
        }
        
    }

}
