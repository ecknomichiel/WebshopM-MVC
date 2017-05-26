namespace WebshopM_MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebshopM_MVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebshopM_MVC.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebshopM_MVC.DataAccess.StoreContext context)
        {
             context.Items.AddOrUpdate(shop => shop.ArticleNumber, 
                        new ShopItem() { 
                            ArticleNumber = 1001, 
                            Description = "Fläsk av svenska grisar, förpackad i plastlådor på 800gr. Mathandverk. Ej KRAV-märkt.",
                            Name = "Fjällcharken fläsk (800)", 
                            Price = 120, 
                            Quantity = 47, 
                            ShelfPosition = "K001"});
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1002,
                            Description = "Fläsk av svenska grisar, förpackad i plastlådor på 400gr. Mathandverk. Ej KRAV-märkt.",
                            Name = "Fjällcharken fläsk (400)",
                            Price = 69.90,
                            Quantity = 30,
                            ShelfPosition = "K002"
                        });
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1003,
                            Description = "Kallrökt renstek från Fågelbergets Gårdchark, styckat och vacuumförpackad i styck på 500gr. Mathandverk. Ej KRAV-märkt.",
                            Name = "Gårdchark renstek (500)",
                            Price = 104.80,
                            Quantity = 15,
                            ShelfPosition = "K011"
                        });
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1004,
                            Description = "Kallrökt röding från fiskodlingen i Gäddede, styckat och vacuumförpackad i styck på 500gr. Mathandverk. Ej KRAV-märkt.",
                            Name = "Frostviksröding, rökt (500)",
                            Price = 60,
                            Quantity = 80,
                            ShelfPosition = "K021"
                        });
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1005,
                            Description = "Fryst rödingfilet från fiskodlingen i Gäddede, styckat och vacuumförpackad i styck på 1000gr. Mathandverk. Ej KRAV-märkt.",
                            Name = "Frostviksrödingsfilet (1000)",
                            Price = 75,
                            Quantity = 80,
                            ShelfPosition = "K022"
                        });
                    context.SaveChanges();
        }
    }
}
