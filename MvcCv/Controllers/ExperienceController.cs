using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult ExperienceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperienceAdd(TblExperience tblExperience)
        {
            repo.TAdd(tblExperience);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceDelete(int id)
        {
            TblExperience t = repo.Fınd(x => x.ExperienceID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ExperienceUpdate(int id)
        {
            TblExperience t = repo.Fınd(x => x.ExperienceID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult ExperienceUpdate(TblExperience tblExperience)
        {
            TblExperience t = repo.Fınd(x => x.ExperienceID == tblExperience.ExperienceID);
            t.Title = tblExperience.Title;
            t.Subitle = tblExperience.Subitle;
            t.Explanation = tblExperience.Explanation;
            t.Date = tblExperience.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}