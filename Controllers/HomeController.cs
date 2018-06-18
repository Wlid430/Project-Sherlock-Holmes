using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        PGA_HROEntities context = new PGA_HROEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDatas()
        {

            int male = context.tblImages.Where(x => x.imgId == 1).Count();
            Ratio obj = new Ratio();
            obj.Male = male;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            
            public int Male { get; set; }
        }
        }


    }
