using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace SCTraining.Web.Models
{
    public class EventsRenderingViewModel
    {
        public Item Item { get; set; }
        public HtmlString EventName
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(this.Item, "EventName"));
            }
        }
        public HtmlString EventDate
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(this.Item, "EventDate"));
            }
        }
        public HtmlString EventDescription
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(this.Item, "EventDescription"));
            }
        }
    }
}