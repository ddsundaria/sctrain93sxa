//using SCTraining.Web.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCTraining.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult FindResults()
        {
            //var searchIndex = ContentSearchManager.GetIndex((SitecoreIndexableItem)Sitecore.Context.Item);

            var searchIndex = ContentSearchManager.GetIndex("sitecore_custom_index");

            using (var searchContext = searchIndex.CreateSearchContext())
            {
                var searchResults = searchContext.GetQueryable<SearchResultItem>()
                    .Where(x => x.TemplateName == "Blog Post" && x.Content.Contains("blog"))
                    .ToList()
                    .Select(item => item.GetItem())
                    .ToList();

                //var predicate = PredicateBuilder.True<SearchResultItem>();

                //predicate = predicate.And<SearchResultItem>(i => i.TemplateName == "News");

                //predicate = predicate.And<SearchResultItem>(i => i.TemplateName == "Page");

                //predicate = predicate.And<SearchResultItem>(i => i.Content.Contains(Request.QueryString["query"]));

                //var queryable = searchContext.GetQueryable<SearchResultItem>();

                //var results = queryable.Where(predicate).Select(item => item.GetItem()).ToList();


                return View(searchResults);
            }
        }
    }
}