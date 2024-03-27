using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo=new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(TblAdmin tblAdmin)
        {
            repo.TAdd(tblAdmin);
            return RedirectToAction("Index");
        }
        public ActionResult AdminDelete(int id)
        {
            TblAdmin t = repo.Fınd(x => x.AdminID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            TblAdmin t = repo.Fınd(x => x.AdminID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminUpdate(TblAdmin tblAdmin)
        {
            TblAdmin t = repo.Fınd(x => x.AdminID == tblAdmin.AdminID);
            t.UserName = tblAdmin.UserName;
            t.Password = tblAdmin.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}

