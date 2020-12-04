using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace MagicSquare
{
    public class Persistence
    {
        // module pour sauvegarder dans un fichier le damier ou restituer un fichier dans le programme
        public string root;
        public string backupFolder;
        public string longMagicSquareType;
        public string shortMagicSquareType;
        public string magicSquareLabel;
     public   List<string> targetFilesList;
        public Grid grid;
      public  FileName openingFile;
     public   FileName backupFile;
       public int selectedMenuOption;


        //public Grid grid { get => grid; set => grid = value; }
        //public FileName openingFile { get => openingFile; set => openingFile = value; }
        //public FileName backupFile { get => backupFile; set => backupFile = value; }
        //public int selectedMenuOption { get => selectedMenuOption; set => selectedMenuOption = value; }

        enum magicSquareType
        {// ce sont des entiers à compter de zéro
            ec = 1,
            r
        }

        public Persistence()
        {

            /** ***************************************************************
             +
             * Fonction pour créer le dossier de sauvegarde à un emplacement racine
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
            Uti.Info("Persistance", "Persistance", "");


            root = @"";
            backupFolder = @"svgCarresMagiques\";
            openingFile = new FileName("");
            backupFile = new FileName("");

        }


        public void Reset()
        {
            openingFile.ResetFileName();
            backupFile.ResetFileName();
        }

        public void SetRootFolderLocation()
        {
            Uti.Info("Persistance", "TrouverEmplacementDossierRacine", "");

            root = @"";
            bool isFileExisting = false;
            while (!isFileExisting)
            {
                //Console.WriteLine("Faîtes un copier-coller du chemin de dossier pour donne un emplacement au dossier de sauvegarde");
                //sRacine = Console.ReadLine();
                // trouver un emplacement au dossier de sauvegarde
                // si le dossier existe déjà
                // le dossier "Mes Documents"




                try
                {
                    // code provoquant une exception
                    root = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    root = AddFolderSeparator(root);
                    string interim = Path.Combine(root, backupFolder);
                    string s = @"en-cours";
                    string interim2 = Path.Combine(interim, s);
                    Directory.CreateDirectory(interim2);
                    s = @"resolus";
                    string interim3 = Path.Combine(interim, s);
                    Directory.CreateDirectory(interim3);
                    if (Directory.Exists(interim2) && (Directory.Exists(interim3)))
                    {
                        isFileExisting = true;
                    }
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

            }
        }
        public string AddFolderSeparator(string path)
        {
            path += @"\";
            return path;
        }
        public void SuggestSavingTheGrid(bool save)
        {
            /* ***************************************************************
            +  
            * Fonction pour sauvegarder la grille en cours d'utilisation
            * les paramètres:
            * 1 : grille (Grid)
            * 2 : booleen pour proposer ou non la sauvegarde (bool)
            * 3 : + (+)
            * 4 : + (+)
            * 5 : + (+)
            * retour: + (+)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            Uti.Info("Persistance", "ProposerSauvegarderGrille", "");
            if (save)
            {
                if (Uti.Action("sauvegarder", "Opération de sauvegarde engagée.", "Perte du damier actuel", ""))
                {
                    SetRootFolderLocation();

                    bool bOk = false;
                    while (!bOk)
                    {
                        Console.WriteLine("Sauvegarde sur fichier .txt ou fichier .json? (T/J)");
                        ConsoleKeyInfo saisie = Console.ReadKey(true);
                        if (saisie.Key == ConsoleKey.T)
                        {
                            bOk = true;
                            // sauvegarder dans fichier texte
                            SaveInTextFile();
                        }
                        else
                        {
                            bOk = true;
                            // sauvegarder dans fichier texte
                            SaveInJsonFile();
                        }
                    }
                }
            }
        }
        public string returnsAddressBackUpFolder()
        {
            return root + backupFolder;
        }
        public void SaveInTextFile()//Grid pGrille)
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
            Uti.Info("Persistance", "SauvegarderDansFichierTxt", "");
            //accéder au dossier de sauvegarde svg
            //    s'il n'existe pas 
            //       le créer 
            if (!(Directory.Exists(root + backupFolder)))
            {
                //Uti.Mess("Création du dossier de sauvegarde");
                Directory.CreateDirectory(root + backupFolder);
            }
            backupFile.suffix = ".txt";
            //    si carre résolu
            //Uti.Mess("--->  sauvegarde dans fichier .txt");
            if (grid.magicSquareSolved)
            {
                //Uti.Mess("--->  carre magique résolu");
                if (selectedMenuOption == 2)
                {
                    //Uti.Mess("--->  option 2 : pas de fichier d'origine");
                    // création fichier sauvegarde dans 'resolu'
                    backupFile.value = grid.numerous;
                    backupFile.shortFileType = "r";
                    backupFile.labelFileType = "résolus";
                    backupFile.pathFileType = @"resolus\";
                    // occurrence et extension à déterminer plus tard
                }
                else
                {
                    //Uti.Mess("--->  option 3 : utilisation d'un fichier d'origine");
                    // si avant en cours 'ec' vers 'r'
                    if (openingFile.shortFileType != "r")// avant 'ec' passer à 'r'
                    {
                        /*
                           carré résolu à partir d'un fichier en cours et donc à supprimer
                           sauvegarde à faire dans résolu (nouveau fichier)
                        */
                        //Uti.Mess("--->  fichier d'origine de type en-cours à supprimer");
                        backupFile.prefix = openingFile.prefix;
                        backupFile.value = openingFile.value;
                        backupFile.shortFileType = "r";
                        backupFile.labelFileType = "résolus";
                        backupFile.pathFileType = @"resolus\";
                        // occurrence et extension à déterminer plus tard
                        // suppression du fichier en cours 
                        Console.WriteLine("Chemin du fichier à supprimer:");
                        Console.WriteLine(root + backupFolder + openingFile.pathFileType + openingFile.GivesFullFileName());
                        //Uti.Mess("--->  suppression fichier origine" + fichierOuverture.DonneNomFichierComplet());
                        File.Delete(root + backupFolder + openingFile.pathFileType + openingFile.GivesFullFileName());
                    }
                    else// avant rester à 'r'
                    {

                        /**/
                        //Uti.Mess("--->  fichier d'origine de type resolu");
                        // copie du nom de fichier mais fichier de remplacement non encore créé
                        backupFile.Copier(openingFile);
                    }
                }

                //  Uti.Mess("Sauvegarde du carré magique résolu.");
            }
            else
            {
                // non résolu
                //  Uti.Mess("--->  carré magique non résolu");
                // si avant 'r' on passe à 'ec'
                if (openingFile.shortFileType == "r")
                {
                    /*
                     cm non résolu à partir fichier cm résolu (à conserver)
                     création sauvegarde dans 'en-cour'
                     */
                    //   Uti.Mess("--->  fichier d'origine était de type résolu");
                    // ne pas le supprimer
                    backupFile.prefix = openingFile.prefix;
                    backupFile.value = openingFile.value;
                    backupFile.shortFileType = "ec";
                    backupFile.labelFileType = "en cours";
                    backupFile.pathFileType = @"en-cours\";
                    // occurrence et extension à déterminer plus tard
                }
                else
                {// si avant 'ec' , garder la même chose
                    if (selectedMenuOption == 2)
                    {
                        //    Uti.Mess("--->  option 2 : carré magique créée sans fichier d'origine");
                        backupFile.value = grid.numerous;
                        backupFile.shortFileType = "ec";
                        backupFile.labelFileType = "en cours";
                        backupFile.pathFileType = @"en-cours\";
                    }
                    else
                    {
                        //   Uti.Mess("--->  option 3 : carré magique chargé depuis un fichier d'origine");
                        backupFile.Copier(openingFile);
                        backupFile.suffix = ".txt";
                    }
                }
                // prépare le nom du fichier de sauvegarde et crée le fichier de sauvegarde
                Console.WriteLine("Sauvegarder l'état actuel du damier pour reprendre le jeu plus tard.");
            }
            // accéder au sous dossier 'resolus' ou 'en-cours'
            if (!Directory.Exists(root + backupFolder + backupFile.pathFileType))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(root + backupFolder + backupFile.pathFileType);
            }

            // si le nouveau fichier a le même nom qu'un fichier existant, le fichier ancien doit être supprimé
            if (selectedMenuOption == 3)
            {
                if (File.Exists(root + backupFolder + openingFile.pathFileType + openingFile.GivesFullFileName()))
                {
                    // supprimer fichier ouverture si de type en cours
                    if (openingFile.shortFileType.Equals("ec"))
                    {
                        //   Uti.Mess("--->  carré magique résolu");
                        File.Delete(root + backupFolder + openingFile.pathFileType + openingFile.GivesFullFileName());
                    }

                }
            }
            // créer le fichier de sauvegarde
            CreateBackupTextFile(root + backupFolder, backupFile.pathFileType);
        }
        public void SaveInJsonFile()
        {
            /* ***************************************************************
            +  
            * Fonction pour sauvegarder l'objet grille dans un fichier JSON
            * crée le dossier de sauvegarde s'il n'existe pas
            * crée le dossier parent s'il n'existe pas
            * met à jour l'objet nom fichier pour ses composantes
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
            Uti.Info("Persistance", "SauvegarderDansFichierJSON", "");
            /*
             persistance connait grille 
             grille connait persistance
             persistance connait
                racine typecm
                libcm
                connait nom chargé dans mémoire
                connait dossier sauvegarde
                connait dossier parent
                2 - connait pas le fichier d'ouverture car il n'y en a pas
                3 - connait nom fichier ouverture

             */
            //accéder au dossier de sauvegarde svg
            //    s'il n'existe pas 
            //       le créer 
            if (!(Directory.Exists(root + backupFolder)))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(root + backupFolder);
            }
            // selon que le cm est ou non résolu
            //  Uti.Mess("--->  sauvegarde dans fichier json");
            if (grid.magicSquareSolved)
            {
                //   Uti.Mess("--->  carré magique résolu");
                backupFile.shortFileType = "r";
                backupFile.labelFileType = "résolus";
                backupFile.pathFileType = @"resolus\";
            }
            else
            {
                //   Uti.Mess("--->  carré magique non résolu");
                backupFile.shortFileType = "ec";
                backupFile.labelFileType = "en cours";
                backupFile.pathFileType = @"en-cours\";
            }
            // prefixe nombre suffixe
            if (selectedMenuOption == 2)
            {
                //   Uti.Mess("--->  option 2 : pas de fichier d'origine");
                backupFile.value = grid.numerous;
            }
            else
            {
                //   Uti.Mess("--->  carré magique utilisé chargé depuis un fichier d'origine");
                backupFile.value = openingFile.value;
            }
            // vérification existence dossierParent
            if (!Directory.Exists(root + backupFolder + backupFile.pathFileType))
            {
                //   Uti.Mess("Création du dossier de sauvegarde");
                Directory.CreateDirectory(root + backupFolder + backupFile.pathFileType);
            }
            // connaitre occurrence

            // création donc incrémentation 
            backupFile.suffix = ".json";
            backupFile.occurrence = 0;
            switch (selectedMenuOption)
            {
                case 2:
                    // fichier 'r' ou 'ec' créé, il n'existait pas avant. Incrémentation obligatoire si risque d'écraser un fichier existant
                    //     Uti.Mess("--->  option 2");
                    while (File.Exists(root + backupFolder + backupFile.pathFileType + backupFile.ToString()))
                    {
                        backupFile.occurrence++;
                    }
                    break;
                case 3:
                    //  gestion du suffixe
                    //    Uti.Mess("--->  option 3");
                    if (grid.magicSquareSolved)
                    {
                        //       Uti.Mess("--->  carré magique résolu");
                        // fichier sauvegarde 'r'
                        if (openingFile.shortFileType == backupFile.shortFileType)
                        {
                            //         Uti.Mess("--->  fichier origine type résolu");
                            // fichier ouverture 'r'
                            while (File.Exists(root + backupFolder + backupFile.pathFileType + backupFile.ToString()))
                            {
                                backupFile.occurrence++;
                            }
                            /* 
                             il est supposé qu'il existe plusieurs combinaisons de carrés magiques gagnants
                             pas de suppression du carré magique même d'extention .txt 
                             */
                        }
                        else
                        {
                            //         Uti.Mess("--->  fichier origine type en cours");
                            // fichier ouverture 'ec' 
                            // supprimer le fichier 'ec' et créer un fichier 'r'
                            File.Delete(root + backupFolder + openingFile.pathFileType + openingFile.ToString());
                            backupFile.occurrence = 0;
                            while (File.Exists(root + backupFolder + backupFile.pathFileType + backupFile.ToString()))
                            {
                                backupFile.occurrence++;
                            }
                        }
                    }
                    else
                    {
                        //      Uti.Mess("--->  carré magique non résolu");
                        // carré magique non résolu suppression du fichier ouverture création d'un fichier de même nom

                        if (openingFile.shortFileType == "ec") // 'ec' reste 'ec'
                        {
                            //  Uti.Mess("--->  fichier ouverture de type en cours");
                            //  gestion du suffixe (qd fichier ouv est txt)
                            if (selectedMenuOption == 2)// création de fichier
                            {
                                //   Uti.Mess("--->  option 2");
                                backupFile.value = grid.numerous;
                                backupFile.shortFileType = "ec";
                                backupFile.labelFileType = "en cours";
                                backupFile.pathFileType = @"en-cours\";
                                // occurence déja à zéro
                                while (File.Exists(root + backupFolder + backupFile.pathFileType + backupFile.ToString()))
                                {
                                    backupFile.occurrence++;

                                }

                            }
                            else // remplacement de fichier
                            {
                                //   Uti.Mess("--->  option 3");
                                // copie nom fichier mais si change ext alors change occ
                                backupFile.Copier(openingFile);
                                //  gestion du suffixe à mettre json (il peut avoir été modifié par la copie précédente)
                                backupFile.suffix = ".json";
                                // si le suffixe change, l'occurrence doit repartir de zéro
                                if (openingFile.suffix != backupFile.suffix)
                                {

                                    backupFile.occurrence = 0;
                                    while (File.Exists(root + backupFolder + backupFile.pathFileType + backupFile.ToString()))
                                    {
                                        backupFile.occurrence++;
                                    }
                                }
                            }
                            File.Delete(root + backupFolder + openingFile.pathFileType + openingFile);
                        }
                        else
                        {
                            //  Uti.Mess("--->  fichier ouverture de type résolu");
                            //FichierSauvegarde.Copier(fichierOuverture);
                            //  gestion du suffixe
                            backupFile.suffix = ".json";
                            backupFile.occurrence = 0;
                            while (File.Exists(root + backupFolder + backupFile.pathFileType + backupFile.ToString()))
                            {
                                backupFile.occurrence++;
                            }
                        }
                    }
                    break;
            }
            // l'objet grille est passé en fichier JSON
            // Uti.Mess("--->  création du fichier json");
            CreationFichierJSON(grid, root + backupFolder + backupFile.pathFileType + backupFile.ToString());
        }

        public void CreateBackupTextFile(string backupFolder, string parentFolder)
        {
            /* ***************************************************************
            +
            * Fonction pour créer le fichier .txt dans le bon dossier sans 
            * écraser les fichiers concernant un carré magique de même taille
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
            Uti.Info("Persistance", "CreationFichierSauvegardeTxt", "");

            // prépare le nom du fichier de sauvegarde et crée le fichier de sauvegarde
            bool bOk = false;
            int iIndice = 0;
            string sTf = FileCategory(parentFolder);
            string fileName = "";

            //        préparer nom fichier de sauvegarde : cm+grille.iNombre+ec+n+.txt

            fileName = backupFolder + parentFolder + "cm" + grid.numerous + sTf + iIndice + ".txt";//        si existe déja 
            bOk = false;
            while (!bOk)
            {
                if (File.Exists(fileName))
                {
                    //            ajouter incrémentation
                    iIndice++;
                    fileName = backupFolder + parentFolder + "cm" + grid.numerous + sTf + iIndice + ".txt";

                    //Console.WriteLine("incrémentation.");
                }
                else
                {
                    //        créer fichier
                    /*
                     le contenu du fichier doit obéir à la structure suivante
                     ligne 1 : chemin du fichier lors sauvegarde
                     ligne 2 : "Carré magique de "
                     ligne 3 : grille.Nombre
                     ligne 4 : ***
                     ligne 5 : total à obtenir sur la résolution du carré magique
                     ligne 6 : ***
                     lignes suivantes  : les valeurs du carré magique par ligne. 
                     chaque valeur est suivi du tiret "-". Le tiret est directement 
                     suivi de la valeur suivante de la même ligne.
                     */

                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine(fileName);
                        sw.WriteLine("Carré magique de ");
                        sw.WriteLine(grid.numerous);
                        sw.WriteLine("***");
                        sw.WriteLine(grid.SumToFind().ToString());
                        sw.WriteLine("***");
                        // remplir avec le damier le fichier 
                        try
                        {
                            for (int i = 0; i < grid.numerous; i++)
                            {
                                for (int j = 0; j < grid.numerous; j++)
                                {

                                    // inscrire dans le fichier                                    
                                    sw.Write(grid.Checkerboard[i, j].value + "-");
                                }
                                sw.WriteLine("");
                            }
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
                    }
                    bOk = true;
                }
            }
        }
        public string FileCategory(string parentFolder)
        {
            Uti.Info("Persistance", "CategorieFichier", "");
            /* ***************************************************************
            +
            * Fonction pour savoir si le dossier parent est le dossier 'en-cours' 
            * ou 'resolus'
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
            if (parentFolder == @"en-cours\")
            {
                return "ec";
            }
            else
            {
                return "r";
            }
        }

        public bool IsBackupFilePresent()
        {
            Uti.Info("Persistance", "PresenceDossierSvg", "");
            /* ***************************************************************
            +
            * Fonction pour créer un dossier svg
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
            if (Directory.Exists(root))
            {
                if (Directory.Exists(root + backupFolder))
                    return true;
                else
                {
                    Console.WriteLine("Le dossier " + root + " existe mais le dossier " + backupFolder + " est manquant.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool isFolderPresent(string folderName)
        {
            Uti.Info("Persistance", "PresenceDossier", "");
            if (Directory.Exists(root + backupFolder + folderName))
            {
                return true;
            }
            else
            {
                Console.WriteLine("le dossier " + folderName + " n'existe pas.");
                return false;
            }
        }
        public void DisplayListOfExistingFiles()
        {
            /* ***************************************************************
            +
            * Fonction pour lister les fichiers de sauvegardes existants de carrés magiques
            * en cours ou résolus
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
            Uti.Info("Persistance", "AfficheListeFichiersExistants", "");
            // dossier: test 
            string sStr = root + backupFolder;
            string sCheminFichier = @"";
            int iPosExt;
            int iPosBarre;

            magicSquareType type;
            if (!IsBackupFilePresent())
            {
                Console.WriteLine("Aucune sauvegarde à ce jour.");
            }
            else
            {
                Console.WriteLine("fichier de sauvegarde trouvé.");
                // choisit entre fichiers résolus ou en-cours
                ChoixTypeFichierTxt();
                // affiche les fichiers selon le choix réalisé si la liste n'est pas vide
                if (AfficheListeFichiersExistantsCibles())
                {
                    // choix du numéro du carré magique
                    SelectionCMSelonTaille();
                    if (selectedMenuOption == 3)
                    {
                        openingFile.value = grid.numerous;
                    }
                    // limitation liste à des propostions pour une seule liste de fichiers de mêmes taille
                    if (ChoixOccurrence())
                    {
                        // choix de l'utilisateur
                        sCheminFichier = ChoixOccurrenceFichierTailleDeterminee();

                        //remplit les propriétés de l'objet à partir du nom de fichier
                        openingFile.FineNameDecomposition(sCheminFichier);


                        iPosExt = sCheminFichier.LastIndexOf(@".");
                        iPosBarre = sCheminFichier.LastIndexOf(@"\");

                        // analyse le nom du fichier pour remplir le fichierOuverture (NomFichier)
                        if (selectedMenuOption == 3)   // ouverture fichier existant pour y prendre les informations
                        {
                            // remplacement fichier
                            //Console.WriteLine("fichOuv ext : " + fichierOuverture.SSuffixe);
                            // longueur de la partie extension (avec le point)
                            int tailleExt = (sCheminFichier.Substring(iPosExt, (sCheminFichier.Length - iPosExt))).Length;
                            int tailleNomFichier = iPosExt - (iPosBarre + 1);
                            // donne le nom du fichier sans l'extension
                            Console.WriteLine(sCheminFichier.Substring((iPosBarre + 1), tailleNomFichier));
                        }
                        // ouverture du fichier
                        if (openingFile.suffix == ".txt")
                        {
                            // ???
                            OuvrirFichierTxt(sCheminFichier);
                        }
                        else
                        {
                            OuvrirFichierJSON(sCheminFichier);
                        }
                        // lancer les permutations menu ---> persistance 
                        Console.WriteLine();
                        // fournir la persistance à la grille
                        grid.persistence = this;
                        grid.MagicSquareManipulation();
                    }
                }
            }
        }
        public bool AfficheListeFichiersExistantsCibles()
        {
            Uti.Info("Persistance", "AfficheListeFichiersExistantsCibles", "");
            int iResultat = 0;
            string sResultat = "";
            int i = 0;
            string[] tabCibles = new string[100];
            targetFilesList = new List<string>();
            // récupération des chemins de dossiers contenant les fichiers de sauvegarde s'ils existent
            if (longMagicSquareType == @"en-cours\" || longMagicSquareType == @"resolus\")
            {
                if (isFolderPresent(longMagicSquareType))
                {
                    // afficher les fichiers existants
                    Console.WriteLine("le fichier " + magicSquareLabel + " existe");
                    //sauvegardeARestaurer = true;
                    tabCibles = Directory.GetFiles(root + backupFolder + longMagicSquareType);
                }
                // ajout au tableau des titres de fichiers existants dans la liste concernée
                foreach (string sCheminFichier in tabCibles)
                {
                    if (sCheminFichier != "")
                    {
                        i++;
                        targetFilesList.Add(sCheminFichier);
                    }
                }
                // affichage de la liste de fichiers
                Console.WriteLine(" Les carrés magiques " + magicSquareLabel + ":");
                foreach (string sS in targetFilesList)
                {
                    //Console.WriteLine(s);
                    iResultat = sS.LastIndexOf(@"\");
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = sS.Substring((iResultat + 1), (sS.Length - iResultat - 1));
                    // donne le nom du fichier seul
                    Console.WriteLine(sResultat);
                }
            }
            if (targetFilesList.Count > 0)
            {
                // liste remplie 
                Console.WriteLine("Filtrez en fonction de la valeur du carré magique qui vous intéresse.");
                return true;
            }
            else
            {
                // liste vide
                Console.WriteLine("Aucun fichier sauvegardé dans ce dossier.");
                return false;
            }
        }


        public void OuvrirFichierTxt(string sCheminFichier)
        {
            Uti.Info("Persistance", "OuvrirFichierTxt", "");
            /* ***************************************************************
                   OuvrirFichier

             * Fonction pour afficher le titre d'un fichier sans le chemin
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

            /*
                convention liée à la structure du fichier
                indice l 0 de tabContenuFichier
                incice l 2 iNombre 
                incice l 4 total à trouver
                incice l 6 début des valeurs du carré magique             
            */

            List<string> listeContenuFichier = new List<string>();
            int iValeur = 0;
            string sFragment = "";
            //string resultat = "";
            int i = 0;
            int j = 0;
            //int k = 0;
            int iIndiceLigne = 0;
            int iL = 0;
            //int m = 0;
            int iDepart = 5;
            string sLigne = "";
            string[] tabContenuFichier;
            string[,] fragments = new string[grid.numerous, grid.numerous];
            //Console.WriteLine(sCheminFichier);
            // renseigne la propriété 'nomFichierChargeDansMemoire'
            //ObtenirNomFichier(sCheminFichier);
            // remplissage liste contenu fichier
            using (StreamReader sr = File.OpenText(sCheminFichier))
            {
                string sS = sr.ReadLine();
                Console.WriteLine(sS);
                while ((sS = sr.ReadLine()) != null)
                {
                    listeContenuFichier.Add(sS);
                }
            }
            tabContenuFichier = listeContenuFichier.ToArray();
            // pour une ligne du fichier
            for (iL = iDepart; iL < (iDepart + grid.numerous); iL++)
            {
                // récuper la valeur
                sLigne = tabContenuFichier[iL];
                // remplir le fragment  d'un iNombre de la ligne
                while ((iIndiceLigne + 1) < sLigne.Length)
                {
                    if (sLigne[iIndiceLigne] != '-')
                    {
                        sFragment = sLigne[iIndiceLigne].ToString();

                        while (/*(indiceLigne + 1) < ligne.Length || */sLigne[iIndiceLigne + 1] != '-') // lorsque le fragment compte plus d'un chiffre
                        {
                            if ((iIndiceLigne + 1) != (sLigne.Length - 1))

                                iIndiceLigne++;
                            sFragment += sLigne[iIndiceLigne];

                        }
                        // fragment à convertir en entier
                        if (int.TryParse(sFragment, out iValeur))
                        {
                            // c'est un entier
                            //Console.WriteLine("case " + i + "." + j + " : " + value);
                            // remplissage dans la grille
                            grid.ChangeGridCellValue(i, j, iValeur);
                            j++;
                            if (j == grid.numerous)
                            {
                                i++;
                                j = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("impossible");
                        }
                    }
                    iIndiceLigne++;
                }
                iIndiceLigne = 0;
                // à placer dans le damier
            }
            ////afficher le damier
            //persistanceGrille.AffiDamier();
        }
        public void OuvrirFichierJSON(string sCheminFichier)
        {
            Uti.Info("Persistance", "OuvrirFichierJSON", "");
            /* ***************************************************************
                   OuvrirFichier

             * Fonction pour afficher le titre d'un fichier sans le chemin
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
            /*
                convention liée à la structure du fichier
                indice l 0 de tabContenuFichier
                incice l 2 iNombre 
                incice l 4 total à trouver
                incice l 6 début des valeurs du carré magique             
            */
            List<string> listeContenuFichier = new List<string>();
            int i = 0;
            int j = 0;
            string sGrilleJSON;
            Console.WriteLine(sCheminFichier);
            // stocke le contenu du fichier dans la variable 

            sGrilleJSON = File.ReadAllText(sCheminFichier);
            // charge le fichier JSON dans une instance adaptée    
            Grid plop = new Grid();
            Console.WriteLine("Deserialization persistanceGrille--->" + grid);
            plop.Checkerboard = JsonConvert.DeserializeObject<Grid>(sGrilleJSON).Checkerboard;
            foreach (Cell cell in grid.Checkerboard)
            {
                cell.value = plop.Checkerboard[i, j].value;
                j++;
                if (j == grid.numerous)
                {
                    i++;
                    j = 0;
                }
            }
            ////afficher le damier
            //persistanceGrille.AffiDamier();
        }
        public void ChoixFichierAOuvrir(Grid grille)
        {
            Uti.Info("Persistance", "ChoixFichierAOuvrir", "");
            /* ***************************************************************
                   ChoixFichierAOuvrir

             * Fonction pour que l'utilisateur précise quelle fichier il veut 
             * ouvrir en spécitiant :
             *   - la taille du carré
             *   - la nature en-cours ou résolu du fichier
             *   - l'occurrence
             * les paramètres:
             * 1 : grille (Grid)
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
            string sNomFichier = "";
            // fichier en-cours ou résolus?
            ChoixTypeFichierTxt();
            // vérification que ce dossier existe ...
            string sChemin = root + backupFolder;
            if (Directory.Exists(sChemin + longMagicSquareType + sNomFichier))
            {
                // alors chercher le dossier
                Console.WriteLine("Ce dossier est existe.");
            }
            else
            {
                Console.WriteLine("Ce dossier est introuvable.");
            }
        }

        public void SelectionCMSelonTaille()
        {
            /* ***************************************************************
           * Fonction pour afficher les carrés magiques de même taille de la liste sans le chemin.
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
            Uti.Info("Persistance", "SelectionCMSelonTaille", "");
            char cCarac = ' ';
            string sResultat = "";
            int iOrdre = 0;
            int iPosCaracAvPreLettNomFic = 0;
            int iPrecedent = 0;
            List<string> listeFichiersRetenus = new List<string>();
            grid = new Grid();
            grid.build(Grid.DeterminationTailleSansInstance());
            // initialisation 
            grid.CheckerboardInitialization();
            // affichage
            if (shortMagicSquareType == "ec")
            {
                cCarac = 'e';
                foreach (string sCheminFichier in targetFilesList)
                {
                    iPosCaracAvPreLettNomFic = sCheminFichier.LastIndexOf(@"\");
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = sCheminFichier.Substring((iPosCaracAvPreLettNomFic + 1), (sCheminFichier.Length - iPosCaracAvPreLettNomFic - 1));
                    if (iPosCaracAvPreLettNomFic != iPrecedent)
                    {
                        iOrdre = targetFilesList.IndexOf(sCheminFichier) + 1;
                        // si le fichier correspond à la valeur du carré magique, afficher le nom
                        // du fichier et le stocker dans la list
                        if (Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, cCarac, 1) == grid.numerous.ToString())
                        {
                            listeFichiersRetenus.Add(sCheminFichier);
                        }
                    }
                }
            }
            else
            {
                cCarac = 'r';
                foreach (string sCheminFichier in targetFilesList)
                {
                    iPosCaracAvPreLettNomFic = sCheminFichier.LastIndexOf(@"\");
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = sCheminFichier.Substring((iPosCaracAvPreLettNomFic + 1), (sCheminFichier.Length - iPosCaracAvPreLettNomFic - 1));
                    if (iPosCaracAvPreLettNomFic != iPrecedent)
                    {
                        //ordre++;
                        iOrdre = targetFilesList.IndexOf(sCheminFichier) + 1;
                        // si le fichier correspond à la valeur du carré magique, afficher le nom
                        // du fichier et le stocker dans la list
                        if (Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, cCarac, 1) == grid.numerous.ToString())
                        {
                            listeFichiersRetenus.Add(sCheminFichier);
                        }
                    }
                }
            }
            targetFilesList = null;
            targetFilesList = listeFichiersRetenus;
        }
        public void CreationFichierJSON(Grid PersistanceGrille, String s)
        {
            /*Fonction pour créer le fichier JSON et le remplir
             * les paramètres:
             *1 : grille à sauvegarer(Grid)
            * 2 : adresse de la lettre du lecteur au nom du fichier(string)
            * 3 : +(+)
            * 4 : +(+)
            * 5 : +(+)
            * retour: +(+)
            * exemple(s):
              *+
              *Ce qui est impossible:
             *+
            *****************************************************************/
            Uti.Info("Persistance", "ChoixOccurrence", "");
            string jsonSerializedObj = JsonConvert.SerializeObject(grid);
            File.WriteAllText(s, jsonSerializedObj);
            // affiche le contenu du fichier json
            //Console.WriteLine(jsonSerializedObj);
            Console.WriteLine("Fichier de sauvegarde au format .json créé.");
        }
        public bool ChoixOccurrence()
        {
            /* ***************************************************************
                   

             * Fonction pour afficher indiquer la quantité d'occurrences d'un même fichier
             * la liste de l'instance ne contient que les fichiers de mêmes taille de carré
             * magique
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
            Uti.Info("Persistance", "ChoixOccurrence", "");
            string[] propositionsCM;
            int iIndice = 0;
            if (targetFilesList.Count > 0)
            {
                propositionsCM = targetFilesList.ToArray();
                Console.WriteLine("les propositions:");
                foreach (string sProposition in propositionsCM)
                {
                    Console.WriteLine(iIndice + ". " + sProposition);
                    iIndice++;
                }
                return true;
            }
            else
            {
                return false;
            }


        }
        public void ChoixTypeFichierTxt()
        {
            Uti.Info("Persistance", "ChoixTypeFichier", "");
            /* ***************************************************************
                   OuvrirFichier

             * Fonction pour déterminer s'il s'agit d'un fichier en cours ou
             * d'un fichier resolus et renseigne la variable de classe typeDossier
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
            // déterminer si c'est un fichier en cours ou resolus
            magicSquareType choice = magicSquareType.ec;
            string stringInput = "";
            int integerInput = 0;
            // actualise les propriétés relatives au fichier en fonction de 
            //la saisie utilisateur
            while (integerInput < 1 || integerInput > 2)
            {
                Console.WriteLine("Choisisser la catégorie de fichier de carré magique à ouvrir:");
                Console.WriteLine("1. en cours");
                Console.WriteLine("2. résolus");
                stringInput = Console.ReadLine();
                if (int.TryParse(stringInput, out integerInput))
                {
                    if (integerInput < (int)magicSquareType.ec || integerInput > (int)magicSquareType.r)
                    {
                        Console.WriteLine("La saisie doit être comprise entre " + (int)magicSquareType.ec + " et " + (int)magicSquareType.r);
                    }
                    else
                    {
                        if (integerInput == 1)
                        {
                            choice = magicSquareType.ec;
                            shortMagicSquareType = "ec";
                            longMagicSquareType = @"en-cours\";
                            magicSquareLabel = "en cours";
                        }
                        else
                        {
                            choice = magicSquareType.r;
                            shortMagicSquareType = "r";
                            longMagicSquareType = @"resolus\";
                            magicSquareLabel = "résolus";
                        }

                        Console.WriteLine(longMagicSquareType);

                    }

                }
                else
                {
                    Console.WriteLine("Cette saisie n'est pas un entier.");
                }
            }
        }
        public string ChoixOccurrenceFichierTailleDeterminee()
        {
            Uti.Info("Persistance", "ChoixOccurrenceFichierTailleDetermine", "");
            /* ***************************************************************
              Ouvrir occurence fichier précise

            * Fonction pour déterminer s'il s'agit d'un fichier en cours ou
            * d'un fichier resolus et renseigne la variable de classe typeDossier
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
            string sSaisie = "";
            //int iSaisie = 0;
            int iIndice = 99;
            string sChaine = "";
            string sNomFich = "";
            int iResultat = 0;
            bool bOkIndice = false;
            // conversion liste en tableau
            string[] choixPossibles = targetFilesList.ToArray();
            // demande le fichier à ouvrir jusqu'à avoir une proposition acceptable et l'ouvre
            // ouverture de fichier avec le chemin
            while (!bOkIndice)
            {
                Console.WriteLine("votre proposition?");
                sSaisie = Console.ReadLine();
                if (int.TryParse(sSaisie, out iIndice))
                {
                    // l'indicie d'occurrence commence à partir de 0
                    if (iIndice >= 0 && iIndice < choixPossibles.Length)
                    {
                        sChaine = choixPossibles[iIndice];
                        openingFile.FineNameDecomposition(sChaine);
                        bOkIndice = true;
                    }
                }
                else
                {
                    Console.WriteLine("impossible");
                }
            }
            // retourne le chemin du fichier à ouvrir
            return sChaine;
        }
    }
}
