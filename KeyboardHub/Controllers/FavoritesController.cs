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
    public class FavoritesController : Controller
    {
        private KeyboardHubDB db = new KeyboardHubDB();

        // GET: Favorites
        public async Task<ActionResult> Index()
        {
            var favorites = db.Favorites.Include(f => f.AspNetUser1);
            return View(await favorites.ToListAsync());
        }

        // GET: Favorites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorite favorite = await db.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return HttpNotFound();
            }
            return View(favorite);
        }

        // GET: Favorites/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FavoriteID,C_URL,AspNetUser")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                db.Favorites.Add(favorite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", favorite.AspNetUser);
            return View(favorite);
        }

        // GET: Favorites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorite favorite = await db.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", favorite.AspNetUser);
            return View(favorite);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FavoriteID,C_URL,AspNetUser")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favorite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", favorite.AspNetUser);
            return View(favorite);
        }

        // GET: Favorites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorite favorite = await db.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return HttpNotFound();
            }
            return View(favorite);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Favorite favorite = await db.Favorites.FindAsync(id);
            db.Favorites.Remove(favorite);
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
