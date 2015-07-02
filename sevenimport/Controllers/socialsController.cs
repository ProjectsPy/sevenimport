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
    public class socialsController : Controller
    {
        private importEntities db = new importEntities();

        // GET: socials
        public async Task<ActionResult> Index()
        {
            return View(await db.socials.ToListAsync());
        }

        // GET: socials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            social social = await db.socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // GET: socials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,font,link,IdMarca")] social social)
        {
            if (ModelState.IsValid)
            {
                db.socials.Add(social);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(social);
        }

        // GET: socials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            social social = await db.socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,font,link")] social social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(social);
        }

        // GET: socials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            social social = await db.socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            social social = await db.socials.FindAsync(id);
            db.socials.Remove(social);
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
