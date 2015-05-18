using System;
using System.IO;
using System.Text.RegularExpressions;

class CleanUpTheMess
{
    static void Main()
    {
        string messFile = "../../Mecanismo.cs";
        string readFile = File.ReadAllText(messFile);
        string pattern = @"\s*\n\s*";
        string newStr = Regex.Replace(readFile, pattern," ");
        pattern = @";\s*";
        newStr = Regex.Replace(newStr, pattern, ";\n");
        pattern = @"\s*{\s*";
        newStr = Regex.Replace(newStr, pattern, "\n{\n");
        pattern = @"\s*}\s*";
        newStr = Regex.Replace(newStr, pattern, "\n}\n");
        Console.WriteLine(newStr);
        File.WriteAllText("../../NewMecanismo.cs",newStr);
    }
}