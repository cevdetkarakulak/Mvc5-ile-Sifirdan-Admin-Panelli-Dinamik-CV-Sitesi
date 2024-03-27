using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        GenericRepository<TblInterest> repo = new GenericRepository<TblInterest>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblInterest tblInterest)
        {
            var values = repo.Fınd(x=>x.InterestID==1);
            values.Description = tblInterest.Description;
            values.Description2 = tblInterest.Description2;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}