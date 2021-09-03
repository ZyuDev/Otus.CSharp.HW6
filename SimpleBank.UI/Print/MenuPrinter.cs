using System;

namespace SimpleBank.UI.Print
{
    public class MenuPrinter
    {
        public static void Print()
        {

            PrintCommon.PrintDelimiter();
            Console.WriteLine("Menu:");
            PrintCommon.PrintDelimiter();

            Console.WriteLine("1 - print Currencies");
            Console.WriteLine("2 - print Persons");
            Console.WriteLine("3 - print Accounts");
            Console.WriteLine("4 - print Transactions");
            Console.WriteLine("5 - input new Transaction");
            Console.WriteLine("e - exit");
        }
    }
}
