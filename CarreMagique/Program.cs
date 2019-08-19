using System;
//using System.Collections.Generic;

namespace CarreMagique
{
    class Program
    {
        static void Main(string[] args)
        {
            Uti.Info("Program", "Main", "");

            Uti.Mess("toilettage code à faire sur br-1 et master");
            
            Menu menu = new Menu();
            menu.MethodesMenuJeu();
            Console.WriteLine();
        }
    }
}
