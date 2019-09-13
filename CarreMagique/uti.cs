

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace CarreMagique
{
    public static class Uti
    {

        static public void Info(string sNomClasse, string sNomFonction, string sComplements)
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
            string sClasse = "----> " + sNomClasse;
            string sFonction = " ----> " + sNomFonction;
            string sLesComplements = "";
            if (sComplements != "")
                sLesComplements = " ----> " + sComplements;
            // l'affichage
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(sClasse);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(sFonction);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sLesComplements);
            Console.ResetColor();
        }
        static public void Mess(string sMessage)
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
            Console.WriteLine(sMessage);
            Console.ResetColor();
        }
        static public void MessErr(string sMessage)
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
            Console.WriteLine(sMessage);
            Console.ResetColor();
        }
        static public void Sep(string sMessage, int iNombre)
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
            for (int i = 0; i < iNombre; i++)
            {
                Console.Write(sMessage);
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        public static void Echanger<T>(ref T t1, ref T t2)
        {// méthode d'échange générique
            /* ***************************************************************
    +
    * Fonction générique pour échange de variables
    * les paramètres:
    * 1 : valeur à échanger... (T)
    * 2 : ... avec celle-ci (T)
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
    * Fonction générique pour vérifier si deux instances sont de même type
    * les paramètres:
    * 1 : instance 1 (T)
    * 2 : instance 2 (U)
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
       public static string DonneNomDossier(string sChemin)
        {
            int position = sChemin.LastIndexOf(@"\");
            return sChemin.Substring(position + 1);
        }
        static void Titrer(string sMessage)
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
            PremierTierLeTexte(sMessage);
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        private static void CentrerLeTexte(string sTexte)
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
            int iNbEspaces = (Console.WindowWidth - sTexte.Length) / 2;
            Console.SetCursorPosition(iNbEspaces, Console.CursorTop);
            Console.WriteLine(sTexte);
        }
        private static void PremierTierLeTexte(string sTexte)
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
            int iNbEspaces = (Console.WindowWidth - sTexte.Length) / 3;
            Console.SetCursorPosition(iNbEspaces, Console.CursorTop);
            Console.WriteLine(sTexte);
        }
        static public void Avertissement(string sMessage)
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
            Console.WriteLine(sMessage);
            Console.WriteLine("*****\n");
            Console.ResetColor();
        }
        static public void GestionEspaces(int iValeur)
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
            if (iValeur < 10)
            {
                Console.Write("   " + iValeur + " ");
            }
            else if (iValeur < 100)
            {
                Console.Write("  " + iValeur + " ");
            }
            else // < 1000
            {
                Console.Write(" " + iValeur + " ");
            }
        }
        static public bool Quitter(string sCommentaire)
        {
            /* ***************************************************************
            +
            * Fonction pour permettre à l'utilisateur de quitter une boucle
            * les paramètres:
            * 1 : message complémentaire (string)
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
            if (sCommentaire != "")
            {
                Console.Write(sCommentaire);
            }
            Console.WriteLine(" " + "(O/N)?");

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
        static public bool Action(string sVerbeAction, string sActionSiOui, string sActionSiNon, string sCommentaire)
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
            Console.Write("Voulez-vous " + sVerbeAction);
            if (sCommentaire != "")
            {
                Console.Write(sCommentaire + " ");
            }
            Console.WriteLine("?");
            Console.WriteLine("(O/N)?");

            ConsoleKeyInfo saisie = Console.ReadKey(true);
            if (saisie.Key == ConsoleKey.O)
            {
                Console.WriteLine(sActionSiOui);
                return true;
            }
            else
            {
                Console.WriteLine(sActionSiNon);
                return false;
            }
        }
        static public bool EstPair(int iNombre)
        {
            /* ***************************************************************
    +
    * Fonction pour préciser si le iNombre en paramètre est pair
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
            if ((iNombre % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string ExtractionChainesEntreDeuxCaracteres(string sChaine, char sMotif1, int iOcc1, char cMotif2, int iOcc2)
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
            string sSousChaine = "";
            int a = 0;
            int b = 0;


            // identifie les bonnes occurrences de motif1 
            int k = 0;
            while (k < sChaine.Length)
            {
                if (sChaine[k] == sMotif1)
                {
                    i++;
                    if (i == iOcc1)
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
            while (k < sChaine.Length)
            {
                if (sChaine[k] == cMotif2)
                {
                    i++;
                    if (i == iOcc2)
                    {
                        b = k;
                        break;
                    }
                }
                k++;
            }
            // trouve la sous-chaine et la renvoie
            int iLongueur = b - a - 1;
            if (iLongueur > 0)
            {
                sSousChaine = sChaine.Substring((a + 1), iLongueur);
            }
            else
            {
                Console.WriteLine("Impossible la longueur de la sous-chaine est nulle.");
            }
            return sSousChaine;
        }
    }

    class ExempleFichierJSON
    {
        string sRacine = @"C:\Users\demon\source\testouille\testouille\test\";
        string sFiJSON = @"student.json";
        string sPath;
        public string CreationFichierJSONAPartirDUnObjet()
        {
            Uti.Info("fichierJSON", "CreationFichierJSONAPartirDUnObjet", "");
            sPath = sRacine + sFiJSON;
            //  https://www.c-sharpcorner.com/article/working-with-json-in-C-Sharp/
            /*
             **************************************************************************

                                      CREATION D'UN FICHIER JSON

             **************************************************************************
             */
            // déclaration et instantiation de l'étudiant student
            Student student = new Student()
            {
                Id = 1,
                sName = "Balaji",
                sDegree = "MCA",
                Hobbies = new List<string>
                {
                    "Reading","Playing Games"
                }
            };
            //
            // conversion en une chaîne de caractères au format JSON 
            string sResultJson = JsonConvert.SerializeObject(student);
            //
            // affichage de la chaîne
            Console.WriteLine(sResultJson);
            //
            // création du fichier au chemin (avec le nom du fichier) 
            // et la string au format JSON.
            File.WriteAllText(sPath, sResultJson);
            //
            // Confirmation
            if (File.Exists(sPath))
            {
                Console.WriteLine("Stored!");
            }
            else
            {
                Console.WriteLine("échec création fichier JSON");
            }
            return sResultJson;
        }
        public void CreationDUnObjetAPartirFichierJSON(string sResultJson)
        {
            Uti.Info("fichierJSON", "CreationDUnObjetAPartirFichierJSON", "");

            /*
            **************************************************************************

                                     CREATION D'UN OBJET DE TYPE 
                                       DETERMINE A PARTIR D'UN 
                                            FICHIER JSON
            *   strResultJson est une chaine décrivant un objet en notation JSON
            **************************************************************************
            */
            // vide la chaine 
            sResultJson = string.Empty;
            Console.WriteLine("---> JSON --> objet " + sResultJson);
            //
            // stockE le contenu du fichier dans la variable ???
            sResultJson = File.ReadAllText(sPath);
            //
            // charge le fichier JSON dans un fichier adapté           
            Student resultStudent = JsonConvert.DeserializeObject<Student>(sResultJson);
            Console.WriteLine("Deserialization --->" + resultStudent);
        }
        public void AffichageAvecDictionaryDunObjetJSON(string sResultJson)
        {
            Uti.Info("fichierJSON", "AffichageAvecDictionaryDunObjetJSON", "");
            /*
           **************************************************************************

                                    CREATION D'UNE PRESENTATION
                                          PAR DICTIONARY
                                      DETERMINE A PARTIR D'UN 
                                           FICHIER JSON
           *   strResultJson est une chaine décrivant un objet en notation JSON
           *   utilisable avec tout fichier JSON
           **************************************************************************
           */
            Console.WriteLine("---> JSON --> dictionnaire ");
            var dictionary = JsonConvert.DeserializeObject<System.Collections.IDictionary>(sResultJson);
            foreach (System.Collections.DictionaryEntry entry in dictionary)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }

        }
    }
}
public static class UtiExemple
{
    public static void ConversionTypesProches()
    {
        Console.WriteLine("---> ConversionTypesProches");
        /* la conversion est possible mais de la responsabilité du 
         * programmeur ici une perte d'information la partie décimale */
        double dPrix = 125.55;
        int iValeur = (int)dPrix; // valeur vaut 125
        Console.WriteLine(dPrix + " double converti en int " + iValeur);
        /* Ceci est propre au fonctionnement de l'énumération */
        Console.WriteLine(Jours.Jeudi + " cas d'une énumération " + (int)Jours.Jeudi);
    }
    public static void ConversionTypesDifferents()
    {
        Console.WriteLine("---> ConversionTypesDifferents");
        // méthode 1
        string sChaineAge = "20"; // le iNombre doit être écrit en chiffres.
        int iAge = Convert.ToInt32(sChaineAge);
        // age vaut 20
        // méthode 2
        string sChaineAge2 = "20";
        int iAge2 = int.Parse(sChaineAge2);
        // age vaut 20
        // méthode 3
        string sChaineAge3 = "ab20cd";
        int iAge3;
        string sChaine = "9";
        int iNombre;
        if (int.TryParse(sChaine, out iNombre))
        {
            Console.WriteLine(iNombre);
        }
        else
        {
            Console.WriteLine("impossible");
        }
        sChaineAge3 = "188";
        if (int.TryParse(sChaineAge3, out iAge3))
        {
            Console.WriteLine("La conversion de \"188\" est possible, age vaut " + iAge3);
        }
        else
        {
            Console.WriteLine("Conversion impossible de \"188\"");
        }
    }

