using System;

class StringsAndObjects
{
    static void Main()
    {
        string lsHelloVar = "Hello";
        string lsWorldVar = "World";
        object loHWVar = lsHelloVar + " " + lsWorldVar;
        string lsObjToStr = (string) loHWVar;
        Console.WriteLine("First string var : {0}",lsHelloVar);
        Console.WriteLine("Second string var : {0}",lsWorldVar);
        Console.WriteLine("Obj var : {0}",loHWVar);
        Console.WriteLine("Third string var : {0}",lsObjToStr);
    }
}