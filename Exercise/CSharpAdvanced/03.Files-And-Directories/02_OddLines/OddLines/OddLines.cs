namespace OddLines
{
    using System.IO;

    using BashSoft;

    public class OddLines
    {
        public static void Main()
        {
            string myOutputPath = @"..\..\..\MyOutput.txt";
            string inputPath = @"..\..\..\01_OddLinesIn.txt";
            string expectedOutputPath = @"..\..\..\01_OddLinesOut.txt";

            StreamReader reader = File.OpenText(inputPath);
            StreamWriter writer = File.AppendText(myOutputPath);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int counter = 0;
                    while (!string.IsNullOrEmpty(line))
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
            Tester.CompareContent(myOutputPath, expectedOutputPath);
            File.Delete(myOutputPath);
        }
    }
}
