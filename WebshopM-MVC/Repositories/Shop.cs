using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopM_MVC.Models;
using WebshopM_MVC.DataAccess;

namespace WebshopM_MVC.Repositories
{
    public class Shop
    { //Singleton class
        #region private attributes
        private List<ShopItem> memoryItems = new List<ShopItem>();
        private IShopContext context; //Is null when caching (SaveOnClose == true)
        private static Shop instance;
        private int maxId;
        #endregion
        #region Singleton pattern
        public static Shop Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new Shop();
                }
                return instance;
            }
        }
        #endregion
        #region Properties
        public bool SaveOnClose
        {
            get { return context == null; }
            set
            {
                if (SaveOnClose != value)
                {
                    if (SaveOnClose)
                    {
                        //It is possible changes had built up
                        context = ShopContextFactory.CreateShopContext();
                        Save(true);
                    }
                    else
                    { //No changes had built up, so free context immediately
                        context = null;
                    }
                }
            }
        }
        private int NextId
        { // increment maxId by one and return it. I used maxId in order to prevent confusion between nextId and NextId
            // in real-life situations, consider moving this to the IShopContext
            get { return ++maxId; }
        }
        
        #endregion
        #region Search methods
        public IEnumerable<ShopItem> GetAllItems()
        {
            return memoryItems;
        }
        public IEnumerable<ShopItem> GetAllItemsOnPrice(double aPrice, bool greaterThan = false)
        {
            return memoryItems.Where(item => (greaterThan && item.Price >= aPrice)
                                            || (!greaterThan && item.Price <= aPrice));
        }
        public IEnumerable<ShopItem> GetAllItemsOnName(string aName)
        {
            return memoryItems.Where(item => item.Name.Contains(aName));
        }
        #endregion
        public IEnumerable<ShopItem> GetAllItemsOnNameAndPrice(double price, string name, bool greaterThan)
        {
            return GetAllItemsOnPrice(price, greaterThan).Where(item => item.Name.Contains(name));
        }
        #region Data access
        public ShopItem Get(int aId)
        {// returns null if id not found
            return memoryItems.SingleOrDefault(i => i.ArticleNumber == aId);
        }
        public void Add(ShopItem item)
        {
            if (item.ArticleNumber > 0 && Get(item.ArticleNumber) != null)
                throw new Exception(String.Format("Trying to add an existing item: ({0})", item.ToString()));

            item.ArticleNumber = NextId;

            memoryItems.Add(item);
            if (!SaveOnClose)
            {
                context.Put(item);
            } 
        }
        public void Update(ShopItem valueItem)
        {
            ShopItem repositoryItem = Get(valueItem.ArticleNumber);
            if (repositoryItem == null)
                throw new Exception(String.Format("Trying to update an item that does not exist yet: ({0})", valueItem.ToString()));

            if (!repositoryItem.Equals(valueItem) )
            {
                repositoryItem.Assign(valueItem);
            }

            if (!SaveOnClose)
            {
                context.Put(repositoryItem);
            }
        }
        public void Delete(ShopItem item)
        {
            memoryItems.Remove(item);
            if (!SaveOnClose)
                context.Delete(item);
        }

        public void Save(bool force = false)
        {
            //Ignore this if not forced or SaveOnClose 
            if (!(force || SaveOnClose))
                return;

            IShopContext saveContext;
            if (context == null)
            {
                saveContext = ShopContextFactory.CreateShopContext();
            }
            else
            {
                saveContext = context;
            }
            saveContext.Save(memoryItems);
        }
        #endregion
        #region Construction / Destruction
        private Shop()
        {
            IShopContext context = ShopContextFactory.CreateShopContext();
            memoryItems.AddRange(context.GetAllItems());
            maxId = memoryItems.Max(item => item.ArticleNumber);
        }

        ~Shop()  // destructor
        {
            Save(true);
        }
        #endregion



        
    }
}
