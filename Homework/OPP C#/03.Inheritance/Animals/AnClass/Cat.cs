using System;

namespace Animals.AnClass
{
    abstract class Cat : Animal
    {
        protected Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miaaaaaauuuuu");
        }
    }
}
