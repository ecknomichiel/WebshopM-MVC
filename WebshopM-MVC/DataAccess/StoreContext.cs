using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WebshopM_MVC.Models;
/* This is like a datamodule for the store */
namespace WebshopM_MVC.DataAccess
{
    public class StoreContext: DbContext, IShopContext, ICreateableShopContext
    {
        //Items is made public for speeding up seeding. In actual use, it is accessed through 
        //the IShopContext interface only
        public DbSet<Models.ShopItem> Items { get; set; }

        #region Constructor
        public StoreContext():base("DefaultConnection")
        { }
        #endregion

        #region :IShopContext
        public void Put(ShopItem aItem)
        {
            ShopItem dbItem = Items.Find(aItem.ArticleNumber);
            if (dbItem == null)
            {
                //Insert
                Items.Add(aItem);
            }
            else
            {
                Entry(dbItem).CurrentValues.SetValues(aItem);
            }
            SaveChanges();
        }

        public ShopItem Get(int aId)
        {
            return Items.Find(aId);
        }

        public void Delete(ShopItem aItem)
        {
            Entry(aItem).State = EntityState.Deleted;
            SaveChanges();
        }

        public void Save(IEnumerable<ShopItem> items)
        {
            ShopItem mi;
            List<ShopItem> itemsToAdd = new List<ShopItem>();
            itemsToAdd.AddRange(items);
            foreach (ShopItem pi in Items)
            {
                mi = items.SingleOrDefault(i => i.ArticleNumber == pi.ArticleNumber);
                if (mi == null)
                {
                    //Item deleted from memory
                    Entry(pi).State = EntityState.Deleted;
                }
                else
                {
                    if (!pi.Equals(mi))
                    {
                        Entry(pi).CurrentValues.SetValues(mi);
                    }
                    
                    itemsToAdd.Remove(mi);
                }
            }
            foreach (ShopItem newItem in itemsToAdd)
            {
                Items.Add(newItem);
            }
            SaveChanges();
        }

        public IEnumerable<ShopItem> GetAllItems()
        {
            return Items;
        }
        #endregion


        public IShopContext Create()
        {
            return new StoreContext();
        }
    }
}