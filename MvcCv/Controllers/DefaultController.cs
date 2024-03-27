using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHead()
        {
            return PartialView();
        }
        public ActionResult PartialNavbar()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public ActionResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public ActionResult PartialSosyal()
        {
            var values = db.TblSosyal.Where(x => x.SosyalValue == true).ToList(); ;
            return PartialView(values);
        }

        public ActionResult PartialExperience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }
        public ActionResult PartialEdication()
        {
            var values = db.TblEdication.ToList();
            return PartialView(values);
        }
        public ActionResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public ActionResult PartialInterest()
        {
            var values = db.TblInterest.ToList();
            return PartialView(values);
        }
        public ActionResult PartialAward()
        {
            return PartialView();

        }
        [HttpGet]
        public ActionResult PartialContact()
        {
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult PartialContact(TblContact tblContact)
        {
            tblContact.Date = DateTime.Now.Date;
            db.TblContact.Add(tblContact);
            db.SaveChanges();
            return PartialView();
        }
    }

}