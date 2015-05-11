using System;

class PrintCompanyInformation
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            string sCompName, sComAddress, sPhNumber, sFaxNumber, sWebSite,sManFsName,sManLsMan,sManPhone;
            byte bManAge;
            Console.Write("Enter company name : ");
            sCompName = Console.ReadLine();
            Console.Write("Enter company address : ");
            sComAddress = Console.ReadLine();
            Console.Write("Enter company phone number : ");
            sPhNumber = Console.ReadLine();
            Console.Write("Enter company fax number : ");
            sFaxNumber = Console.ReadLine();
            Console.Write("Enter company web site : ");
            sWebSite = Console.ReadLine();
            Console.Write("Enter manager first name : ");
            sManFsName = Console.ReadLine();
            Console.Write("Enter manager last name : ");
            sManLsMan = Console.ReadLine();
            Console.Write("Enter manager age : ");
            while (true)
            {
                if (byte.TryParse(Console.ReadLine(), out bManAge))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a number");
                }
            }
            Console.Write("Enter manager phone :");
            sManPhone = Console.ReadLine();
            Console.WriteLine(sCompName);
            Console.WriteLine("Address : {0}", sComAddress);
            Console.WriteLine("Tel. {0}", string.IsNullOrEmpty(sPhNumber) ? "(no tel.)" : sPhNumber);
            Console.WriteLine("Fax: {0}", string.IsNullOrEmpty(sFaxNumber)? "(no fax)" : sFaxNumber);
            Console.WriteLine(@"Web site: {0}",sWebSite);
            Console.Write("Manager: {0} ", char.ToUpper(sManFsName[0])+sManFsName.Substring(1));
            Console.Write("{0} ",char.ToUpper(sManLsMan[0])+sManLsMan.Substring(1));
            Console.WriteLine("(age: {0}, tel. {1})",bManAge,sManPhone);
        }
    }
}