using System;


namespace LaptopShop
{
    class Laptop
    {
        private string model;
        private decimal price;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private int hdd;
        private float screen;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer) : this(model, price)
        {
            this.Manufacturer = manufacturer;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor) : this(model, price, manufacturer)
        {
            this.Processor = processor;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram) : this(model, price, manufacturer, processor)
        {
            this.RAM = ram;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard)
            : this(model, price, manufacturer, processor, ram)
        {
            this.GraphicsCard = graphicsCard;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard, int hdd)
            : this(model, price, manufacturer, processor, ram, graphicsCard)
        {
            this.HDD = hdd;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard, int hdd, float screen)
            : this(model, price, manufacturer, processor, ram, graphicsCard, hdd)
        {
            this.Screen = screen;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard, int hdd, float screen, Battery lapBattery)
            : this(model, price, manufacturer, processor, ram, graphicsCard, hdd, screen)
        {
            this.LapBattery = lapBattery;
        }

        public string Model {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be empty!");
                }
                this.model = value;
            } 
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative !");
                }
                this.price = value;
            } 
        }
        public string Manufacturer {
            get { return this.manufacturer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manufacturer cannot be empty!");
                }
                this.manufacturer = value;
            } 
        }
        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Processor cannot be empty!");
                }
                this.processor = value;
            } 
        }
        public int RAM
        {
            get { return this.ram; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("RAM cannot be negative !");
                }
                this.ram = value;
            } 
        }
        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("GraphicsCard cannot be empty!");
                }
                this.graphicsCard =  value;
            } 
        }
        public int HDD
        {
            get { return this.hdd; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("HDD cannot be negative !");
                }
                this.hdd = value;
            } 
        }
        public float Screen
        {
            get { return this.screen; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Screen cannot be negative !");
                }
                this.screen = value;
            } 
        }

        public Battery LapBattery { get; set; }

        public override string ToString()
        {
            string retStr =
                string.Format(
                    "model : {0}, price : {1} лв, Manufacturer : {2}, Processor : {3}, RAM : {4}, Graphics Card : {5}, HDD : {6}, Screen : {7}",
                    this.Model, this.Price, this.Manufacturer, this.Processor, this.RAM, this.GraphicsCard, this.HDD, this.Screen);
            return retStr;
        }
    }
}
