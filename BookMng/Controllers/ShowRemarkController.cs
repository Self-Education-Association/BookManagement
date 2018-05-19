using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMng.Models;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace BookMng.Controllers
{
    public class ShowRemarkController : Controller
    {
        private ApplicationDbContext db = ApplicationDbContext.Create();

        // GET: ShowRemark
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowRemark()
        {
            return View(db.Remarks.ToList());
        }

    }
}