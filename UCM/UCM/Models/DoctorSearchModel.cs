using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.Linq;

namespace UCM.Models
{
    public class DoctorSearchModel
    {
        public DoctorSearchModel()
        {
            Page = 1;
            PageSize = 10;
        }

        public string Name { get; set; }
        public string Language { get; set; }
        public string Specialty { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public bool DidDistanceSearch { get; set; }
        public SearchResults<DoctorSearchResult> Results { get; set; }
    }
}