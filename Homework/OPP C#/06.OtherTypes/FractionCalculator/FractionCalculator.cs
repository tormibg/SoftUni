using System;
using System.Net.Sockets;

namespace FractionCalculator
{
    class FractionCalculator
    {
        static void Main()
        {
            try
            {
                //Console.WriteLine(long.MaxValue);
                Fraction fraction1 = new Fraction(22, 7);
                Fraction fraction2 = new Fraction(40, 4);
                Fraction result = fraction1 + fraction2;
                Console.WriteLine(result.Numerator);
                Console.WriteLine(result.Denominator);
                Console.WriteLine(result);

                Fraction fraction3 = new Fraction(9223372036854775807, 745415184684);
                Fraction fraction4 = new Fraction(9223372036854775807, -9223372036854775808);
                Fraction result2 = fraction3 + fraction4;
                Console.WriteLine(result2.Numerator);
                Console.WriteLine(result2.Denominator);
                Console.WriteLine(result2);

            }
            catch (DivideByZeroException ex)
            {

                Console.Error.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }
    }
}
