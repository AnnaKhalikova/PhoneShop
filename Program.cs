using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Phone_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\Users\aikha\Downloads\.NET\Phone Shop\bin\Debug\netcoreapp3.1\TheFirstShop.json";
            string path2 = @"C:\Users\aikha\Downloads\.NET\Phone Shop\bin\Debug\netcoreapp3.1\TheSecondShop.json";

            Console.WriteLine("Hello! You at the phone shop!");
            IList<Phone> phonesForFirstShop = ReadJSONFromFile(path1);
            IList<Phone> phonesForSecondShop = ReadJSONFromFile(path2);
            List<Shop> shopNetwork = new List<Shop>();

            shopNetwork.Add(new Shop("PhoneStore1"));
            shopNetwork.Add(new Shop("PhoneStore2"));

            FillTheListOfPhones(phonesForFirstShop, shopNetwork[0]);
            FillTheListOfPhones(phonesForSecondShop, shopNetwork[1]);

            //Show info about shops
            foreach(var shop in shopNetwork)
            {
                ShowInfoAboutShop(shop);
            }

            string modelToFind = null;
            Console.WriteLine("Please, enter a model, that you want to find: ");
            modelToFind = Console.ReadLine();
            int codeMessage = -1;
            while (codeMessage == -1 || codeMessage == -2)
            {
                
                foreach (var shop in shopNetwork)
                {
                    List<Phone> phones = new List<Phone>();

                    if (FindPhone(modelToFind, shop) != null)
                    {
                        phones.Add(FindPhone(modelToFind, shop));
                        codeMessage = ShowInfo(phones);

                        if (phones[0].IsAvailable)
                        {
                            string shopName = null;
                            Console.WriteLine($"В каком магазине вы хотите приобрести {phones[0].Model}");
                            shopName = Console.ReadLine();
                            int shopReturnsCode = 0;
                            do
                            {
                                shopReturnsCode = ChooseShopAndOrderPhone(phones[0], shopNetwork, shopName);
                                if (shopReturnsCode == 1)
                                {
                                    Console.WriteLine("Спасибо, что выбрали нас");
                                }
                                else
                                {
                                    Console.WriteLine($"Магазин {shop.ShopName} не найден");
                                    Console.WriteLine("Повторите ввод названия магазина:");
                                    shopName = Console.ReadLine();
                                }
                            } while (shopReturnsCode != 1);
                        }
                      
                        if (codeMessage == -1 || codeMessage == -2)
                        {
                            Console.WriteLine("Пожалуйста, повторите ввод модели телефона для поиска");
                            modelToFind = Console.ReadLine();
                        }
                    }                                    
                }
            }
        }
        static void ShowInfoAboutShop(Shop shop)
        {
            Console.WriteLine("Shop name: " + shop.ShopName);
            Console.WriteLine("Amount of available iOS phones: " + shop.CalculatePhonesByType(OperatingSystemType.iOS));
            Console.WriteLine("Amount of available Android phones: " + shop.CalculatePhonesByType(OperatingSystemType.Android));
        }
        static Phone FindPhone(string model, Shop shop)
        {
            Phone phone = null;
            foreach (var item in shop.Phones)
            {
                if (item.Model == model)
                {
                    phone = item;
                }
            }

            return phone;
        }
        static IList<Phone> ReadJSONFromFile(string path)
        {
            JObject o;
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                o = (JObject)JToken.ReadFrom(reader);
            }
            JArray a = (JArray)o["d"];

            IList<Phone> phones = a.ToObject<IList<Phone>>();

            return phones;
        }
        static void FillTheListOfPhones(IList<Phone> phones, Shop shop)
        {

            for (int i = 0; i < phones.Count; i++)
            {
                shop.AddPhone((string)phones[i].Model, (string)phones[i].Brand,(double)phones[i].Price, (OperatingSystemType)phones[i].Type, (bool)phones[i].IsAvailable, shop);
            }
        }
        static int ShowInfo(List<Phone> phones)
        {
            int indexOfPhone = 0;
            if (phones == null)
            {
                Console.WriteLine("Введенный Вами товар не найден");
                //Error code 1
                return -1;
            }
            foreach (var phone in phones)
            {
                if (phone != null && phone.IsAvailable == false)
                {
                    Console.WriteLine("Данный товар отсутствует на складе");
                    //Error code 2
                    return -2;
                }
                else
                {
                    Console.WriteLine($"Model: {phone.Model}\n Brand: {phone.Brand}\n Available at the shop: {phone.ShopPlace.ShopName} ");
                    indexOfPhone = phones.IndexOf(phone);
                }
                    
            }
            //Return index of finded phone if all work perfect
            return indexOfPhone;
        }
        
        static int ChooseShopAndOrderPhone(Phone phone, List<Shop> shops, string shopName)
        {
            
            foreach(var shop in shops)
            {
                if(shop.ShopName == shopName)
                {
                    if (FindPhone(phone.Model, shop) != null)
                    {
                        Console.WriteLine($"Заказ {phone.Model} на сумму {phone.Price} успешно оформлен!");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine($"Такой модели в магазине {shop.ShopName} нет");
                    }
                    
                }               
            }
            return 0;
        }
    }
}
