using System;
using System.Globalization;

class VariableInHexadecimalFormat
{
    static void Main()
    {
        int liIntValue = 254;
        string lsHexValue = "0x"+liIntValue.ToString("X"); //convert int to hex
        Console.WriteLine("The int value is {0}, and the hex value is {1}",liIntValue,lsHexValue);
        int liIntAgain = int.Parse(lsHexValue.Substring(2), NumberStyles.HexNumber); //convert hex to int
        Console.WriteLine("The hex value is {0}, and the int value is {1}",lsHexValue, liIntAgain);
    }
}