    public static void UtilisationDUnConsoleKeyInfo()
    {
        int iTheme = 0;
        bool bOk = false;
        // récupération d'une ConsoleKeyInfo (un caractère) pour la convertir en entier (un chiffre)
        ConsoleKeyInfo saisie = Console.ReadKey(true);
        if (char.IsDigit(saisie.KeyChar))
        {
            iTheme = int.Parse(saisie.KeyChar.ToString());
            bOk = true;
        }
        else
        {
            iTheme = -1;
            Console.WriteLine("Il faut entrer un nombre.");
        }

    }
    public static void Brouillon()
    {

        string sPathD = @"";
        string sPathF = @"";
        List<string> listring = new List<string>();
        listring.Add("abricot");
        listring.Add("ananas");
        listring.Add("avocat");
        listring.Add("banane");
        listring.Add("figue");
        listring.Add("pomme");
        listring.Add("poire");
        File.AppendAllLines(sPathF, listring);
        // ajout au fichier sans faire disparaître le contenu précédent
        File.AppendAllLines(sPathF, listring);
        //if (!File.Exists(pathF))
        //{
        // Create a file to write to.
        using (StreamWriter sw = File.CreateText(sPathF))
        {
            // écrase le précédent contenu du fichier et inscrit le contenu qui suit
            sw.WriteLine("Hello");
            sw.WriteLine("And");
            sw.WriteLine("Welcome");
        }
        //}
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
    static public void Exception()
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
        string sSl = "\n";
        string sTbl = "\t";
        // élaboration du menu
        string sMenu = "MENU" + sSl + sTbl;
        sMenu += "1. +" + sSl + sTbl;
        sMenu += "2. +" + sSl + sTbl;
        sMenu += "3. " + sSl + sTbl;
        sMenu += "4. " + sSl + sTbl;
        sMenu += "5. " + sSl + sTbl;
        sMenu += "6. " + sSl + sTbl;
        sMenu += "7. " + sSl + sTbl;
        sMenu += "8. " + sSl + sTbl;
        sMenu += "9. " + sSl + sTbl;
        sMenu += "10. " + sSl + sTbl;
        sMenu += "11. " + sSl + sTbl;
        sMenu += "12. " + sSl + sTbl;
        sMenu += "13. +" + sSl + sTbl;
        sMenu += "14. +" + sSl + sTbl;
        Console.WriteLine(sMenu);
    }
    static void MenuCoursObjet()
    {
        Console.WriteLine("---> MonMenu");
        string sSl = "\n";
        string sTbl = "\t";
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
public static class PeleMele
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
        int iX = Console.CursorLeft;
        int iY = Console.CursorTop;
        Console.SetCursorPosition(25, 7);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Hello world aussi");
        Console.SetCursorPosition(iX, iY);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\tEn dessous du premier " + iX + " " + iY);
        Console.ResetColor();

    }

