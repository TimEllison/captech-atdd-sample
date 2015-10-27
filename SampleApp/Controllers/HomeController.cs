using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Submit to Contact Us";

            return View(new ContactModel());
        }

        public ActionResult Save()
        {
            return RedirectToAction("Saved");
        }

        public ActionResult Saved()
        {
            return View();
        }

        public ActionResult Counties(string id)
        {
            var counties = new List<KeyValuePair<string,string>>();
            switch (id)
            {
                case "VA":
                    counties.AddRange(new KeyValuePair<string,string>[]
                    {
                        new KeyValuePair<string, string>("H", "Henrico"),
                        new KeyValuePair<string, string>("HA", "Hanover"),
                        new KeyValuePair<string, string>("NK", "New Kent"),
                        new KeyValuePair<string, string>("G", "Goochland"),
                    });
                    break;
                case "NC":
                    counties.AddRange(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>("HAL", "Halifax"),
                        new KeyValuePair<string, string>("W", "Wake"),
                        new KeyValuePair<string, string>("WA", "Wayne"),
                        new KeyValuePair<string, string>("C", "Catawba"),
                    });
                    break;
                default:
                    counties = null;
                    break;
            }
            return Json(counties, JsonRequestBehavior.AllowGet);
        }
    }
}