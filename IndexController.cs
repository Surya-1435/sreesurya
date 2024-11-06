using project2.Models.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;
using System.Drawing;


namespace project2.Controllers
{
    public class IndexController : Controller
    {
        Class1Context dal = new Class1Context();

        public ActionResult Index()
        {
            Class1 c = new Class1();
            List<Class1> li = dal.result.ToList();
            return View("Index", li);
        }
        public ActionResult Index2()
        {
            Class2 c = new Class2();
            List<Class2> li = dal.result2.ToList();
            return View("Indexer", li);
        }
        public ActionResult TvShows()
        {
            Class2 p = new Class2();
            return View("TvShows", p);
        }
        public ActionResult Create()
        {
            Class1 p = new Class1();
            return View("Create", p);
        }
        public ActionResult save(Class1 p)
        {
            p.anyName = Request.Files;
            HttpPostedFileBase a = p.anyName[0];
            string s = "~/images/store/" + a.FileName;
            p.ImagePath = s;
            a.SaveAs(Server.MapPath(p.ImagePath));
            dal.result.Add(p);
            dal.SaveChanges();
            List<Class1> li = dal.result.ToList();
            return View("Index", li);
        }
        public ActionResult down(Class2 p2)
        {
            p2.anyName = Request.Files;
            HttpPostedFileBase a = p2.anyName[0];
            string s = "~/images/store/" + a.FileName;
            p2.ImagePath = s;
            a.SaveAs(Server.MapPath(p2.ImagePath));
            dal.result2.Add(p2);
            dal.SaveChanges();
            List<Class2> li = dal.result2.ToList();
            return View("Indexer", li);
        }
        public ActionResult MovieDelete(int id)
        {
            Class1 d = dal.result.Find(id);
            dal.result.Remove(d);
            dal.SaveChanges();
            List<Class1> v = dal.result.ToList();
            return RedirectToAction("Index", v);
        }
        public ActionResult Movieedit(int id)
        {
            Class1 d = dal.result.Find(id);
            if (d.MovieId.Equals(id))
            {
                Class1 v = new Class1();
                Class1 s = dal.result.Find(id);
                v.MovieName = s.MovieName;
                v.MovieDescription = s.MovieDescription;

                return View("Movieedit", v);
            }
            else
            {
                return View();
            }
        }
        public ActionResult about()
        {
            Class1 c = new Class1();
            List<Class1> li = dal.result.ToList();
            return View("About", li);

          
        }
    }
}