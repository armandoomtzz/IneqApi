using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class StatusController : ApiController
    {
        // READ ALL
        public ActionResult List()
        {
            return View(dc.Status.ToList());
        }
        //READ SINGLE
        public ActionResult Details(int id = 0)
        {
            return View(dc.Status.Find(id));
        }
        //CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Status br)
        {
            using (dc)
            {
                dc.Status.Add(br);
                dc.SaveChanges();

            }
            return RedirectToAction("List");
        }
        //UPDATE
        public ActionResult Edit(int id = 0)
        {
            return View(dc.Status.Find(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Status br)
        {
            dc.Entry(br).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("List");
        }

        //DELETE
        public ActionResult Delete(int id = 0)
        {
            return View(dc.ComponentTypes.Find(id));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Status br = dc.Statuses.Find(id);
            dc.Status.Remove(eq);
            dc.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

