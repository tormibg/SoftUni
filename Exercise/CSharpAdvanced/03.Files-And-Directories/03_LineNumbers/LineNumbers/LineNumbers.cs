namespace LineNumbers
{
    using System.IO;

    using BashSoft;

    public class LineNumbers
    {
        public static void Main()
        {
            string myOutputPath = @"..\..\..\MyOutput.txt";
            string inputPath = @"..\..\..\01_LinesIn.txt";
            string expectedOutputPath = @"..\..\..\01_LinesOut.txt";

            string[] input = File.ReadAllLines(inputPath);

            using (var writer = File.AppendText(myOutputPath))
            {
                for (int line = 0; line < input.Length; line++)
                {
                    writer.WriteLine($"{line+1}. {input[line]}");
                }
            }

            Tester.CompareContent(myOutputPath, expectedOutputPath);
            File.Delete(myOutputPath);
        }
    }
}
