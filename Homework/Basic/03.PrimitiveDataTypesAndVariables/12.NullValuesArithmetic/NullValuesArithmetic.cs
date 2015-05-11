using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? liIntNull = null;
        double? ldDoubleNull = null;
        Console.WriteLine("First null int : {0} , and null double : {1}",liIntNull, ldDoubleNull);
        liIntNull = liIntNull + 5;
        ldDoubleNull = ldDoubleNull + 3.14567;
        Console.WriteLine("First null int : {0} , and null double : {1}", liIntNull, ldDoubleNull);
        liIntNull = 5;
        ldDoubleNull = 3.14567;
        Console.WriteLine("First null int : {0} , and null double : {1}", liIntNull, ldDoubleNull);
        liIntNull = liIntNull + null;
        ldDoubleNull = ldDoubleNull + null;
        Console.WriteLine("First null int : {0} , and null double : {1}", liIntNull, ldDoubleNull);
    }
}
