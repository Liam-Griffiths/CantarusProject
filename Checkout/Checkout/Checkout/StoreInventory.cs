using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    class StoreInventory : IStoreInventory
    {
        public Dictionary<string, IStoreItem> Inventory { get; set; }

        public void PopulateDefault()
        {

            Inventory = new Dictionary<string, IStoreItem>();

            var defaultList = new List<(string name, int price, int ruleQuantity, int rulePrice)>();

            defaultList.Add(("A", 50, 3, 130));
            defaultList.Add(("B", 30, 2, 45));
            defaultList.Add(("C", 20, -1, -1));
            defaultList.Add(("D", 15, -1, -1));

            foreach (var storeItem in defaultList)
            {
                StoreItem item = new StoreItem();
                item.Price = storeItem.price;
                item.Name = storeItem.name;
                item.RuleQuantity = storeItem.ruleQuantity;
                item.RulePrice = storeItem.rulePrice;

                if (!Inventory.ContainsKey(item.Name))
                {
                    Inventory.Add(item.Name, item);
                }
            }

        }

        public IStoreItem GetItem(string name)
        {
            if (Inventory.ContainsKey(name))
            {
                return Inventory[name];
            }
            else
            {
                return null;
            }
        }
    }

    class StoreItem : IStoreItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int RuleQuantity { get; set; }
        public int RulePrice { get; set; }
    }

}
