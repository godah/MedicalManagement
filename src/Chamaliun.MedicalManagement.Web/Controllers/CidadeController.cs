using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chamaliun.MedicalManagement.Domain.Entities;
using Chamaliun.MedicalManagement.Infra.Data.ORM.EF;

namespace Chamaliun.MedicalManagement.Web.Controllers
{
    public class CidadeController : Controller
    {
        private MMDbContext db = new MMDbContext();

        // GET: Cidade
        public async Task<ActionResult> Index()
        {
            var cidade = db.Cidade.Include(c => c.Uf);
            return View(await cidade.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla");
            return View();
        }

        // POST: Cidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao,UfId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla", cidade.UfId);
            return View(cidade);
        }

        // GET: Cidade/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla", cidade.UfId);
            return View(cidade);
        }

        // POST: Cidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao,UfId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UfId = new SelectList(db.Uf, "Id", "Sigla", cidade.UfId);
            return View(cidade);
        }

        // GET: Cidade/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cidade cidade = await db.Cidade.FindAsync(id);
            db.Cidade.Remove(cidade);
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
