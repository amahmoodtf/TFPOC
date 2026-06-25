using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolrCore
{
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
    public class Product : ISearchableDocument
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [SolrField("manu")]
        public string Manufacturer { get; set; }
        [SolrField("cat")]
        public ICollection<string> Categories { get; set; }
        [SolrField("price")]
        public decimal Price { get; set; }
        [SolrField("inStock")]
        public bool InStock { get; set; }
    }
    public class RecipeItem : ISearchableDocument
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [SolrField("name")]
        public string Name { get; set; }
    }

    public class MyBookClass : ISearchableDocument
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; } = string.Empty;
        [SolrField("title")]
        public string Title { get; set; } = string.Empty;
        [SolrField("author")]
        public string Author { get; set; } = string.Empty;
    }
}
