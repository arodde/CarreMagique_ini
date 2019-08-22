using System;
//using System.Collections.Generic;

namespace CarreMagique
{
    class Program
    {
        static void Main(string[] args)
        {
            Uti.Info("Program", "Main", "");

            Uti.Mess("PERSISTANCE JSON A IMPLEMENTER");
            
            Menu menu = new Menu();
            menu.MethodesMenuJeu();
            Console.WriteLine();
        }
    }
}
