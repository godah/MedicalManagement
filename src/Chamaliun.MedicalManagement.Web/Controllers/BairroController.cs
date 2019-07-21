using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Chamaliun.MedicalManagement.Domain.Entities;
using Chamaliun.MedicalManagement.Infra.Data.ORM.EF;

namespace Chamaliun.MedicalManagement.Web.Controllers
{
    public class BairroController : Controller
    {
        private MMDbContext db = new MMDbContext();

        // GET: Bairro
        public async Task<ActionResult> Index()
        {
            var bairro = db.Bairro.Include(b => b.Cidade);
            return View(await bairro.ToListAsync());
        }

        // GET: Bairro/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = await db.Bairro.FindAsync(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // GET: Bairro/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidade, "Id", "Descricao");
            return View();
        }

        // POST: Bairro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao,CidadeId")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Bairro.Add(bairro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidade, "Id", "Descricao", bairro.CidadeId);
            return View(bairro);
        }

        // GET: Bairro/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = await db.Bairro.FindAsync(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidade, "Id", "Descricao", bairro.CidadeId);
            return View(bairro);
        }

        // POST: Bairro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao,CidadeId")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bairro).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidade, "Id", "Descricao", bairro.CidadeId);
            return View(bairro);
        }

        // GET: Bairro/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = await db.Bairro.FindAsync(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // POST: Bairro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bairro bairro = await db.Bairro.FindAsync(id);
            db.Bairro.Remove(bairro);
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
