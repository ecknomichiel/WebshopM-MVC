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
                            Description = "Fl�sk av svenska grisar, f�rpackad i plastl�dor p� 800gr. Mathandverk. Ej KRAV-m�rkt.",
                            Name = "Fj�llcharken fl�sk (800)", 
                            Price = 120, 
                            Quantity = 47, 
                            ShelfPosition = "K001"});
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1002,
                            Description = "Fl�sk av svenska grisar, f�rpackad i plastl�dor p� 400gr. Mathandverk. Ej KRAV-m�rkt.",
                            Name = "Fj�llcharken fl�sk (400)",
                            Price = 69.90,
                            Quantity = 30,
                            ShelfPosition = "K002"
                        });
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1003,
                            Description = "Kallr�kt renstek fr�n F�gelbergets G�rdchark, styckat och vacuumf�rpackad i styck p� 500gr. Mathandverk. Ej KRAV-m�rkt.",
                            Name = "G�rdchark renstek (500)",
                            Price = 104.80,
                            Quantity = 15,
                            ShelfPosition = "K011"
                        });
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1004,
                            Description = "Kallr�kt r�ding fr�n fiskodlingen i G�ddede, styckat och vacuumf�rpackad i styck p� 500gr. Mathandverk. Ej KRAV-m�rkt.",
                            Name = "Frostviksr�ding, r�kt (500)",
                            Price = 60,
                            Quantity = 80,
                            ShelfPosition = "K021"
                        });
                    context.Items.AddOrUpdate(shop => shop.ArticleNumber,
                        new ShopItem()
                        {
                            ArticleNumber = 1005,
                            Description = "Fryst r�dingfilet fr�n fiskodlingen i G�ddede, styckat och vacuumf�rpackad i styck p� 1000gr. Mathandverk. Ej KRAV-m�rkt.",
                            Name = "Frostviksr�dingsfilet (1000)",
                            Price = 75,
                            Quantity = 80,
                            ShelfPosition = "K022"
                        });
                    context.SaveChanges();
        }
    }
}
