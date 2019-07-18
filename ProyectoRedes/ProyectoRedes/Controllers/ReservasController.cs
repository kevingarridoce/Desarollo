using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoRedes.Models;

namespace ProyectoRedes.Controllers
{
    public class ReservasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Equipos).Include(r => r.Laboratorio).Include(r => r.Profesor);
            return View(reservas.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }
        [Authorize(Roles = "Admin, Profesor")]
        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.EquiposID = new SelectList(db.Equipos, "EquiposID", "Modelo");
            ViewBag.LaboratorioID = new SelectList(db.Laboratorios, "LaboratorioID", "LaboratorioID");
            ViewBag.ProfesorID = new SelectList(db.Profesors, "ProfesorID", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaID,LaboratorioID,ProfesorID,EquiposID,FechaReserva,FechaDiaLab,Descripcion,CantidadEquipos")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquiposID = new SelectList(db.Equipos, "EquiposID", "Modelo", reserva.EquiposID);
            ViewBag.LaboratorioID = new SelectList(db.Laboratorios, "LaboratorioID", "LaboratorioID", reserva.LaboratorioID);
            ViewBag.ProfesorID = new SelectList(db.Profesors, "ProfesorID", "Nombre", reserva.ProfesorID);
            return View(reserva);
        }
        [Authorize(Roles = "Admin, Profesor")]
        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquiposID = new SelectList(db.Equipos, "EquiposID", "Modelo", reserva.EquiposID);
            ViewBag.LaboratorioID = new SelectList(db.Laboratorios, "LaboratorioID", "LaboratorioID", reserva.LaboratorioID);
            ViewBag.ProfesorID = new SelectList(db.Profesors, "ProfesorID", "Nombre", reserva.ProfesorID);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaID,LaboratorioID,ProfesorID,EquiposID,FechaReserva,FechaDiaLab,Descripcion,CantidadEquipos")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquiposID = new SelectList(db.Equipos, "EquiposID", "Modelo", reserva.EquiposID);
            ViewBag.LaboratorioID = new SelectList(db.Laboratorios, "LaboratorioID", "LaboratorioID", reserva.LaboratorioID);
            ViewBag.ProfesorID = new SelectList(db.Profesors, "ProfesorID", "Nombre", reserva.ProfesorID);
            return View(reserva);
        }
        [Authorize(Roles = "Admin, Profesor")]
        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
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
