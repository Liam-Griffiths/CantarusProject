using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    public class Item : ICheckoutItem
    {
        public string Name
        {
            get;
            set;
        }
    }
}
