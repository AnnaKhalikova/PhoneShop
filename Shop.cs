using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone_Shop
{
    class Shop
    {
        List<Phone> Phones;
        public string ShopName { get; set; }
        public Shop(string shopName)
        {
            ShopName = shopName;
            Phones = new List<Phone>();
        }
        void AddPhone(string model, string brand, OperatingSystemType type, bool isAvailable)
        {
            Phones.Add(new Phone(model, brand, type, isAvailable));
        }
        //remade search method with Dictionary structure
        Phone FindPhone(string model, Shop shop)
        {
            Phone phone = null;
            Dictionary<Phone, Shop> searchDictionary = new Dictionary<Phone, Shop>();
            foreach(var item in Phones)
            {
                if(item.Model == model)
                {
                    phone = item;
                }
            }
            return phone;
        }
        string ShowInfo(Phone phone)
        {
            string result = null;
            if(phone == null)
            {
                result = "Введенный Вами товар не найден";
            }
            else if(phone != null == false)
            {
                result = "Данный товар отсутствует на складе";
            }
            else
            {
                result += "";
            }
            return result;
        }
    }
}
