using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MoodShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index ()
        {
            IndexModel model = new IndexModel ();
            ViewBag.Title = "MoodShare";
            return View (model);
        }
    }
}

