

using System;
using System.Collections.Generic;
using System.Text;


namespace CarreMagique
{
    public static class Uti
    {

        static public void Info(string nomClasse, string nomFonction, string complements)
        {

            /* ***************************************************************
            Info
            * Fonction pour aider le développeur à savoir par quelle classe et fonction le programme passe.
            * les paramètres:
            * 1 : nom de la classe (string)
            * 2 : nom de la fonction (string)
            * 3 : commentaire (string)
            * retour: (void)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
            **************************************************************** */
            /* ***************************************************************
             +
             * Fonction pour +
             * les paramètres:
             * 1 : + (+)
             * 2 : + (+)
             * 3 : + (+)
             * 4 : + (+)
             * 5 : + (+)
             * retour: + (+)
             * exemple(s):
             * +
             * Ce qui est impossible:
             * +
            **************************************************************** */
            // les mentions à afficher
            string classe = "----> " + nomClasse;
            string fonction = " ----> " + nomFonction;
            string lesComplements = "";
            if (complements != "")
                lesComplements = " ----> " + complements;
            // l'affichage
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(classe);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(fonction);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(lesComplements);
            Console.ResetColor();
        }
        static public void Mess(string message)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            Info("Program", "Mess", "");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static public void MessErr(string message)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            Info("Program", "Mess", "");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static public void Sep(string message, int nombre)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < nombre; i++)
            {
                Console.Write(message);
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        public static void Echanger<T>(ref T t1, ref T t2)
        {// méthode d'échange générique
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }
        public static bool EstEgal<T, U>(T t, U u)
        {// teste qu'il s'agit de la même instance
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            return t.Equals(u);
        }
        static void Titrer(string message)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t");
            PremierTierLeTexte(message);
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        private static void CentrerLeTexte(string texte)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }
        private static void PremierTierLeTexte(string texte)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            int nbEspaces = (Console.WindowWidth - texte.Length) / 3;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }
        static public void Avertissement(string message)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*****\n");
            PremierTierLeTexte("AVERTISSEMENT!!!");
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("*****\n");
            Console.ResetColor();
        }
        static public void GestionEspaces(int valeur)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            //Uti.Info("Uti", "GestionEspaces", "");
            // affiche la valeur avec une série d'espace en fonction de l'importance de la valeur
            if (valeur < 10)
            {
                Console.Write("   " + valeur + " ");
            }
            else if (valeur < 100)
            {
                Console.Write("  " + valeur + " ");
            }
            else // < 1000
            {
                Console.Write(" " + valeur + " ");
            }
        }
        static public bool Quitter(string commentaire)
        {
            /* ***************************************************************
    +
    * Fonction pour +
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: + (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            // true pour quitter ; false pour continuer
            Console.Write("Voulez-vous quitter");
            if (commentaire != "")
            {
                Console.Write(commentaire + " ");
            }
            Console.WriteLine("(O/N)?");

            ConsoleKeyInfo saisie = Console.ReadKey(true);

            if (saisie.Key == ConsoleKey.O)
            {
                Console.WriteLine("On s'arrête ...");
                return true;
            }
            else
            {
                Console.WriteLine("On continue ...");
                return false;
            }
        }
        static public bool Action(string verbeAction, string actionSiOui, string actionSiNon, string commentaire)
        {
            /* ***************************************************************
    +
    * Fonction pour soumettre une action à l'utilisateur et renvoyer un booléen 
    * correspondant à sa décision
    * les paramètres:
    * 1 : verbeAction (string)
    * 2 : actionSiOui (string)
    * 3 : actionSiNon (string)
    * 4 : commentaire (string) (pour apporter une précision s'il y a lieur
    * 5 : + (+)
    * retour: si oui true si non false (bool)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            // pour lancer une éventuelle action
            Uti.Info("Uti", "Action", "sauvegarde");
            Console.Write("Voulez-vous " + verbeAction);
            if (commentaire != "")
            {
                Console.Write(commentaire + " ");
            }
            Console.WriteLine("?");
            Console.WriteLine("(O/N)?");

            ConsoleKeyInfo saisie = Console.ReadKey(true);
            if (saisie.Key == ConsoleKey.O)
            {
                Console.WriteLine(actionSiOui);
                return true;
            }
            else
            {
                Console.WriteLine(actionSiNon);
                return false;
            }
        }
        static public bool EstPair(int nombre)
        {
            /* ***************************************************************
    +
    * Fonction pour préciser si le nombre en paramètre est pair
    * les paramètres:
    * 1 : + (+)
    * 2 : + (+)
    * 3 : + (+)
    * 4 : + (+)
    * 5 : + (+)
    * retour: true: pair, false: impair (+)
    * exemple(s):
    * +
    * Ce qui est impossible:
    * +
   **************************************************************** */
            if ((nombre % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string ExtractionChainesEntreDeuxCaracteres(string chaine, char motif1, int occ1, char motif2, int occ2)
        {
            /*
             ExtractionChainesEntreDeuxCaracteres
             * Fonction pour extraire une sous-chaine d'une 
             * chaine en identifiant deux caractères char par
             * leur occurence dans la chaine
             * les paramètres:
             * 1 : la chaine (string)
             * 2 : un caractère (char)
             * 3 : l'occurrence de ce caractère dans la chaîne
             * 4 : un caractère (char)
             * 5 : l'occurrence de ce caractère dans la chaîne
             * retour: la sous-chaîne (string)
             * exemple:
             * chaine "salut \"coco\" t'aimes la banane?"
             * extraire "t'aimes"
             * string resultat = ExtractionChainesEntreDeuxCaracteres("salut coco t'aimes la banane?",' ',2,' ',3);
             * extraire "coco"
             * string sch = ExtractionChainesEntreDeuxCaracteres("salut \"coco\" t'aimes la banane?",'"', 1,'"',2);
             * Ce qui est impossible:
             * extraire "\"coco\"
             * sch = ExtractionChainesEntreDeuxCaracteres("salut \"coco\" t'aimes la banane?", '\\', 1, '\\',4);
             * le caractère '\' ne peut pas être géré
             * extraire quelque chose de plus grand que la chaîne ou donner le même caractère et la même occurence 
             * dans les paramètres 2 , 3 et 4 , 5
            */
            int i = 0;// compteur d'occurrence
            string sousChaine = "";
            int a = 0;
            int b = 0;

           
            // identifie les bonnes occurrences de motif1 
            int k = 0;
            while (k < chaine.Length)
            {
                if (chaine[k] == motif1)
                {
                    i++;
                    if (i == occ1)
                    {
                        a = k;
                        break;
                    }
                }
                k++;
            }
            i = 0;
            k = 0;
            // et de motif2
            while (k < chaine.Length)
            {
                if (chaine[k] == motif2)
                {
                    i++;
                    if (i == occ2)
                    {
                        b = k;
                        break;
                    }
                }
                k++;
            }
            // trouve la sous-chaine et la renvoie
            int longueur = b - a - 1;
            if (longueur > 0)
            {
                sousChaine = chaine.Substring((a + 1), longueur);
            }
            else
            {
                Console.WriteLine("Impossible la longueur de la sous-chaine est nulle.");
            }
            return sousChaine;
        }
    }
}
public static class utiExemple
{
    public static void ConversionTypesProches()
    {
        Console.WriteLine("---> ConversionTypesProches");
        /* la conversion est possible mais de la responsabilité du 
         * programmeur ici une perte d'information la partie décimale */
        double prix = 125.55;
        int valeur = (int)prix; // valeur vaut 125
        Console.WriteLine(prix + " double converti en int " + valeur);
        /* Ceci est propre au fonctionnement de l'énumération */
        Console.WriteLine(Jours.Jeudi + " cas d'une énumération " + (int)Jours.Jeudi);
    }
    public static void ConversionTypesDifferents()
    {
        Console.WriteLine("---> ConversionTypesDifferents");
        // méthode 1
        string chaineAge = "20"; // le nombre doit être écrit en chiffres.
        int age = Convert.ToInt32(chaineAge);
        // age vaut 20
        // méthode 2
        string chaineAge2 = "20";
        int age2 = int.Parse(chaineAge2);
        // age vaut 20
        // méthode 3
        string chaineAge3 = "ab20cd";
        int age3;
        string chaine = "9";
        int nombre;
        if (int.TryParse(chaine, out nombre))
        {
            Console.WriteLine(nombre);
        }
        else
        {
            Console.WriteLine("impossible");
        }
        chaineAge3 = "188";
        if (int.TryParse(chaineAge3, out age3))
        {
            Console.WriteLine("La conversion de \"188\" est possible, age vaut " + age3);
        }
        else
        {
            Console.WriteLine("Conversion impossible de \"188\"");
        }
    }

    public static void UtilisationDUnConsoleKeyInfo()
    {
        int iTheme = 0;
        bool ok = false;
        // récupération d'une ConsoleKeyInfo (un caractère) pour la convertir en entier (un chiffre)
        ConsoleKeyInfo saisie = Console.ReadKey(true);
        if (char.IsDigit(saisie.KeyChar))
        {
            iTheme = int.Parse(saisie.KeyChar.ToString());
            ok = true;
        }
        else
        {
            iTheme = -1;
            Console.WriteLine("Il faut entrer un nombre.");
        }
    }
  
    //public void T1dim()
    //{
    //    Uti.Info("DesTableaux", "T1dim", "");

    //    int[] myArray1 = new int[4]; // 4 valeurs à 0

    //    int[] myArray2 = new int[] { 10, 20, 30, 40 }; // valeurs 10, 20, 30, 40

    //    int[] myArray3 = { 10, 20, 30, 40 }; // simplifié  valeurs 10, 20, 30, 40

    //    Console.WriteLine(myArray1[0] + " " + myArray1[1] + " " + myArray1[2] + " " + myArray1[3]);
    //    Console.WriteLine(myArray2[0] + " " + myArray2[1] + " " + myArray2[2] + " " + myArray2[3]);
    //    Console.WriteLine(myArray3[0] + " " + myArray3[1] + " " + myArray3[2] + " " + myArray3[3]);
    //}
    //public void T2dim()
    //{
    //    Uti.Info("DesTableaux", "T2dim", "");
    //    double[,] myArray1 = new double[,]
    //    {
    //        {0.1, 0.5},
    //        {1.3, 1.7}
    //    };

    //    double[,] myArray2 =  // simplifié
    //    {
    //        {0.1, 0.5},
    //        {1.3, 1.7}
    //    };

    //    Console.WriteLine(myArray1[1, 1]);
    //    Console.WriteLine(myArray1[1, 0]);
    //    Console.WriteLine(myArray1[0, 1]);
    //    Console.WriteLine(myArray1[0, 0]);

    //    Console.WriteLine(myArray2[1, 1]);
    //    Console.WriteLine(myArray2[1, 0]);
    //    Console.WriteLine(myArray2[0, 1]);
    //    Console.WriteLine(myArray2[0, 0]);
    //}
    //public void Tdt()
    //{
    //    Uti.Info("DesTableaux", "Tdt", "");
    //    int[][] myIntArray = new int[2][];
    //    myIntArray[0] = new int[5];
    //    myIntArray[0][1] = 42;
    //    string[] firstnameArray =
    //    {
    //        "Matt",
    //        "Tim",
    //        "James"
    //    };

    //    string[] surnameArray =
    //    {
    //        "Johnson",
    //        "Smith"
    //    };
    //    string[] famille =
    //    {
    //        "coeur",
    //        "pique",
    //        "carreau",
    //        "trefle"
    //    };

    //    string[][] myArray =
    //    {
    //        firstnameArray,
    //        surnameArray,
    //        famille
    //    };
    //    int[][] myArrayOfIntArrays = new int[5][];

    //    Console.WriteLine(myArray[0][0]);
    //    Console.WriteLine(myArray[0][1]);
    //    Console.WriteLine(myArray[0][2]);
    //    Console.WriteLine(myArray[1][0]);
    //    Console.WriteLine(myArray[1][1]);

    //    // récupérer les tailles de tableau
    //    Console.WriteLine(myArray.GetLength(0));
    //    Console.WriteLine(firstnameArray.GetLength(0).ToString());
    //    Console.WriteLine(surnameArray.GetLength(0));

    //    int t1 = myArray.GetLength(0);
    //    int t11 = firstnameArray.GetLength(0);
    //    int t12 = surnameArray.GetLength(0);

    //    foreach (string[] el in myArray)
    //    {
    //        foreach (string element in el)
    //        {
    //            Console.Write(element + " ");
    //        }
    //        Console.WriteLine();
    //    }

    //}
    enum Jours
    {// ce sont des entiers à compter de zéro
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
        Dimanche
    }
    static public void exception()
    {
        try
        {
            // code provoquant une exception
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Erreur de format : " + ex);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Erreur de référence nulle : " + ex);
        }
        catch (SystemException ex)
        {
            Console.WriteLine("Erreur système autres que FormatException et NullReferenceException : " + ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Toutes les autres exceptions : " + ex);
        }
        finally
        {
            Console.WriteLine("Cela est toujours exécuté");
        }
    }
    static void MonMenuObjet()
    {
        Console.WriteLine("---> MonMenu");
        // mise en forme
        string sl = "\n";
        string tbl = "\t";
        // élaboration du menu
        string sMenu = "MENU" + sl + tbl;
        sMenu += "1. +" + sl + tbl;
        sMenu += "2. +" + sl + tbl;
        sMenu += "3. " + sl + tbl;
        sMenu += "4. " + sl + tbl;
        sMenu += "5. " + sl + tbl;
        sMenu += "6. " + sl + tbl;
        sMenu += "7. " + sl + tbl;
        sMenu += "8. " + sl + tbl;
        sMenu += "9. " + sl + tbl;
        sMenu += "10. " + sl + tbl;
        sMenu += "11. " + sl + tbl;
        sMenu += "12. " + sl + tbl;
        sMenu += "13. +" + sl + tbl;
        sMenu += "14. +" + sl + tbl;
        Console.WriteLine(sMenu);
    }
    static void MenuCoursObjet()
    {
        Console.WriteLine("---> MonMenu");
        string sl = "\n";
        string tbl = "\t";
        string sInput = "";
        // menu
        int iTheme = 0;

        MonMenuObjet();
        sInput = Console.ReadLine();
        iTheme = Convert.ToInt32(sInput); // conversion string en int
        switch (iTheme) // à chaque thème déclaration des variables dans la portée suffisante pour éviter les variables globales
        {
            //case 1:
            //    +();
            //    break;
            //case 2:
            //    +();
            //    break;
            //case 3:
            //    +();
            //    break;
            //case 4:
            //    +();
            //    break;
            //case 5:
            //    +();
            //    break;
            //case 6:
            //    +();
            //    break;
            //case 7:
            //    +();
            //    break;
            //case 8:
            //    +();
            //    break;
            //case 9:
            //    +();
            //    break;
            //case 10:
            //    +();
            //    break;
            //case 11:
            //    +();
            //    break;
            //case 12:
            //    +();
            //    break;
            //case 13:
            //    +();
            //    break;
            //case 14:
            //    +();
            //    break;
        }
    }
}
public static class pelemele
{

    enum Jours
    {// ce sont des entiers à compter de zéro
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
        Dimanche
    }

    static void ConsoleCouleurs()
    {
        Console.WriteLine("---> ConsoleCouleurs");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write("Hello ");
        //
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("les couleurs");
        //
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.Write(" dans la console\n");
        // réinitialise la console
        Console.ResetColor();
        // effacer l'écran
        Console.Clear();
        // position le curseur
        Console.WriteLine("Hello world");
        Console.SetCursorPosition(25, 7);
        Console.WriteLine("Hello world aussi");
        Console.WriteLine("Encore Hello world");
        //
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("Hello world");
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        Console.SetCursorPosition(25, 7);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Hello world aussi");
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\tEn dessous du premier " + x + " " + y);
        Console.ResetColor();

    }

    private static void DessineUneVoitureEtLaDeplace()
    {
        Console.WriteLine("---> DessineUneVoitureEtLaDeplace");
        int i = 0;
        int j = 0;
        int largeur = 21;
        int hauteur = 4;
        Console.Clear();
        Console.WriteLine(@"      .--------.");
        Console.WriteLine(@" ____/_____|___ \___");
        Console.WriteLine(@"O    _   - |   _   ,*");
        Console.WriteLine(@" '--(_)-------(_)--'");
        while (true)
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            switch (info.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (i > 0)
                    {
                        Console.MoveBufferArea(i, j, largeur, hauteur, i - 1, j);
                        i--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (i < Console.WindowWidth - largeur)
                    {
                        Console.MoveBufferArea(i, j, largeur, hauteur, i + 1, j);
                        i++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (j > 0)
                    {
                        Console.MoveBufferArea(i, j, largeur, hauteur, i, j - 1);
                        j--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    Console.MoveBufferArea(i, j, largeur, hauteur, i, j + 1);
                    j++;
                    break;
            }
            if (info.Key == ConsoleKey.Q)
                break;
        }
    }
    private static void Sons()
    {
        Console.WriteLine("---> Sons");
        int noteDo = 262;
        int noteRe = 294;
        int noteMi = 330;
        int noire = 400;
        int blanche = 800;

        Console.Beep(noteDo, noire);
        Console.Beep(noteDo, noire);
        Console.Beep(noteDo, noire);
        Console.Beep(noteRe, noire);
        Console.Beep(noteMi, blanche);
        Console.Beep(noteRe, blanche);
        Console.Beep(noteDo, noire);
        Console.Beep(noteMi, noire);
        Console.Beep(noteRe, noire);
        Console.Beep(noteRe, noire);
        Console.Beep(noteDo, noire);
    }

}




public class Chainage<T>
{
    public Chainage<T> Precedent { get; set; }
    public Chainage<T> Suivant { get; set; }
    public T Valeur { get; set; }
}



public class ListeChainee<T>
{
    public Chainage<T> Premier { get; private set; } // en lecture seule
    public Chainage<T> Dernier
    {
        get
        {
            if (Premier == null) // si la liste est vide
                return null;
            Chainage<T> dernier = Premier;
            while (dernier.Suivant != null)
            {
                // tant que le chainage affecté a un successeur, on lui affecte le suivant
                dernier = dernier.Suivant;
            }
            // à la sortie de la boucle ont forcément le dernier élément de la liste
            return dernier;
        }
    }
    public void Ajouter(T element)
    {

        if (Premier == null)
        {
            // ajoute un premier élément si pas de premier  
            Premier = new Chainage<T> { Valeur = element };
        }
        else
        {
            // posistionnement au dernier élément et création d'un chainge sur 
            //sa propriété suivant dont la valeur est l'élément et le précédent le dernier
            Chainage<T> dernier = Dernier;
            dernier.Suivant = new Chainage<T> { Valeur = element, Precedent = dernier };
            // la determination du nouveau dernier se fait via le get de Dernier
        }
    }
    public Chainage<T> ObtenirElement(int indice)
    {
        Chainage<T> temp = Premier;
        for (int i = 1; i <= indice; i++)
        {
            if (temp == null) // si la liste est vide
                return null;
            temp = temp.Suivant; // si la liste contient au moins un élément
        }
        return temp;
    }

    public void Inserer(T element, int indice)
    {
        if (indice == 0) // Insérer avant le premier
        {
            if (Premier == null) // Soit que la liste est vide
                Premier = new Chainage<T> { Valeur = element };
            else // Soit que la liste contient au moins un élément
            {
                Chainage<T> temp = Premier;
                Premier = new Chainage<T> { Suivant = temp, Valeur = element };
                temp.Precedent = Premier;
            }
        }
        else // insérer à une autre position que le premier
        {
            Chainage<T> elementAIndice = ObtenirElement(indice);
            if (elementAIndice == null) // si pas d'élément à cet indice alors ajouter un élément en dernière position
                Ajouter(element);
            else // si un élément est trouvé à ce position
            { // alors procéder à l'insertion
                Chainage<T> precedent = elementAIndice.Precedent; // celui d'avant
                Chainage<T> temp = precedent.Suivant; // celui qui sera après
                                                      // ajout du nouveau
                precedent.Suivant = new Chainage<T> { Valeur = element, Precedent = precedent, Suivant = temp };
                temp.Precedent = precedent.Suivant;
            }
        }
    }
}



