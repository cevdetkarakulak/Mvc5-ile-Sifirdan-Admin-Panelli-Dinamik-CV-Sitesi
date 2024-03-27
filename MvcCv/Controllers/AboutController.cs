using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblAbout tblAbout)
        {
            var values = repo.Fınd(x => x.AboutID == 1);
            values.Name = tblAbout.Name;
            values.SurName = tblAbout.SurName;
            values.Mail = tblAbout.Mail;
            values.Phone = tblAbout.Phone;
            values.ImageUrl = tblAbout.ImageUrl;
            values.Adress = tblAbout.Adress;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}