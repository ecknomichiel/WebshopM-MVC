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

    interface ICreateableShopContext
    {
        public IShopContext Create();
    }

    static class ShopContextFactory
    {
        private static List<ICreateableShopContext> contexts = new List<ICreateableShopContext>(){new StoreContext()};
        public static IShopContext CreateShopContext()
        { //return a new instance of the last registered context type.
            return contexts[contexts.Count - 1].Create();
        }

        public static void RegisterContext(ICreateableShopContext context)
        {
            contexts.Add(context);
        }
    }

}