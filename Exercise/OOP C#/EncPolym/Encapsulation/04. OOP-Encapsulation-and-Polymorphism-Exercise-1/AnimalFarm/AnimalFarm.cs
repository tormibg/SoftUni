namespace AnimalFarm
{
    using System;

    public class AnimalFarm
    {
        public static void Main()
        {
            Chicken chicken = new Chicken("AAA", 3);
            Console.WriteLine(chicken.ProductPerDay);
            chicken.Age = 20;
            Console.WriteLine(chicken.ProductPerDay);
        }
    }
}
