using System;

namespace SimpleBank.UI.Print
{
    public class PrintCommon
    {
        public static void PrintDelimiter()
        {
            Console.WriteLine("===================");
        }

        public static void PrintAppHeader()
        {
            PrintDelimiter();
            Console.WriteLine("Simple Bank");
            PrintDelimiter();
        }
    }
}