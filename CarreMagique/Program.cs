using System;
using System.IO;

namespace CarreMagique
{
    class Program
    {
        static void Main(string[] args)
        {
            Uti.Info("Program", "Main", "");
            Menu menu = new Menu();
            menu.MethodesMenuJeu();
            Console.WriteLine();
        }
    }  

     
}
