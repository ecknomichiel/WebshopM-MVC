using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebshopM_MVC.Models;
using WebshopM_MVC.Repositories;

namespace WebshopM_MVC.Controllers
{
    public class ShopController : Controller
    {
        private Shop shop = Shop.Instance;

        // GET: Shop
        public ActionResult Index()
        {
            return View(shop.GetAllItems());
        }

        // GET: Shop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = shop.Get(id.Value);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleNumber,Name,Price,ShelfPosition,Quantity,Description")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                shop.Add(shopItem);
                return RedirectToAction("Index");
            }

            return View(shopItem);
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = shop.Get(id.Value);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleNumber,Name,Price,ShelfPosition,Quantity,Description")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {   // shopItem is actually a new instance with all the values set
                shop.Update(shopItem);
                return RedirectToAction("Index");
            }
            return View(shopItem);
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = shop.Get(id.Value);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopItem shopItem = shop.Get(id);
            shop.Delete(shopItem);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Dispose of shop? Save changes to database if cached?
                shop.Save();
            }
            base.Dispose(disposing);
        }
    }
}
