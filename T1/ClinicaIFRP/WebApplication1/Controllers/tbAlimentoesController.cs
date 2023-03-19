using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tbAlimentoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbAlimentoes
        public ActionResult Index()
        {
            return View(db.tbAlimento.ToList());
        }

        // GET: tbAlimentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            if (tbAlimento == null)
            {
                return HttpNotFound();
            }
            return View(tbAlimento);
        }

        // GET: tbAlimentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbAlimentoes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlimento,IdTipoQuantidade,Nome,Carboidrato,VitaminaA,VitaminaB")] tbAlimento tbAlimento)
        {
            if (ModelState.IsValid)
            {
                db.tbAlimento.Add(tbAlimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbAlimento);
        }

        // GET: tbAlimentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            if (tbAlimento == null)
            {
                return HttpNotFound();
            }
            return View(tbAlimento);
        }

        // POST: tbAlimentoes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlimento,IdTipoQuantidade,Nome,Carboidrato,VitaminaA,VitaminaB")] tbAlimento tbAlimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbAlimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbAlimento);
        }

        // GET: tbAlimentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            if (tbAlimento == null)
            {
                return HttpNotFound();
            }
            return View(tbAlimento);
        }

        // POST: tbAlimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            db.tbAlimento.Remove(tbAlimento);
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
