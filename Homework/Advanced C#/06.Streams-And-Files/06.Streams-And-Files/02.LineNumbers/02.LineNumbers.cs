using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\..\text.txt");
        StreamWriter writer = new StreamWriter(@"..\..\..\newtext.txt");
        using (reader)
        {
            using (writer)
            {
                string strLine = reader.ReadLine();
                int lineNumber = 0;
                while (strLine != null)
                {
                    lineNumber++;
                    writer.WriteLine("{0} {1}",lineNumber,strLine);
                    strLine = reader.ReadLine();
                }
            }
        }
    }
}