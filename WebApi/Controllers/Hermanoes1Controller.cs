using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class Hermanoes1Controller : Controller
    {
        private NuevaJerusalenEntities db = new NuevaJerusalenEntities();

        // GET: Hermanoes1
        public ActionResult Index()
        {
            return View(db.Hermano.ToList());
        }

        // GET: Hermanoes1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hermano hermano = db.Hermano.Find(id);
            if (hermano == null)
            {
                return HttpNotFound();
            }
            return View(hermano);
        }

        // GET: Hermanoes1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hermanoes1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cedula,nombre,apellidos,IdSexo,Fecha_Nac,IdProvincia,Ciudad,Direccion,Telefono,IdEstadoCivil,TipoSangre,Bautizo,FechaBautizo,activo")] Hermano hermano)
        {
            if (ModelState.IsValid)
            {
                db.Hermano.Add(hermano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hermano);
        }

        // GET: Hermanoes1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hermano hermano = db.Hermano.Find(id);
            if (hermano == null)
            {
                return HttpNotFound();
            }
            return View(hermano);
        }

        // POST: Hermanoes1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cedula,nombre,apellidos,IdSexo,Fecha_Nac,IdProvincia,Ciudad,Direccion,Telefono,IdEstadoCivil,TipoSangre,Bautizo,FechaBautizo,activo")] Hermano hermano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hermano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hermano);
        }

        // GET: Hermanoes1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hermano hermano = db.Hermano.Find(id);
            if (hermano == null)
            {
                return HttpNotFound();
            }
            return View(hermano);
        }

        // POST: Hermanoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hermano hermano = db.Hermano.Find(id);
            db.Hermano.Remove(hermano);
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
