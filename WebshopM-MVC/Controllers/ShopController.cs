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
             /*         <li>@Html.ActionLink("Home", "Index", "Shop")</li>
                    <li>@Html.ActionLink("Search", "Search", "Shop")</li>
                    <li>@Html.ActionLink("About", "About", "Shop")</li>
                    <li>@Html.ActionLink("Contact", "Contact", "Shop")</li>
                    <li>@Html.ActionLink("Settings", "Settings", "Shop")</li> */
    public class ShopController : Controller
    {
        private Shop shop = Shop.Instance;

        #region Index (home)
        // GET: Shop
        public ActionResult Index()
        {
            return View(shop.GetAllItems());
        }
        #endregion

        #region Details
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
        #endregion

        #region Create (add new product)
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
        { //This shares a lot with the edit view, so the views should have a partial view for the item details as well
            if (ModelState.IsValid)
            {
                shop.Add(shopItem);
                return RedirectToAction("Index");
            }

            return View(shopItem);
        }
        #endregion

        #region Edit
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
        #endregion

        #region Delete
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
        #endregion

        #region Search
        [HttpGet]
        public ActionResult Search()
        {
            return View(shop.GetAllItemsOnPrice(-1, false));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string value)
        {
            IEnumerable<ShopItem> searchResult;

            searchResult = shop.GetAllItems();

            return View(searchResult);
        }
        #endregion

        #region Settings
        public ActionResult Settings()
        {
            return View(shop);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(bool? saveOnClose)
        {
            //Change the settings here
            if (saveOnClose == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            shop.SaveOnClose = saveOnClose.Value;
            return View(shop);
        }

        #endregion


    }
}
