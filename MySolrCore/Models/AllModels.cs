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

    public class SolrProduct : ISearchableDocument
    {
        public SolrProduct() { }

        [SolrUniqueKey("id")]
        public string ProductID { get; set; }

        [SolrField("activationDate")]
        public DateTime ActivationDate { get; set; }

        [SolrField("alternateName")]
        public string AlternateName { get; set; }

        [SolrField("bouquetHeight")]
        public string BouquetHeight { get; set; }

        [SolrField("bouquetWidth")]
        public string BouquetWidth { get; set; }

        [SolrField("canDisplayRestrictedImage")]
        public bool CanDisplayRestrictedImage { get; set; }

        [SolrField("category")]
        public ICollection<string> Categories { get; set; }

        [SolrField("categoryID")]
        public ICollection<string> CategoryIDs { get; set; }

        [SolrField("collection")]
        public ICollection<string> Collections { get; set; }

        [SolrField("collectionID")]
        public ICollection<string> CollectionIDs { get; set; }

        [SolrField("color")]
        public ICollection<string> Color { get; set; }

        [SolrField("colorID")]
        public ICollection<string> ColorID { get; set; }

        [SolrField("container")]
        public string Container { get; set; }

        [SolrField("department")]
        public string DepartmentName { get; set; }

        [SolrField("departmentID")]
        public string DepartmentID { get; set; }

        [SolrField("directoryGroupID")]
        public ICollection<string> DirectoryGroupID { get; set; }

        [SolrField("directoryGroup")]
        public ICollection<string> DirectoryGroupName { get; set; }

        [SolrField("directory")]
        public ICollection<string> Directory { get; set; }

        [SolrField("directoryID")]
        public ICollection<string> DirectoryID { get; set; }

        [SolrField("hasPriceLock")]
        public bool HasPriceLock { get; set; }

        [SolrField("hasEnvImage")]
        public bool HasEnvImage { get; set; }

        [SolrField("hasWhiteImage")]
        public bool HasWhiteImage { get; set; }

        [SolrField("isFSGProduct")]
        public bool IsFSGProduct { get; set; }

        [SolrField("isImageRequired")]
        public bool IsImageRequired { get; set; }

        [SolrField("isImageAvailable")]
        public bool IsImageAvailable { get; set; }

        [SolrField("itemNumber")]
        public string ItemNumber { get; set; }

        [SolrField("itemName")]
        public string ItemName { get; set; }

        [SolrField("occasion")]
        public string OccasionName { get; set; }

        [SolrField("occasionID")]
        public string OccasionID { get; set; }

        [SolrField("primaryCategory")]
        public string PrimaryCategory { get; set; }

        [SolrField("primaryCategoryID")]
        public string PrimaryCategoryID { get; set; }

        [SolrField("primaryColor")]
        public ICollection<string> PrimaryColor { get; set; }

        [SolrField("primaryColorID")]
        public ICollection<string> PrimaryColorID { get; set; }

        [SolrField("productStyle")]
        public ICollection<string> ProductStyles { get; set; }

        [SolrField("productStyleID")]
        public ICollection<string> ProductStyleIDs { get; set; }

        [SolrField("productStatus")]
        public string ProductStatusName { get; set; }

        [SolrField("productStatusID")]
        public string ProductStatusID { get; set; }

        [SolrField("productType")]
        public string ProductTypeName { get; set; }

        [SolrField("productTypeID")]
        public string ProductTypeID { get; set; }

        [SolrField("productVariantTypeID")]
        public string ProductVariantTypeID { get; set; }

        [SolrField("productVariantTypeName")]
        public string ProductVariantTypeName { get; set; }

        [SolrField("recipeExampleImageLabel")]
        public ICollection<string> RecipeExampleImageLabel { get; set; }

        [SolrField("recipeExampleImageID")]
        public ICollection<string> RecipeExampleImageID { get; set; }

        [SolrField("recipeItemName")]
        public ICollection<string> RecipeItemName { get; set; }

        [SolrField("restriction")]
        public string RestrictionType { get; set; }

        [SolrField("restrictionID")]
        public string RestrictionID { get; set; }

        [SolrField("searchColor")]
        public ICollection<string> SearchColor { get; set; }

        [SolrField("searchColorID")]
        public ICollection<string> SearchColorID { get; set; }

        [SolrField("searchFlower")]
        public ICollection<string> SearchFlower { get; set; }

        [SolrField("searchFlowerID")]
        public ICollection<string> SearchFlowerID { get; set; }

        [SolrField("season")]
        public string SeasonName { get; set; }

        [SolrField("seasonID")]
        public string SeasonID { get; set; }

        [SolrField("supplier")]
        public ICollection<string> CompanyName { get; set; }

        [SolrField("supplierID")]
        public ICollection<string> SupplierID { get; set; }

        [SolrField("sweepstakes_en")]
        public string Sweepstakes { get; set; }

        [SolrField("targetPrice")]
        public decimal TargetPrice { get; set; }

        [SolrField("workingGroup")]
        public string GroupName { get; set; }

        [SolrField("workingGroupID")]
        public string GroupID { get; set; }

        [SolrField("*")]
        public IDictionary<string, object> OtherFields { get; set; }

        //[SolrField("timestamp")]
        //public DateTime Timestamp { get; set; }

        [SolrField("ecpExport1")]
        public string EcpExport1 { get; set; }

        [SolrField("ecpExport2")]
        public string EcpExport2 { get; set; }

        [SolrField("ecpExport3")]
        public string EcpExport3 { get; set; }

        [SolrField("ecpExport4")]
        public string EcpExport4 { get; set; }

        [SolrField("isAutoPriced")]
        public bool IsAutoPriced { get; set; }

        public string Id { get; set; }
    }

    public class SolrRecipeItem : ISearchableDocument
    {
        public SolrRecipeItem() { }

        [SolrUniqueKey("id")]
        public string RecipeItemID { get; set; }

        [SolrField("alternateName")]
        public string AlternateName { get; set; }

        [SolrField("color")]
        public string ColorName { get; set; }

        [SolrField("colorID")]
        public string ColorID { get; set; }

        [SolrField("description")]
        public string Description { get; set; }

        [SolrField("isActive")]
        public bool IsActive { get; set; }

        [SolrField("isSellable")]
        public bool IsSellable { get; set; }

        [SolrField("isTelefloraKeepsake")]
        public bool IsTelefloraKeepsake { get; set; }

        [SolrField("material")]
        public string Material { get; set; }

        [SolrField("pluralDescription")]
        public string PluralDescription { get; set; }

        [SolrField("primaryColor")]
        public string PrimaryColorName { get; set; }

        [SolrField("primaryColorID")]
        public string PrimaryColorID { get; set; }

        [SolrField("recipeExampleImageID")]
        public string RecipeExampleImageID { get; set; }

        [SolrField("recipeItemName")]
        public string RecipeItemName { get; set; }

        [SolrField("recipeItemPluralName")]
        public string RecipeItemPluralName { get; set; }

        [SolrField("recipeItemTypeID")]
        public string RecipeItemTypeID { get; set; }

        [SolrField("recipeItemTypeName")]
        public string RecipeItemTypeName { get; set; }

        [SolrField("supplierItemNumber")]
        public string SupplierItemNumber { get; set; }

        [SolrField("supplierID")]
        public string SupplierID { get; set; }

        [SolrField("supplierName")]
        public string SupplierName { get; set; }

        [SolrField("perUnitPrice")]
        public double PerUnitPrice { get; set; }

        [SolrField("holidayPricePerUnit")]
        public double HolidayPricePerUnit { get; set; }

        [SolrField("imageUrl")]
        public string ImageUrl { get; set; }

        [SolrField("*")]
        public IDictionary<string, object> OtherFields { get; set; }

        //[SolrField("timestamp")]
        //public DateTime Timestamp { get; set; }

        public string Id { get; set; }
    }

    public class SolrIndexProduct : SolrProduct
    {
        public SolrIndexProduct() { }
    }

    public class SolrIndexRecipeItem : SolrRecipeItem
    {
        public SolrIndexRecipeItem() { }
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
