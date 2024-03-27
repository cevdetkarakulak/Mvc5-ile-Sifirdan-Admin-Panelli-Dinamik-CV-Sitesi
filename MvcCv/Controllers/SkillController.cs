using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<TblSkill> repo = new GenericRepository<TblSkill>();
        
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SkilAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkilAdd(TblSkill tblSkill)
        {
            repo.TAdd(tblSkill);
            return RedirectToAction("Index");
        }
        public ActionResult SkillDelete(int id)
        {
            var skill = repo.Fınd(x => x.SkillID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SkillUpdate(int id)
        {
            var y = repo.Fınd(x => x.SkillID == id);
            return View(y);
        }
        [HttpPost]
        public ActionResult SkillUpdate(TblSkill tblSkill)
        {

            var y = repo.Fınd(x => x.SkillID == tblSkill.SkillID);
            y.SkillName = tblSkill.SkillName;
            y.SkillValue = tblSkill.SkillValue;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}