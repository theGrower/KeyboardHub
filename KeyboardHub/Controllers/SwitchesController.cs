using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KeyboardHub.Models;

namespace KeyboardHub.Controllers
{
    public class SwitchesController : Controller
    {
        private KeyboardHubDB db = new KeyboardHubDB();

        // GET: Switches
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = await db.Switches.FindAsync(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            return View(@switch);
        }

        // GET: Switches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = await db.Switches.FindAsync(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            return View(@switch);
        }

        // GET: Switches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Switches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SwitchID,Color,Type,AccuationForce,Description,TouchAudio,TouchOringAudio,BottomAudio,BottomOringAudio,GIFPath")] Switch @switch)
        {
            if (ModelState.IsValid)
            {
                db.Switches.Add(@switch);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(@switch);
        }

        // GET: Switches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = await db.Switches.FindAsync(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            return View(@switch);
        }

        // POST: Switches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SwitchID,Color,Type,AccuationForce,Description,TouchAudio,TouchOringAudio,BottomAudio,BottomOringAudio,GIFPath")] Switch @switch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@switch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(@switch);
        }

        // GET: Switches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Switch @switch = await db.Switches.FindAsync(id);
            if (@switch == null)
            {
                return HttpNotFound();
            }
            return View(@switch);
        }

        // POST: Switches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Switch @switch = await db.Switches.FindAsync(id);
            db.Switches.Remove(@switch);
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
