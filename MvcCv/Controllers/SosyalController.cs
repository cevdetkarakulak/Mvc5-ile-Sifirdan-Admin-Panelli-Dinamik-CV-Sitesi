using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class SosyalController : Controller
    {
        // GET: Sosyal
        GenericRepository<TblSosyal> repo = new GenericRepository<TblSosyal>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SosyalAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalAdd(TblSosyal tblSosyal)
        {
            repo.TAdd(tblSosyal);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Sosyalupdate(int id)
        {
            var values = repo.Fınd(x => x.SosyalID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Sosyalupdate(TblSosyal tblSosyal)
        {
            var values = repo.Fınd(x => x.SosyalID == tblSosyal.SosyalID);
            values.SosyalValue = true;
            values.SoyalName = tblSosyal.SoyalName;
            values.SoyalLink = tblSosyal.SoyalLink;
            values.Sosyalİcon = tblSosyal.Sosyalİcon;
            repo.TUpdate(tblSosyal);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalDelete(int id)
        {
            var values = repo.Fınd(x => x.SosyalID == id);
            values.SosyalValue = false;
            repo.TUpdate(values);
           return RedirectToAction("Index");
        }
    }
}