using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace E_Shop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext DB = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comment(int sayfa=1)
        {
            return View(DB.Commnents.ToList().ToPagedList(sayfa,3));
        }

        public ActionResult Delete(int id)
        {
            var delete = DB.Commnents.Where(x => x.Id == id).FirstOrDefault();
            DB.Commnents.Remove(delete);
            DB.SaveChanges();
            return RedirectToAction("Comment");
        }
        public ActionResult UserList()
        {
            var user = DB.Users.Where(x => x.Role == "User").ToList();
            return View(user);
        }
        public ActionResult UserDelete(int id)
        {
            var userid = DB.Users.Where(x => x.Id == id).FirstOrDefault();
            DB.Users.Remove(userid);
            DB.SaveChanges();
            return RedirectToAction("UserList");
        }
    }
}