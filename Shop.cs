using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone_Shop
{
    class Shop
    {
        List<Phone> Phones;
        public Shop()
        {
            Phones = new List<Phone>();
        }
        void AddPhone(string model, string brand, OperatingSystemType type, bool isAvailable)
        {
            Phones.Add(new Phone(model, brand, type, isAvailable));
        }
        Phone FindPhone(string model)
        {
            Phone phone = null;
            foreach(var item in Phones)
            {
                if(item.Model == model)
                {
                    phone = item;
                }
            }
            return phone;
        }
    }
}
