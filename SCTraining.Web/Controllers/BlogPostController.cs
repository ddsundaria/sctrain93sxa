using SCTraining.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;

namespace SCTraining.Web.Controllers
{
    public class BlogPostController : Controller
    {
        // GET: BlogPost
        public ActionResult BlogDetails()
        {
            var contextItem = Sitecore.Context.Item;

            BlogPostViewModel model = new BlogPostViewModel();

            Field title = contextItem.Fields["Title"];
            Field summary = contextItem.Fields["Summary"];
            Field body = contextItem.Fields["Body"];

            DateField date = contextItem.Fields["Date"];

            ImageField image = contextItem.Fields["Image"];

            ReferenceField authorField = contextItem.Fields["Author"];

            Sitecore.Data.Items.Item authorItem = authorField.TargetItem;

            Field authorName = authorItem.Fields["Author Name"];
            Field designation = authorItem.Fields["Designation Or Expertise"];
            Field authorSummary = authorItem.Fields["Summary"];
            ImageField authorImage = authorItem.Fields["Author Image"];

            model.Title = title.Value;
            model.Summary = summary.Value;
            model.Body = body.Value;

            model.BlogPostDate = date.DateTime;

            model.BlogImage = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image.MediaItem));

            model.Author = new Author
            {
                AuthorName = authorName.Value,
                Designation = designation.Value,
                Summary = authorSummary.Value,
                AuthorImage = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(authorImage.MediaItem))
            };

            return View(model);
        }
    }
}