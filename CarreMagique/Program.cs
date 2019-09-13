using System;
using System.IO;
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

        static void Main3(string[] args)
        {
            
           string sRacine = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sRacine = sRacine += @"\";
            if (Directory.Exists(sRacine))
            {                
                Console.WriteLine(sRacine);
                sRacine = Path.Combine(sRacine + @"carres-magiques\");

                if (!Directory.Exists(sRacine))
                {
                    Directory.CreateDirectory(sRacine);
                    if (!Directory.Exists(sRacine))
                        Console.WriteLine("echec création fichier 'carres-magiques' dans le dossier 'Mes Documents'");
                    else
                        Console.WriteLine("succès création fichier 'carres-magiques' dans le dossier 'Mes Documents'");
                }
            }
        }
    }
}
