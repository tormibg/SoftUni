using System;
namespace GenericList
{
    class GenericListInput
    {
        static void Main()
        {
            GenericList<string> test = new GenericList<string>();
           
            test.Add("Gosho");
            test.Add("Pesho");
            test.Add("Atanaas");
            test.Add("I Az");
            test.Add("I Pak Az");
            Console.WriteLine(test);

            Console.WriteLine(test[3] + "\n");

            test.RemoveAt(3);
            Console.WriteLine(test);

            test.InsertAt(3, "I Az vtori pat");
            Console.WriteLine(test);

            var index = test.FindElementIndex("I Az vtori pat");
            Console.WriteLine(index != null ? index.ToString() : "No such element.");
            Console.WriteLine();

            Console.WriteLine(test.Countains("I Az vtori pat"));

            Console.WriteLine(test.Max() + "\n");

            Console.WriteLine(test.Min() + "\n");

            test.Clear();
            Console.WriteLine(test);

            Type type = typeof(GenericList<>);
            object[] versionAttributes = type.GetCustomAttributes(typeof(VersionAttribute), true);
            foreach (VersionAttribute attribute in versionAttributes)
            {
                Console.WriteLine("Version: " + attribute.Major + "." + attribute.Minor);
            }
        }
    }
}
