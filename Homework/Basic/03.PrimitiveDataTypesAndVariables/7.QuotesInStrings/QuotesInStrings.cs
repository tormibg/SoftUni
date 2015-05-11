using System;

class QuotesInStrings
{
    static void Main()
    {
        string lsFirstVar = "The \"use\" of quotations causes difficulties.";
        string lsSecVar = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("Fisrst string with \\ : {0}",lsFirstVar);
        Console.WriteLine(@"Second string with @ : {0}",lsSecVar);
    }
}
