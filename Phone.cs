using System;
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
        public bool IsAvailable { get; set; }
        public OperatingSystemType Type { get; set; }

        public Phone()
        {

        }
        public Phone(string model, string brand, OperatingSystemType type, bool isAvailable)
        {
            Model = model;
            Brand = brand;
            Type = type;
            IsAvailable = isAvailable;
        }
    }
}
