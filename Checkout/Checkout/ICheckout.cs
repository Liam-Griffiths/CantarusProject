using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    interface ICheckout
    {
        void Scan(Item item);
        int Total();
    }
}
