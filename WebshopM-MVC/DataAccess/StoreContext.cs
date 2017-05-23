using System;
using System.Data.Entity;
/* This is like a datamodule for the store */
namespace WebshopM_MVC.DataAccess
{
    public class StoreContext: DbContext
    {
        public DbSet<Models.ShopItem> Items { get; set; }

        public StoreContext():base("DefaultConnection")
        { }
    }
}