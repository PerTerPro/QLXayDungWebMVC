using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLXayDungWebMVC.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}