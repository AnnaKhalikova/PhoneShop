using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone_Shop
{
    class Shop
    {
        public List<Phone> Phones;
        public string ShopName { get; set; }
        public Shop(string shopName)
        {
            ShopName = shopName;
            Phones = new List<Phone>();
        }
        public void AddPhone(string model, string brand,double price, OperatingSystemType type, bool isAvailable, Shop shop)
        {
            Phones.Add(new Phone(model, brand, price, type, isAvailable, shop));
        }
        public int CalculatePhonesByType(OperatingSystemType type)
        {
            int amount = 0;
            foreach(var phone in Phones)
            {
                if (phone.Type == type && phone.IsAvailable == true)
                   amount++;
            }
            return amount;
        }
    }
}
