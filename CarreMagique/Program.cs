using System;
using System.IO;

namespace CarreMagique
{
    class Program
    {
        static void Main(string[] args)
        {
            Uti.Info("Program", "Main", "");
            Uti.ReferencesProgramme("RODDE","Alain","carre-magique","1.0.2");
            Menu menu = new Menu();
            menu.MethodesMenuJeu();
            Console.WriteLine();
        }
    }  

     
}

