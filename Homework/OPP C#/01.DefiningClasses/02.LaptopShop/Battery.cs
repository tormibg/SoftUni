using System;

namespace LaptopShop
{
    class Battery
    {
        private string model;
        private float batteryLife;

        public Battery(string model, float batteryLife)
        {
            this.Model = model;
            this.BatteryLife = batteryLife;
        }

        public string Model { get; set; }
        public float BatteryLife { get; set; }

    }
}
