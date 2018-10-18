using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Spatial.Solr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCM.Models;

namespace UCM.Controllers
{
    public class DoctorSearchController : Controller
    {
        public ActionResult Index(DoctorSearchModel model)
        {
            using (var context = ContentSearchManager.GetIndex(new SitecoreIndexableItem(Sitecore.Context.Item)).CreateSearchContext())
            {
                var predicate = PredicateBuilder.True<DoctorSearchResult>();

                predicate = predicate.And(i => i.TemplateName == "Doctor");

                if (!string.IsNullOrWhiteSpace(model.Name))
                {
                    predicate = predicate.And(i => i.Name.Contains(model.Name));
                }

                if (!string.IsNullOrWhiteSpace(model.Specialty))
                {
                    predicate = predicate.And(i => i.Specialties.Contains(model.Specialty));
                }

                if (!string.IsNullOrWhiteSpace(model.Language))
                {
                    predicate = predicate.And(i => i.Language.Contains(model.Language));
                }

                var queryable = context.GetQueryable<DoctorSearchResult>()
                    .Where(predicate)
                    .FacetOn(i => i.Specialties, 1)
                    .FacetOn(i => i.Languages, 1)
                    .Page(model.Page - 1, model.PageSize);

                if (model.Latitude.HasValue && model.Longitude.HasValue)
                {
                    queryable = queryable
                        .WithinRadius(i => i.Location, model.Latitude.Value, model.Longitude.Value, int.MaxValue)
                        .OrderByNearest();
                    model.DidDistanceSearch = true;
                }

                model.Results = queryable.GetResults();
            }


            return View("Index", model);
        }
    }
}