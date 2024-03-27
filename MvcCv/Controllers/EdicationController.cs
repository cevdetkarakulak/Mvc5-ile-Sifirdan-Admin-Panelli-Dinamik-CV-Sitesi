using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EdicationController : Controller
    {
        // GET: Edication
        GenericRepository<TblEdication> repo = new GenericRepository<TblEdication>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
       public ActionResult EdicationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EdicationAdd(TblEdication tblEdication)
        {
            if (!ModelState.IsValid)
            {
                return View("EdicationAdd");
            }
            repo.TAdd(tblEdication);
            return RedirectToAction("Index");
        }
        public ActionResult EdicationDelete(int id)
        {
            var vales = repo.Fınd(x => x.EdicationID == id);
            repo.TDelete(vales);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EdicationUpdate(int id)
        {
            var values = repo.Fınd(x => x.EdicationID == id);
            return View(values);
                
        }
        [HttpPost]
        public ActionResult EdicationUpdate(TblEdication tblEdication)
        {
            if (!ModelState.IsValid)
            {
                return View("EdicationUpdate");
            }
            var values = repo.Fınd(x => x.EdicationID == tblEdication.EdicationID);
            values.Title = tblEdication.Title;
            values.Subitle1 = tblEdication.Subitle1;
            values.Subitle2 = tblEdication.Subitle2;
            values.Date = tblEdication.Date;
            values.GNO = tblEdication.GNO;
            repo.TUpdate(values);

            return RedirectToAction("Index");

        }
    }
}