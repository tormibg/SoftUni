using System;

class BankAccountData
{
    static void Main()
    {
        string lsFirstName = "Ivan";
        string lsMidName = "Ivanov";
        string lsLastName = "Ivanov";
        string lsHolderName = lsFirstName + " " + lsMidName + " " + lsLastName;
        decimal lmBalance = 12345.67m;
        string lsBankName = "UniBank";
        string lsIBAN = "BG80BNBG96611020345678";
        ulong lsCCard1 = 378282246310005;
        string lsCCard2 = "371449635398431";
        string lsCCard3 = "378734493671000";
        Console.WriteLine("Holder name : {0}",lsHolderName);
        Console.WriteLine("Account balance : {0}",lmBalance);
        Console.WriteLine("Bank : {0}",lsBankName);
        Console.WriteLine("IBAN number : {0}",lsIBAN);
        Console.WriteLine("You have a 3 credit cards :");
        Console.WriteLine("1. {0}",lsCCard1);
        Console.WriteLine("2. {0}",lsCCard2);
        Console.WriteLine("3. {0}",lsCCard3);
    }
}
