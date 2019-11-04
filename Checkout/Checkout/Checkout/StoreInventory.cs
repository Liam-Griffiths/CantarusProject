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

            var defaultList = new List<(string name, int price, int ruleQuantity, int rulePrice)>();

            defaultList.Add(("A", 50, 3, 130 ));
            defaultList.Add(("B", 50, 3, 130));
            defaultList.Add(("C", 20, -1, -1));
            defaultList.Add(("D", 15, -1, -1));

            foreach (var storeItem in defaultList)
            {
                IStoreItem item = new Object() as IStoreItem;
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

    }
}
