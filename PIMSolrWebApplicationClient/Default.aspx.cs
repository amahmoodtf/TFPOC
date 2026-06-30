using SolrNet;
using SolrNet.Attributes;
using SolrNet.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySolrCore;
namespace SolrWebApplicationClient
{
    public partial class _Default : Page
    {
        public static bool isCloudMode = true;
        public static string userName = "dev-user1";
        public static string password = "SolrRocks";
        public static string zookeeperConnectionString = "aci-pimolrc01.teleflora.org:2181";
        public static string solrUrl = "https://aci-mtfsolrc01.teleflora.org:8984/solr";
        //public static string zookeeperConnectionString = "acs-mtfsolrc01.tf.stg:2181,acs-mtfsolrc02.tf.stg:2181,acs-mtfsolrc03.tf.stg:2181";
        //public static string solrUrl = "https://acs-mtfsolrc01.tf.stg:8984/solr";

        public static string mYTfSolrUrl = "https://aci-mtfsolrc01.teleflora.org:8984/solr/myteleflora";

        public static string pIMProductsSolrUrl = "https://aci-mtfsolrc01.teleflora.org:8984/solr/products";
        public static string pIMRecipeItemSolrUrl = "https://aci-mtfsolrc01.teleflora.org:8984/solr/recipeitem";

        public static string pIMProductCollectionName = "products";
        public static string pIMRecipeItemCollectionName = "recipeItems";
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryPIMSolr(isCloudMode);

        }
        private void AddDocToMyTFSolrIndex(bool isCloudMode)
        {
            if (!isCloudMode)
            {
                zookeeperConnectionString = solrUrl;

            }
            //var connectionFactory = new SolrConnectionFactory(isCloudMode, zookeeperConnectionString, userName, password);
            //connectionFactory.AddIndex<IndexItem>(mYTfCollectionName);
            //connectionFactory.Start();
            //var solrOps = SolrConnections.SolrMYTFConnection.Resolve<ISolrOperations<IndexItem>>();
            //var solrOps = Global.SolrConnection.Resolve<ISolrOperations<IndexItem>>();

            //var item = new IndexItem
            //{
            //    Id = "1",
            //    Url = "https://www.microsoft.com/solr",
            //    Title = "Microsoft Solr Client",
            //    Description = "This is a Solr client library for .NET."
            //};
            //solrOps.Add(item);
            //solrOps.Commit();

            //Console.WriteLine("Document added successfully.");
        }
        private void QueryPIMSolr(bool isCloudMode)
        {
            if (!isCloudMode)
            {
                zookeeperConnectionString = solrUrl;

            }
            /*var connectionFactory = new SolrConnectionFactory(isCloudMode, zookeeperConnectionString, userName, password);
            connectionFactory.AddIndex<IndexItem>(mYTfCollectionName);
            connectionFactory.Start();*/

            //var solrOps1 = SolrConnections.SolrProductConnection.Resolve<ISolrOperations<SolrProduct>>();
            //var solrOps1 = SolrMasterOperationsCache.GetSolrMasterProductOperations(PIMSolrCore.PIMSolrProductCollection);
            var solrOps1 = PIMSolrOperationsCache<SolrProduct>.GetSolrOperations(PIMSolrCore.PIMSolrProductCollection);


            var results = solrOps1.Query(new SolrQueryByField("occasion", "other"));
            if (results != null)
            {
                Response.Write($"Product Solr docs count: {results.Count}");
            }

            
            //var solrOps2 = SolrConnections.SolrRecipeConnection.Resolve<ISolrOperations<SolrRecipeItem>>();
            var solrOps2 = PIMSolrOperationsCache<SolrRecipeItem>.GetSolrOperations(PIMSolrCore.PIMSolrRecipeItemsCollection);

            var results2 = solrOps2.Query(new SolrQueryByField("id", "1"));
            if (results2 != null)
            {
                Response.Write($"RecipeItem Solr docs count: {results2.Count}");
            }

            //index

            //solrOps1.Add();
            //solrOps2.Add();
        }
    }
    public class IndexItem2 : ISearchableDocument
    {
        [SolrField("id")]
        public string Id { get; set; }

        [SolrField("url")]
        public string Url { get; set; }
    }
        public class IndexItem : ISearchableDocument
    {
        [SolrField("id")]
        public string Id { get; set; }

        [SolrField("url")]
        public string Url { get; set; }

        [SolrField("host")]
        public string Host { get; set; }

        [SolrField("content")]
        public string[] Content { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        [SolrField("description")]
        public string Description { get; set; }

        [SolrField("digest")]
        public string Digest { get; set; }

        [SolrField("keywords")]
        public ICollection<string> Keywords { get; set; }

        [SolrField("date")]
        public string Date { get; set; }

        [SolrField("contentLength")]
        public long ContentLength { get; set; }

        [SolrField("lastModified")]
        public long LastModified { get; set; }

        [SolrField("type")]
        public ICollection<string> Type { get; set; }

        [SolrField("product-keywords")]
        public string ProductKeywords { get; set; }

        [SolrField("alternateNames")]
        public string AlternateNames { get; set; }

        [SolrField("pricePoint")]
        public string PricePoint { get; set; }

        [SolrField("dataSource")]
        public string DataSource { get; set; }

        [SolrField("category")]
        public string Category { get; set; }

        [SolrField("abbrevProductName")]
        public string AbbrevProductName { get; set; }

        [SolrField("product-image")]
        public string ProductImage { get; set; }

        [SolrField("product-image-large")]
        public string ProductImageLarge { get; set; }

        [SolrField("productType")]
        public string ProductType { get; set; }

        [SolrField("codifiedSymbol")]
        public string CodifiedSymbol { get; set; }

        [SolrField("variations")]
        public string Variations { get; set; }

        [SolrField("updatedDate")]
        public string UpdatedDate { get; set; }

        [SolrField("dateActivated")]
        public DateTime? DateActivated { get; set; }

        [SolrField("codifRelations")]
        public string[] CodifRelations { get; set; }

    }
}