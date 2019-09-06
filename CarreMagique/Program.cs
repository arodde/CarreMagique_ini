using System;
//using System.Collections.Generic;

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
        static void Main2(string[] args)
        {
            Uti.Info("Program", "Main", "");

            ExempleFichierJSON efjs = new ExempleFichierJSON();
          string s =  efjs.CreationFichierJSONAPartirDUnObjet();
            efjs.CreationDUnObjetAPartirFichierJSON(s);
            Console.WriteLine();
        }
    }
}
