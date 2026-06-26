using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MySolrCore
{
    public static class Config
    {
        public static string SolrUrl
        {
            get
            {
                return GetConfigSetting("SolrUrl");
            }

        }
        public static string SolrMasterUrl
        {
            get
            {
                return GetConfigSetting("SolrMasterUrl");
            }
        }
        public static string SolrZooKeeperConnectionString
        {
            get
            {
                return GetConfigSetting("SolrZooKeeperConnectionString");
            }
        }
        public static string SolrUserName
        {
            get
            {
                return GetConfigSetting("SolrUserName");
            }
        }
        public static string SolrPassword
        {
            get
            {
                return GetConfigSetting("SolrPassword");
            }
        }

        public static bool SolrCloudModeEnabled
        {
            get
            {
                var settingVal = GetConfigSetting("SolrCloudModeEnabled");
                if (string.IsNullOrEmpty(settingVal))
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(settingVal);
                }

            }
        }
        public static string PIMSolrProductCollection
        {
            get
            {
                return "products";
            }

        }
        public static string PIMSolrRecipeItemsCollection
        {
            get
            {
                return "recipeItems";
            }
        }
        public static string PIMDeltaServiceURL
        {
            get
            {
                return GetConfigSetting("PIMDeltaServiceURL");
            }
        }
        public static string PIMECPDeltaServiceURL
        {
            get
            {
                return GetConfigSetting("PIMECPDeltaServiceURL");
            }
        }
        public static string MyTfSolrCollection
        {
            get
            {
                return GetConfigSetting("myteleflora");
            }
        }        
        #region Methods
        internal static string GetConfigSetting(string appSettingName)
        {
            try
            {
                return ConfigurationManager.AppSettings[appSettingName].ToString();
            }
            catch
            {
                Debug.WriteLine("Could not get configuration setting " + appSettingName);
                return string.Empty;
            }
        }
        #endregion
    }
}
