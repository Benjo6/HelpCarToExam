using System;

namespace Lib
{
    public class Car
    {
        public Car()
        {
        }

        public Car(int id, string model, string vendor, int price)
        {
            Id = id;
            Model = model;
            Vendor = vendor;
            Price = price;
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public int Price { get; set; }
    }
}
