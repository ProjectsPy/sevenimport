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
    public class slidersController : Controller
    {
        private importEntities db = new importEntities();

        // GET: sliders
        public async Task<ActionResult> Index()
        {
            var sliders = db.sliders.Include(s => s.marca);
            return View(await sliders.ToListAsync());
        }

        // GET: sliders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slider slider = await db.sliders.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: sliders/Create
        public ActionResult Create()
        {
            ViewBag.IdMarca = new SelectList(db.marcas, "Id", "Name");
            return View();
        }

        // POST: sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Link,IdMarca")] slider slider)
        {
            if (ModelState.IsValid)
            {
                db.sliders.Add(slider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.marcas, "Id", "Name", slider.IdMarca);
            return View(slider);
        }

        // GET: sliders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slider slider = await db.sliders.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMarca = new SelectList(db.marcas, "Id", "Name", slider.IdMarca);
            return View(slider);
        }

        // POST: sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Link,IdMarca")] slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdMarca = new SelectList(db.marcas, "Id", "Name", slider.IdMarca);
            return View(slider);
        }

        // GET: sliders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slider slider = await db.sliders.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            slider slider = await db.sliders.FindAsync(id);
            db.sliders.Remove(slider);
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
