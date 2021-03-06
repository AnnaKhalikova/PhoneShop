﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Shop
{
    enum OperatingSystemType
    {
        iOS,
        Android
    };
    class Phone
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public Shop ShopPlace { get; set; }
        public OperatingSystemType Type { get; set; }

        public Phone()
        {

        }
        public Phone(string model, string brand, double price, OperatingSystemType type, bool isAvailable, Shop shop)
        {
            Model = model;
            Brand = brand;
            Price = price;
            Type = type;
            IsAvailable = isAvailable;
            ShopPlace = shop; 
        }
    }
}
