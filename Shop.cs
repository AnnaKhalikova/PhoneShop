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
        public void AddPhone(string model, string brand, OperatingSystemType type, bool isAvailable, Shop shop)
        {
            Phones.Add(new Phone(model, brand, type, isAvailable, shop));
        }
        //remade search method with Dictionary structure
        public Phone FindPhone(string model)
        {
            Phone phones = null;

            foreach (var item in Phones)
            {
                if (item.Model == model)
                {
                    phones = item;
                }
            }

            return phones;
        }
    }
}
