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
            model.moods = new List<IndexModel.Mood> {
                new IndexModel.Mood{id = 1, name = "Vital"}
              , new IndexModel.Mood{id = 2, name = "Cool"}
            };
            ViewBag.Title = "MoodShare";
            return View (model);
        }
    }
}

