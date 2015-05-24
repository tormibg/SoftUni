using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\..\text.txt");
        using (reader)
        {
            int lineNumber = 0;
            string strLine = reader.ReadLine();
            if (strLine != null)
            {
                Console.WriteLine(strLine);
                lineNumber++;
                strLine = reader.ReadLine();
                while (strLine != null)
                {
                    if (lineNumber % 2 == 0) //Nomeraciata zapochva ot 0, no realno vav faila si 1 red/
                    {
                        strLine = reader.ReadLine();
                        Console.WriteLine(strLine);
                        lineNumber++;
                    }
                    lineNumber++;
                }
            }
        }
    }
}