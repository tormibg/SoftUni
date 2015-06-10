using System;
using System.CodeDom;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using Animals.AnClass;

namespace Animals
{
    class Animals
    {
        static void Main()
        {
            Animal[] allAnimals = new Animal[]
            {
                new Dog("Asen",23, "male"), 
                new Dog("Ivan",28, "male"), 
                new Dog("Mima",10, "female"), 
                new Dog("Ira",15, "female"), 
                new Frog("Frogy", 12, "male"),
                new Frog("Pesho", 20, "male"),
                new Frog("Mara", 10, "female"),
                new Frog("Vania", 5, "female"),               
                new Kitten("Mima", 18), 
                new Kitten("Nina", 19), 
                new Kitten("Pipi", 20), 
                new Kitten("Valia", 21), 
                new Tomcat("Ivan",22), 
                new Tomcat("Zaprian",23), 
                new Tomcat("Kolio",20), 
                new Tomcat("Petkan",30), 
            };
         
            foreach (var animal in allAnimals.GroupBy(clas => clas.GetType().Name))
            {
                Console.WriteLine("{0} - average age : {1}",animal.Key, animal.Select(x => x.Age).Average());
            }

            Console.WriteLine();

            Console.WriteLine("{0} - average age : {1}", "Frog", allAnimals.Where(animal => animal is Frog).Average(x => x.Age));
            Console.WriteLine("{0} - average age : {1}", "Dog", allAnimals.Where(animal => animal is Dog).Average(x => x.Age));
            Console.WriteLine("{0} - average age : {1}", "Cat", allAnimals.Where(animal => animal is Cat).Average(x => x.Age));
        }
    }
}
