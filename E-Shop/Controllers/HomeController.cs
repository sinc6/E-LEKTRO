using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductRepository productRespository = new ProductRepository();
        public ActionResult Index(int sayfa=1)
        {
            return View(productRespository.List().ToPagedList(sayfa, 3));
        }
    }
}