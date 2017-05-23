using System;

namespace WebshopM_MVC.Models
{
    public class ShopItem
    {
        [key]
        public int ArticleNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}