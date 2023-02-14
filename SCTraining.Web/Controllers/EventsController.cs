using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCTraining.Web.Models;
using Sitecore.SecurityModel;

namespace SCTraining.Web.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            EventsRenderingViewModel model = new EventsRenderingViewModel();
            model.Item = Sitecore.Context.Item;

        //    using (new SecurityDisabler()
        //    {
        //         model.Item.Editing.BeginEdit();

        //    model.Item.Fields["EventName"].Value = "Sitecore Training 10.2";

        //    model.Item.Editing.EndEdit();
        //})
           

            return View(model);
    }
}
}