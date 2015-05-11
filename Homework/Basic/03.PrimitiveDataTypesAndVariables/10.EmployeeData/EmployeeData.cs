using System;

class EmployeeData
{
    static void Main()
    {
        string lsFirstName = "Ivan";
        string lsLastName = "Ivanov";
        byte lbAge = 34;
        char lcGender = 'm';
        ulong lulPersonID = 8212123454;
        string lsPersonID = "8212123454"; //test
        uint luiEmplNumber = 27569999;
        Console.WriteLine("First name : {0}",lsFirstName);
        Console.WriteLine("Last Name : {0}",lsLastName);
        Console.WriteLine("Age : {0}",lbAge);
        Console.WriteLine("Sex : {0}",lcGender);
        Console.WriteLine("Personal ID : {0}",lulPersonID);
        Console.WriteLine("Personal (string) ID : {0}",lsPersonID);
        Console.WriteLine("Employee number : {0}",luiEmplNumber);
    }
}