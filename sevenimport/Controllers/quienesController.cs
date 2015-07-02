using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sevenimport;

namespace sevenimport.Controllers
{
    public class quienesController : Controller
    {
        private importEntities db = new importEntities();

        // GET: quienes
        public async Task<ActionResult> Index()
        {
            var quienes = db.quienes.Include(q => q.empresa);
            return View(await quienes.ToListAsync());
        }

        // GET: quienes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiene quiene = await db.quienes.FindAsync(id);
            if (quiene == null)
            {
                return HttpNotFound();
            }
            return View(quiene);
        }

        // GET: quienes/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name");
            return View();
        }

        // POST: quienes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Tittle,Description,IdEmpresa")] quiene quiene)
        {
            if (ModelState.IsValid)
            {
                db.quienes.Add(quiene);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name", quiene.IdEmpresa);
            return View(quiene);
        }

        // GET: quienes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiene quiene = await db.quienes.FindAsync(id);
            if (quiene == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name", quiene.IdEmpresa);
            return View(quiene);
        }

        // POST: quienes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Tittle,Description,IdEmpresa")] quiene quiene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiene).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name", quiene.IdEmpresa);
            return View(quiene);
        }

        // GET: quienes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiene quiene = await db.quienes.FindAsync(id);
            if (quiene == null)
            {
                return HttpNotFound();
            }
            return View(quiene);
        }

        // POST: quienes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            quiene quiene = await db.quienes.FindAsync(id);
            db.quienes.Remove(quiene);
            await db.SaveChangesAsync();
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
