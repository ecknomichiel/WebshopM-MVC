using System;
using System.ComponentModel.DataAnnotations;

namespace WebshopM_MVC.Models
{
    public class ShopItem
    {
        [Key]
        public int ArticleNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public bool Equals(ShopItem other)
        {
            return (other != null
                && ArticleNumber == other.ArticleNumber
                && Name == other.Name
                && Price == other.Price
                && ShelfPosition == other.ShelfPosition
                && Quantity == other.Quantity
                && Description == other.Description
                );
        }

        public void Assign(ShopItem other)
        {
            if (other == null)
                other = new ShopItem();
            ArticleNumber = other.ArticleNumber;
            Name = other.Name;
            Price = other.Price;
            ShelfPosition = other.ShelfPosition;
            Quantity = other.Quantity;
            Description = other.Description;
        }
    }
}