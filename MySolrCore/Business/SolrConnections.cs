using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolrCore
{
    public static class SolrConnections
    {
        public static SolrConnectionFactory SolrMYTFConnection { get; set; }
        public static SolrConnectionFactory SolrProductConnection { get; set; }
        public static SolrConnectionFactory SolrRecipeConnection { get; set; }
    }
}
