using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using MvcAjaxTest002;
//using Newtonsoft.Json;

namespace MVCTest.Controllers
{
    public class OUVRAGEsController : Controller
    {
        private librairieEntities db = new librairieEntities();

        // GET: OUVRAGEs
        public ActionResult Index()
        {
            var oUVRAGEs = db.OUVRAGEs.Include(o => o.CLASSIFICATION).Include(o => o.EDITEUR);
            return View(oUVRAGEs.ToList());
        }
        // POST: OUVRAGEs
        [HttpPost]
        public JsonResult Index(string selected, string find)
        {
            Debug.WriteLine(find);
            Debug.WriteLine(selected);
            //ViewBag.name = find;
            IQueryable<OUVRAGE> oUVRAGEs = db.OUVRAGEs;//.Include(o => o.CLASSIFICATION).Include(o => o.EDITEUR);
            if (find != null && find != "")
                oUVRAGEs = oUVRAGEs.Where(o => o.NOMOUVR.Contains(find));
            if (selected != null && selected != "")
            {
                int c = Convert.ToInt32(selected);
                oUVRAGEs = oUVRAGEs.Where(o => o.CLASSIFICATION.NUMRUB.Equals(c));
            }
            //ViewBag.selected = cls;
            //return View(oUVRAGEs.ToList());
            //JsonConvert.SerializeObject(oUVRAGEs.ToList())
            ViewBag.ouvId = oUVRAGEs.Select(o => new { o.NUMOUVR });
            return Json(oUVRAGEs.Select(o => new { o.NUMOUVR, o.NOMOUVR, o.ANNEEPARU, o.CLASSIFICATION.LIBRUB, o.EDITEUR.ADRED }));
        }

        // GET: OUVRAGEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OUVRAGE oUVRAGE = db.OUVRAGEs.Find(id);
            if (oUVRAGE == null)
            {
                return HttpNotFound();
            }
            return View(oUVRAGE);
        }

        // GET: OUVRAGEs/Create
        public ActionResult Create()
        {
            ViewBag.NUMRUB = new SelectList(db.CLASSIFICATIONs, "NUMRUB", "LIBRUB");
            ViewBag.NOMED = new SelectList(db.EDITEURs, "NOMED", "ADRED");
            return View();
        }

        // POST: OUVRAGEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NUMOUVR,NOMOUVR,ANNEEPARU,NUMRUB,NOMED")] OUVRAGE oUVRAGE)
        {
            if (ModelState.IsValid)
            {
                db.OUVRAGEs.Add(oUVRAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NUMRUB = new SelectList(db.CLASSIFICATIONs, "NUMRUB", "LIBRUB", oUVRAGE.NUMRUB);
            ViewBag.NOMED = new SelectList(db.EDITEURs, "NOMED", "ADRED", oUVRAGE.NOMED);
            return View(oUVRAGE);
        }

        // GET: OUVRAGEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OUVRAGE oUVRAGE = db.OUVRAGEs.Find(id);
            if (oUVRAGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.NUMRUB = new SelectList(db.CLASSIFICATIONs, "NUMRUB", "LIBRUB", oUVRAGE.NUMRUB);
            ViewBag.NOMED = new SelectList(db.EDITEURs, "NOMED", "ADRED", oUVRAGE.NOMED);
            return View(oUVRAGE);
        }

        // POST: OUVRAGEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NUMOUVR,NOMOUVR,ANNEEPARU,NUMRUB,NOMED")] OUVRAGE oUVRAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oUVRAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NUMRUB = new SelectList(db.CLASSIFICATIONs, "NUMRUB", "LIBRUB", oUVRAGE.NUMRUB);
            ViewBag.NOMED = new SelectList(db.EDITEURs, "NOMED", "ADRED", oUVRAGE.NOMED);
            return View(oUVRAGE);
        }

        // GET: OUVRAGEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OUVRAGE oUVRAGE = db.OUVRAGEs.Find(id);
            if (oUVRAGE == null)
            {
                return HttpNotFound();
            }
            return View(oUVRAGE);
        }

        // POST: OUVRAGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OUVRAGE oUVRAGE = db.OUVRAGEs.Find(id);
            db.OUVRAGEs.Remove(oUVRAGE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
