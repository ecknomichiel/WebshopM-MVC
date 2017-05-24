using System;
using System.Collections.Generic;
using WebshopM_MVC.Models;

namespace WebshopM_MVC.DataAccess
{
    interface IShopContext
    {
        ShopItem Get(int aId);
        void Put(ShopItem aItem);
        void Delete(ShopItem aItem);
        void Save(IEnumerable<ShopItem> items);

        IEnumerable<ShopItem> GetAllItems();
    }

    static class ShopContextFactory
    {
        public static IShopContext CreateShopContext()
        {
            return new StoreContext();
        }
    }
}