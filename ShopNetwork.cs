using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Shop
{
    class ShopNetwork
    {
        List<Shop> shops;
        public ShopNetwork()
        {
            List<Shop> shops = new List<Shop>();
        }
        void AddNewShop()
        {
            shops.Add(new Shop());
        }
    }
}
