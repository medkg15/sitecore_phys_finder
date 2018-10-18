using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Spatial.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCM
{
    public class DoctorSearchResult : SearchResultItem
    {
        [IndexField("name")]
        public string Name { get; set; }
        [IndexField("specialtyNames")]
        public string[] Specialties { get; set; }
        [IndexField("languageNames")]
        public string[] Languages { get; set; }
        [IndexField("location")]
        public SpatialPoint Location { get; set; }

        // http://goblinrockets.com/2015/10/31/sitecore-search-solr-ordering-by-score-with-your-own-poco/
        [IndexField("score")]
        public string Score { get; }
    }
}