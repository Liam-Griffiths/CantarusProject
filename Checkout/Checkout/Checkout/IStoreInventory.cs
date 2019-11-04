using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    interface IStoreItem
    {
        string Name { get; set; }
        int Price { get; set; }
        int RuleQuantity { get; set; }
        int RulePrice { get; set; }

        // We could possibly include stock counts here.
    }

    interface IStoreInventory
    {
        Dictionary<string, IStoreItem> Inventory { get; set; }
    }
}
