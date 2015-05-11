using System;

class ExchangeVariableValues
{
    static void Main()
   {
       short a = 5;
       short b = 10;
       short c;
       Console.WriteLine("a = {0}, b = {1}",a,b);
       c = b;
       b = a;
       a = c;
       Console.WriteLine("a = {0}, b = {1}", a, b);
   }
}