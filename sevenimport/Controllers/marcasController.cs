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
    public class marcasController : Controller
    {
        private importEntities db = new importEntities();

        // GET: marcas
        public async Task<ActionResult> Index()
        {
            var marcas = db.marcas.Include(m => m.empresa).Include(m => m.imageMarcas);
            return View(await marcas.ToListAsync());

        }








        // GET: marcas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marca marca = await db.marcas.FindAsync(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // GET: marcas/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name");
            return View();
        }

        // POST: marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Logo,IdEmpresa")] marca marca , List<HttpPostedFileBase> fileUpload)
        {
            if (ModelState.IsValid)
            {
                db.marcas.Add(marca);
                db.SaveChanges();
                int id = marca.Id;

                for (int i = 0; i < fileUpload.Count ; i++)
                {
                    imageMarca image = new imageMarca
                    {
                        Name = System.IO.Path.GetFileName(fileUpload[i].FileName),
                        Id = id
                    };
                    using (var reader = new System.IO.BinaryReader(fileUpload[i].InputStream))
                    {
                        image.Imagen = reader.ReadBytes(fileUpload[i].ContentLength);
                        db.imageMarcas.Add(image);
                        db.SaveChanges();
                    }
                }
                    



                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name", marca.IdEmpresa);
            return View(marca);
        }

        // GET: marcas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marca marca = await db.marcas.FindAsync(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name", marca.IdEmpresa);
            return View(marca);
        }

        // POST: marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Logo,IdEmpresa")] marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.empresas, "Id", "Name", marca.IdEmpresa);
            return View(marca);
        }

        // GET: marcas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marca marca = await db.marcas.FindAsync(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            marca marca = await db.marcas.FindAsync(id);
            db.marcas.Remove(marca);
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
