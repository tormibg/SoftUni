using System;
using System.Text;

class CodePage437
{
    public static void Main(string[] args)
    {
        // Set the window size and title
        Console.Title = "Code Page windows-1251: MS-DOS ASCII Characters";

        Console.Write("Decimal".PadRight(10));
        Console.Write("ASCII".PadRight(10));
        Console.WriteLine();

        for (byte b = 0; b < byte.MaxValue; b++)
        {
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            char c = Encoding.GetEncoding(1251).GetChars(new byte[] { b })[0];
            string display = string.Empty;
            if (char.IsWhiteSpace(c))
            {
                display = c.ToString();
                switch (c)
                {
                    case '\t':
                        display = "\\t";
                        break;
                    case ' ':
                        display = "space";
                        break;
                    case '\n':
                        display = "\\n";
                        break;
                    case '\r':
                        display = "\\r";
                        break;
                    case '\v':
                        display = "\\v";
                        break;
                    case '\f':
                        display = "\\f";
                        break;
                }
            }
            else if (char.IsControl(c))
            {
                display = "control";
            }
            else
            {
                display = c.ToString();
            }
            Console.Write(b.ToString().PadRight(10));
            Console.Write(display.PadRight(10));
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}