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

            string modelToFind = null;
            Console.WriteLine("Please, enter a model, that you want to find: ");
            modelToFind = Console.ReadLine();
            int codeMessage = 1;
            while (codeMessage == 1 || codeMessage == 2)
            {
                foreach (var shop in shopNetwork)
                {
                    List<Phone> phones = new List<Phone>();
                    if(FindPhone(modelToFind, shop) != null)
                        phones.Add(FindPhone(modelToFind, shop));
                    codeMessage = ShowInfo(phones);
                    if (codeMessage == 1 || codeMessage == 2)
                    {
                        Console.WriteLine("Пожалуйста, повторите ввод модели телефона для поиска");
                        modelToFind = Console.ReadLine();
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
                shop.AddPhone((string)phones[i].Model, (string)phones[i].Brand, (OperatingSystemType)phones[i].Type, (bool)phones[i].IsAvailable, shop);
            }
        }
        static int ShowInfo(List<Phone> phones)
        {
            if (phones == null)
            {
                Console.WriteLine("Введенный Вами товар не найден");
                //Error code 1
                return 1;
            }
            foreach (var phone in phones)
            {
                if(phone != null && phone.IsAvailable == false)
                {
                    Console.WriteLine("Данный товар отсутствует на складе");
                    //Error code 2
                    return 2;
                }
                else
                    Console.WriteLine($"Model: {phone.Model}\n Brand: {phone.Brand}\n Available at the shop: {phone.ShopPlace.ShopName} ");
            }
            //Return 0 if all work perfect
            return 0;
        }
    }
}
