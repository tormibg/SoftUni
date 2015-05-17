using System;

    class TextFilter
    {
        static void Main()
        {
            string[] searchStr = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string inputStr = Console.ReadLine();
            
            foreach (var word in searchStr)
            {
                inputStr = inputStr.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(inputStr);
        }
    }