    private static void DessineUneVoitureEtLaDeplace()
    {
        Console.WriteLine("---> DessineUneVoitureEtLaDeplace");
        int i = 0;
        int j = 0;
        int iLargeur = 21;
        int iHauteur = 4;
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
                        Console.MoveBufferArea(i, j, iLargeur, iHauteur, i - 1, j);
                        i--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (i < Console.WindowWidth - iLargeur)
                    {
                        Console.MoveBufferArea(i, j, iLargeur, iHauteur, i + 1, j);
                        i++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (j > 0)
                    {
                        Console.MoveBufferArea(i, j, iLargeur, iHauteur, i, j - 1);
                        j--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    Console.MoveBufferArea(i, j, iLargeur, iHauteur, i, j + 1);
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
        int iNoteDo = 262;
        int iNoteRe = 294;
        int iNoteMi = 330;
        int iNoire = 400;
        int iBlanche = 800;

        Console.Beep(iNoteDo, iNoire);
        Console.Beep(iNoteDo, iNoire);
        Console.Beep(iNoteDo, iNoire);
        Console.Beep(iNoteRe, iNoire);
        Console.Beep(iNoteMi, iBlanche);
        Console.Beep(iNoteRe, iBlanche);
        Console.Beep(iNoteDo, iNoire);
        Console.Beep(iNoteMi, iNoire);
        Console.Beep(iNoteRe, iNoire);
        Console.Beep(iNoteRe, iNoire);
        Console.Beep(iNoteDo, iNoire);
    }
    public static void ManipulationListe()
    {
        List<string> AuthorList = new List<string>();
        AuthorList.Add("Mahesh Chand");
        AuthorList.Add("Praveen Kumar");
        AuthorList.Add("Raj Kumar");
        AuthorList.Add("Nipun Tomar");
        AuthorList.Add("Mahesh Chand");
        AuthorList.Add("Dinesh Beniwal");
        foreach (var author in AuthorList)
        {
            Console.WriteLine(author);
        }
        Console.WriteLine("-------------");
        // Contains - Check if an item is in the list    
        if (AuthorList.Contains("Mahesh Chand"))
        {
            Console.WriteLine("Author found!");
        }

        // Find an item and replace it with new item  
        int iIdx = AuthorList.IndexOf("Nipun Tomar");
        if (iIdx >= 0)
        {
            AuthorList[iIdx] = "New Author";
        }
        Console.WriteLine("\nIndexOf ");
        foreach (var author in AuthorList)
        {
            Console.WriteLine(author);
        }
        Console.WriteLine();
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


class Student
{
    public int Id { get; set; }
    public string sName { get; set; }
    public string sDegree { get; set; }
    public List<string> Hobbies { get; set; }
    public override string ToString()
    {
        // affiche le contenu de l'objet
        return string.Format("Student Information:\n\tId:{0},\n\tName :{1},\n\tDegree :{2},\n\tHobbies :{3}",
            Id, sName, sDegree, string.Join(", ", Hobbies.ToArray()));
    }
}



