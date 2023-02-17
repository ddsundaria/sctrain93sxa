using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
namespace SCTraining.Web.Models
{
    public class BlogResultModel: SearchResultItem
    {
        [IndexField("title")]
        public string BlogTitle { get; set; }

        [IndexField("summary")]
        public string BlogSummary { get; set; }
    }
}