using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AwardController : Controller
    {
        // GET: Award
        GenericRepository<TblAward> repo = new GenericRepository<TblAward>();
        [Authorize]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AwardUpdate(int id)
        {
            ViewBag.d = id;
            var values = repo.Fınd(x => x.AwardID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult AwardUpdate(TblAward tblAward)
        {
            var values = repo.Fınd(x => x.AwardID == tblAward.AwardID);
            values.explanation = tblAward.explanation;
            values.Date = tblAward.Date;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AwardAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AwardAdd(TblAward tblAward)
        {
            repo.TAdd(tblAward);
            return RedirectToAction("Index");
        }
        public ActionResult AwardDelete(int id)
        {
            var values = repo.Fınd(x => x.AwardID == id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}