using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCM
{
    public class LanguagesField : AbstractComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public override object ComputeFieldValue(IIndexable indexable)
        {
            var item = indexable as SitecoreIndexableItem;

            MultilistField f = item.Item.Fields["Languages"];

            if (f != null)
            {
                var multilist = f.GetItems();
                if (multilist == null || multilist.Length == 0)
                    return null;

                return multilist.Select(t => t["Name"]).ToArray();
            }

            return null;
        }
    }
}