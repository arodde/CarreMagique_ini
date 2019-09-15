using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace CarreMagique
{
    public class Persistance
    {
        // module pour sauvegarder dans un fichier le damier ou restituer un fichier dans le programme
        private string sRacine;
        private string sDossSvg;
        private string sTypeCMLongs;
        private string sTypeCMCours;
        private string sTypeCMLongsLib;
        List<string> listeFichiersCibles;
        private Grille persistanceGrille;
        NomFichier fichierOuverture;
        NomFichier fichierSauvegarde;
        int optionMenu;


        public Grille PersistanceGrille { get => persistanceGrille; set => persistanceGrille = value; }
        public NomFichier FichierOuverture { get => fichierOuverture; set => fichierOuverture = value; }
        public NomFichier FichierSauvegarde { get => fichierSauvegarde; set => fichierSauvegarde = value; }
        public int OptionMenu { get => optionMenu; set => optionMenu = value; }

        enum TypeCarreMagique
        {// ce sont des entiers à compter de zéro
            ec = 1,
            r
        }

        public Persistance()
        {
            /* ***************************************************************
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
           

            sRacine = @"";
            sDossSvg = @"svgCarresMagiques\";
            fichierOuverture = new NomFichier("");
            fichierSauvegarde = new NomFichier("");

        }
       
     
        public void Reinitialiser()
        {
            fichierOuverture.RAZNomFichier();
            fichierSauvegarde.RAZNomFichier();
        }

        public void DefinirEmplacementDossierRacine()
        {
            Uti.Info("Persistance", "TrouverEmplacementDossierRacine", "");

            sRacine = @"";
            bool bDossierExiste = false;
            while (!bDossierExiste)
            {
                //Console.WriteLine("Faîtes un copier-coller du chemin de dossier pour donne un emplacement au dossier de sauvegarde");
                //sRacine = Console.ReadLine();
                // trouver un emplacement au dossier de sauvegarde
                // si le dossier existe déjà
                // le dossier "Mes Documents"




                try
                {
                    // code provoquant une exception
                    sRacine = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    sRacine = AjouterSeparateurFichier(sRacine);
                    string provisoire = Path.Combine(sRacine, sDossSvg);
                    string s = @"en-cours";
                    string provisoire2 = Path.Combine(provisoire, s);
                    Directory.CreateDirectory(provisoire2);
                    s = @"resolus";
                    string provisoire3 = Path.Combine(provisoire, s);
                    Directory.CreateDirectory(provisoire3);
                    if (Directory.Exists(provisoire2) && (Directory.Exists(provisoire3)))
                    {
                        bDossierExiste = true;
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
        public string AjouterSeparateurFichier(string sChemin)
        {
            sChemin += @"\";
            return sChemin;
        }
        public void ProposerSauvegarderGrille(bool bOuiSauvegarder)
        {
            /* ***************************************************************
            +  
            * Fonction pour sauvegarder la grille en cours d'utilisation
            * les paramètres:
            * 1 : grille (Grille)
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
            if (bOuiSauvegarder)
            {
                if (Uti.Action("sauvegarder", "Sauvegarde en cours.", "Perte du damier actuel", ""))
                {
                    DefinirEmplacementDossierRacine();
                    
                    bool bOk = false;
                    while (!bOk)
                    {
                        Console.WriteLine("Sauvegarde sur fichier .txt ou fichier .json? (T/J)");
                        ConsoleKeyInfo saisie = Console.ReadKey(true);
                        if (saisie.Key == ConsoleKey.T)
                        {
                            bOk = true;
                            // sauvegarder dans fichier texte
                            SauvegarderDansFichierTxt();
                        }
                        else
                        {
                            bOk = true;
                            // sauvegarder dans fichier texte
                            SauvegarderDansFichierJSON();
                        }
                    }
                }
            }
        }
        public string RetourneAdresseDossierSvg()
        {
            return sRacine + sDossSvg;
        }
        public void SauvegarderDansFichierTxt()//Grille pGrille)
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
            if (!(Directory.Exists(sRacine + sDossSvg)))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(sRacine + sDossSvg);
            }
            FichierSauvegarde.SSuffixe = ".txt";
            //    si carre résolu
            if (persistanceGrille.BCarreMagiqueResolu)
            {
                if (optionMenu == 2)
                {
                    fichierSauvegarde.INombre = persistanceGrille.INombre;
                    fichierSauvegarde.STypeFichierCourt = "r";
                    fichierSauvegarde.STypeFichierLib = "résolus";
                    fichierSauvegarde.STypeFichierPath = @"resolus\";
                    // occurrence et extension à déterminer plus tard
                }
                else
                {
                    // si avant en cours 'ec' vers 'r'
                    if (fichierOuverture.STypeFichierCourt != "r")// avant 'ec' passer à 'r'
                    {
                        fichierSauvegarde.SPrefixe = fichierOuverture.SPrefixe;
                        fichierSauvegarde.INombre = fichierOuverture.INombre;
                        fichierSauvegarde.STypeFichierCourt = "r";
                        fichierSauvegarde.STypeFichierLib = "résolus";
                        fichierSauvegarde.STypeFichierPath = @"resolus\";
                        // occurrence et extension à déterminer plus tard
                        // suppression du fichier en cours 
                        Console.WriteLine("Chemin du fichier à supprimer:");
                        Console.WriteLine(sRacine + sDossSvg+ fichierOuverture.STypeFichierPath + fichierOuverture.DonneNomFichierComplet());
                        File.Delete(sRacine +sDossSvg+ fichierOuverture.STypeFichierPath + fichierOuverture.DonneNomFichierComplet());
                    }
                    else// avant rester à 'r'
                    {
                        // copie du nom de fichier mais fichier de remplacement non encore créé
                        fichierSauvegarde.Copier(fichierOuverture);
                    }
                }

                Console.WriteLine("Sauvegarde du carré magique résolu.");
            }
            else
            {
                // non résolue
                // si avant 'r' on passe à 'ec'
                if (fichierOuverture.STypeFichierCourt == "r")
                {
                    // ne pas le supprimer
                    fichierSauvegarde.SPrefixe = fichierOuverture.SPrefixe;
                    fichierSauvegarde.INombre = fichierOuverture.INombre;
                    fichierSauvegarde.STypeFichierCourt = "ec";
                    fichierSauvegarde.STypeFichierLib = "en cours";
                    fichierSauvegarde.STypeFichierPath = @"en-cours\";
                    // occurrence et extension à déterminer plus tard
                }
                else
                {// si avant 'ec' , garder la même chose
                    if (optionMenu == 2)
                    {

                        fichierSauvegarde.INombre = persistanceGrille.INombre;
                        fichierSauvegarde.STypeFichierCourt = "ec";
                        fichierSauvegarde.STypeFichierLib = "en cours";
                        fichierSauvegarde.STypeFichierPath = @"en-cours\";
                    }
                    else
                    {
                        fichierSauvegarde.Copier(fichierOuverture);
                        FichierSauvegarde.SSuffixe = ".txt";
                    }
                }
                // prépare le nom du fichier de sauvegarde et crée le fichier de sauvegarde
                Console.WriteLine("Sauvegarder l'état actuel du damier pour reprendre le jeu plus tard.");
            }
            // accéder au sous dossier 'resolus' ou 'en-cours'
            if (!Directory.Exists(sRacine + sDossSvg + fichierSauvegarde.STypeFichierPath))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(sRacine + sDossSvg + fichierSauvegarde.STypeFichierPath);
            }

            // si le nouveau fichier a le même nom qu'un fichier existant, le fichier ancien doit être supprimé
            if (optionMenu == 3)
            {
                if (File.Exists(sRacine + sDossSvg + fichierOuverture.STypeFichierPath + fichierOuverture.DonneNomFichierComplet()))
                {
                    File.Delete(sRacine + sDossSvg + fichierOuverture.STypeFichierPath + fichierOuverture.DonneNomFichierComplet());
                }
            }
            // créer le fichier de sauvegarde
            CreationFichierSauvegardeTxt(sRacine + sDossSvg, fichierSauvegarde.STypeFichierPath);
        }
        public void SauvegarderDansFichierJSON()
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
            if (!(Directory.Exists(sRacine + sDossSvg)))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(sRacine + sDossSvg);
            }
            // selon que le cm est ou non résolu
            if (PersistanceGrille.BCarreMagiqueResolu)
            {
                FichierSauvegarde.STypeFichierCourt = "r";
                FichierSauvegarde.STypeFichierLib = "résolus";
                FichierSauvegarde.STypeFichierPath = @"resolus\";
            }
            else
            {
                FichierSauvegarde.STypeFichierCourt = "ec";
                FichierSauvegarde.STypeFichierLib = "en cours";
                FichierSauvegarde.STypeFichierPath = @"en-cours\";
            }
            // prefixe nombre suffixe
            if (optionMenu == 2)
            {
                FichierSauvegarde.INombre = persistanceGrille.INombre;
            }
            else
            {
                FichierSauvegarde.INombre = fichierOuverture.INombre;
            }
            // vérification existence dossierParent
            if (!Directory.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath);
            }
            // connaitre occurrence

            // création donc incrémentation 
            FichierSauvegarde.SSuffixe = ".json";
            FichierSauvegarde.IOccurence = 0;
            switch (optionMenu)
            {
                case 2:
                    // fichier 'r' ou 'ec' créé, il n'existait pas avant. Incrémentation obligatoire si risque d'écraser un fichier existant
                    while (File.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString()))
                    {
                        FichierSauvegarde.IOccurence++;
                    }
                    break;
                case 3:
                    //  gestion du suffixe
                    if (persistanceGrille.BCarreMagiqueResolu)
                    {

                        // fichier sauvegarde 'r'
                        if (fichierOuverture.STypeFichierCourt == fichierSauvegarde.STypeFichierCourt)
                        {
                            // fichier ouverture 'r'
                            while (File.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString()))
                            {
                                FichierSauvegarde.IOccurence++;
                            }
                            /* 
                             il est supposé qu'il existe plusieurs combinaisons de carrés magiques gagnants
                             pas de suppression du carré magique même d'extention .txt 
                             */
                        }
                        else
                        {
                            // fichier ouverture 'ec' 
                            // supprimer le fichier 'ec' et créer un fichier 'r'
                            File.Delete(sRacine + sDossSvg + fichierOuverture.STypeFichierPath + fichierOuverture.ToString());
                            FichierSauvegarde.IOccurence = 0;
                            while (File.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString()))
                            {
                                FichierSauvegarde.IOccurence++;
                            }
                        }
                    }
                    else
                    {
                        // carré magique non résolu suppression du fichier ouverture création d'un fichier de même nom
                        if (fichierOuverture.STypeFichierCourt == "ec") // 'ec' reste 'ec'
                        {

                            //  gestion du suffixe (qd fichier ouv est txt)
                            if (optionMenu == 2)// création de fichier
                            {
                                fichierSauvegarde.INombre = persistanceGrille.INombre;
                                FichierSauvegarde.STypeFichierCourt = "ec";
                                FichierSauvegarde.STypeFichierLib = "en cours";
                                FichierSauvegarde.STypeFichierPath = @"en-cours\";
                                // occurence déja à zéro
                                while (File.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString()))
                                {
                                    FichierSauvegarde.IOccurence++;

                                }

                            }
                            else // remplacement de fichier
                            {
                                // copie nom fichier mais si change ext alors change occ
                                FichierSauvegarde.Copier(fichierOuverture);
                                //  gestion du suffixe à mettre json (il peut avoir été modifié par la copie précédente)
                                FichierSauvegarde.SSuffixe = ".json";
                                // si le suffixe change, l'occurrence doit repartir de zéro
                                if (FichierOuverture.SSuffixe != FichierSauvegarde.SSuffixe)
                                {
                                    FichierSauvegarde.IOccurence = 0;
                                    while (File.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString()))
                                    {
                                        FichierSauvegarde.IOccurence++;
                                    }
                                }
                            }
                            File.Delete(sRacine + sDossSvg + fichierOuverture.STypeFichierPath + fichierOuverture);
                        }
                        else
                        {
                            //FichierSauvegarde.Copier(fichierOuverture);
                            //  gestion du suffixe
                            FichierSauvegarde.SSuffixe = ".json";
                            FichierSauvegarde.IOccurence = 0;
                            while (File.Exists(sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString()))
                            {
                                FichierSauvegarde.IOccurence++;
                            }
                        }
                    }
                    break;
            }
            // l'objet grille est passé en fichier JSON
            CreationFichierJSON(persistanceGrille, sRacine + sDossSvg + FichierSauvegarde.STypeFichierPath + FichierSauvegarde.ToString());
        }
        
        public void CreationFichierSauvegardeTxt(string sDossSvg, string sDossParent)
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
            Uti.MessErr("Emplacement à revoir");
            // prépare le nom du fichier de sauvegarde et crée le fichier de sauvegarde
            bool bOk = false;
            int iIndice = 0;
            string sTf = CategorieFichier(sDossParent);
            string sNomFichier = "";

            //        préparer nom fichier de sauvegarde : cm+grille.iNombre+ec+n+.txt

            sNomFichier = sDossSvg + sDossParent + "cm" + persistanceGrille.INombre + sTf + iIndice + ".txt";//        si existe déja 
            bOk = false;
            while (!bOk)
            {
                if (File.Exists(sNomFichier))
                {
                    //            ajouter incrémentation
                    iIndice++;
                    sNomFichier = sDossSvg + sDossParent + "cm" + persistanceGrille.INombre + sTf + iIndice + ".txt";

                    Console.WriteLine("incrémentation.");
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

                    using (StreamWriter sw = File.CreateText(sNomFichier))
                    {
                        sw.WriteLine(sNomFichier);
                        sw.WriteLine("Carré magique de ");
                        sw.WriteLine(persistanceGrille.INombre);
                        sw.WriteLine("***");
                        sw.WriteLine(persistanceGrille.SommeATrouver().ToString());
                        sw.WriteLine("***");
                        // remplir avec le damier le fichier 
                        try
                        {
                            for (int i = 0; i < persistanceGrille.INombre; i++)
                            {
                                for (int j = 0; j < persistanceGrille.INombre; j++)
                                {

                                    // inscrire dans le fichier                                    
                                    sw.Write(persistanceGrille.Damier[i, j].IValeur + "-");
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
        public string CategorieFichier(string sDossParent)
        {
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
            if (sDossParent == @"en-cours\")
            {
                return "ec";
            }
            else
            {
                return "r";
            }
        }
       
        public bool PresenceDossierSvg()
        {
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
            if (Directory.Exists(sRacine))
            {
                if (Directory.Exists(sRacine + sDossSvg))
                    return true;
                else
                {
                    Console.WriteLine("Le dossier " + sRacine + " existe mais le dossier " + sDossSvg + " est manquant.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool PresenceDossier(string sNomDossier)
        {
            if (Directory.Exists(sRacine + sDossSvg + sNomDossier))
            {
                return true;
            }
            else
            {
                Console.WriteLine("le dossier " + sNomDossier + " n'existe pas.");
                return false;
            }
        }
        public void AfficheListeFichiersExistants()
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
            string sStr = sRacine + sDossSvg;
            string sCheminFichier = @"";
            int iPosExt;
            int iPosBarre;

            TypeCarreMagique type;
            if (!PresenceDossierSvg())
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
                    if (optionMenu == 3)
                    {
                        fichierOuverture.INombre = persistanceGrille.INombre;
                    }
                    // limitation liste à des propostions pour une seule liste de fichiers de mêmes taille
                    if (ChoixOccurrence())
                    {
                        // choix de l'utilisateur
                        sCheminFichier = ChoixOccurrenceFichierTailleDeterminee();

                        //remplit les propriétés de l'objet à partir du nom de fichier
                        fichierOuverture.TraitementChaine(sCheminFichier);


                        iPosExt = sCheminFichier.LastIndexOf(@".");
                        iPosBarre = sCheminFichier.LastIndexOf(@"\");

                        // analyse le nom du fichier pour remplir le fichierOuverture (NomFichier)
                        if (OptionMenu == 3)   // ouverture fichier existant pour y prendre les informations
                        {
                            // remplacement fichier
                            Console.WriteLine("fichOuv ext : " + fichierOuverture.SSuffixe);
                            // longueur de la partie extension (avec le point)
                            int tailleExt = (sCheminFichier.Substring(iPosExt, (sCheminFichier.Length - iPosExt))).Length;
                            int tailleNomFichier = iPosExt - (iPosBarre + 1);
                            // donne le nom du fichier sans l'extension
                            Console.WriteLine(sCheminFichier.Substring((iPosBarre + 1), tailleNomFichier));
                        }
                        // ouverture du fichier
                        if (fichierOuverture.SSuffixe == ".txt")
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
                        PersistanceGrille.GrillePersistance = this;
                        persistanceGrille.ManipulationCarreMagique();
                    }
                }
            }
        }
        public bool AfficheListeFichiersExistantsCibles()
        {
            Uti.Info("Persistance", "AfficheListeFichiersExistantsEC", "");
            int iResultat = 0;
            string sResultat = "";
            int i = 0;
            string[] tabCibles = new string[100];
            listeFichiersCibles = new List<string>();
            // récupération des chemins de dossiers contenant les fichiers de sauvegarde s'ils existent
            if (sTypeCMLongs == @"en-cours\" || sTypeCMLongs == @"resolus\")
            {
                if (PresenceDossier(sTypeCMLongs))
                {
                    // afficher les fichiers existants
                    Console.WriteLine("le fichier " + sTypeCMLongsLib + " existe");
                    //sauvegardeARestaurer = true;
                    tabCibles = Directory.GetFiles(sRacine + sDossSvg + sTypeCMLongs);
                }
                // ajout au tableau des titres de fichiers existants dans la liste concernée
                foreach (string sCheminFichier in tabCibles)
                {
                    if (sCheminFichier != "")
                    {
                        i++;
                        listeFichiersCibles.Add(sCheminFichier);
                    }
                }
                // affichage de la liste de fichiers
                Console.WriteLine(" Les carrés magiques " + sTypeCMLongsLib + ":");
                foreach (string sS in listeFichiersCibles)
                {
                    //Console.WriteLine(s);
                    iResultat = sS.LastIndexOf(@"\");
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = sS.Substring((iResultat + 1), (sS.Length - iResultat - 1));
                    // donne le nom du fichier seul
                    Console.WriteLine(sResultat);
                }
            }
            if (listeFichiersCibles.Count > 0)
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
            Uti.Info("Persistance", "OuvrirFichier", "");
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
            string[,] fragments = new string[persistanceGrille.INombre, persistanceGrille.INombre];
            Console.WriteLine(sCheminFichier);
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
            for (iL = iDepart; iL < (iDepart + persistanceGrille.INombre); iL++)
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
                            Console.WriteLine("case " + i + "." + j + " : " + iValeur);
                            // remplissage dans la grille
                            persistanceGrille.ChangeValeurCelluleGrille(i, j, iValeur);
                            j++;
                            if (j == persistanceGrille.INombre)
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
            //afficher le damier
            persistanceGrille.AffiDamier();
            Console.WriteLine();
        }
        public void OuvrirFichierJSON(string sCheminFichier)
        {
            Uti.Info("Persistance", "OuvrirFichier", "");
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
            Grille plop = new Grille();
            Console.WriteLine("Deserialization persistanceGrille--->" + persistanceGrille);
            plop.Damier = JsonConvert.DeserializeObject<Grille>(sGrilleJSON).Damier;
            foreach (Cellule cell in persistanceGrille.Damier)
            {
                cell.IValeur = plop.Damier[i, j].IValeur;
                j++;
                if (j == persistanceGrille.INombre)
                {
                    Console.WriteLine();
                    i++;
                    j = 0;
                }
            }
            //afficher le damier
            persistanceGrille.AffiDamier();
            Console.WriteLine();
        }
        public void ChoixFichierAOuvrir(Grille grille)
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
             * 1 : grille (Grille)
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
            string sChemin = sRacine + sDossSvg;
            if (Directory.Exists(sChemin + sTypeCMLongs + sNomFichier))
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
            persistanceGrille = new Grille();
            persistanceGrille.Construire(Grille.DeterminationTailleSansInstance());
            // initialisation 
            persistanceGrille.InitialisationDamier();
            // affichage
            if (sTypeCMCours == "ec")
            {
                cCarac = 'e';
                foreach (string sCheminFichier in listeFichiersCibles)
                {
                    iPosCaracAvPreLettNomFic = sCheminFichier.LastIndexOf(@"\");
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = sCheminFichier.Substring((iPosCaracAvPreLettNomFic + 1), (sCheminFichier.Length - iPosCaracAvPreLettNomFic - 1));
                    if (iPosCaracAvPreLettNomFic != iPrecedent)
                    {
                        iOrdre = listeFichiersCibles.IndexOf(sCheminFichier) + 1;
                        // si le fichier correspond à la valeur du carré magique, afficher le nom
                        // du fichier et le stocker dans la list
                        if (Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, cCarac, 1) == persistanceGrille.INombre.ToString())
                        {
                            listeFichiersRetenus.Add(sCheminFichier);
                        }
                    }
                }
            }
            else
            {
                cCarac = 'r';
                foreach (string sCheminFichier in listeFichiersCibles)
                {
                    iPosCaracAvPreLettNomFic = sCheminFichier.LastIndexOf(@"\");
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = sCheminFichier.Substring((iPosCaracAvPreLettNomFic + 1), (sCheminFichier.Length - iPosCaracAvPreLettNomFic - 1));
                    if (iPosCaracAvPreLettNomFic != iPrecedent)
                    {
                        //ordre++;
                        iOrdre = listeFichiersCibles.IndexOf(sCheminFichier) + 1;
                        // si le fichier correspond à la valeur du carré magique, afficher le nom
                        // du fichier et le stocker dans la list
                        if (Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, cCarac, 1) == persistanceGrille.INombre.ToString())
                        {
                            listeFichiersRetenus.Add(sCheminFichier);
                        }
                    }
                }
            }
            listeFichiersCibles = null;
            listeFichiersCibles = listeFichiersRetenus;
        }
        public void CreationFichierJSON(Grille PersistanceGrille, String s)
        {
            /*Fonction pour créer le fichier JSON et le remplir
             * les paramètres:
             *1 : grille à sauvegarer(Grille)
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
            string jsonSerializedObj = JsonConvert.SerializeObject(persistanceGrille);
            File.WriteAllText(s, jsonSerializedObj);
            Console.WriteLine(jsonSerializedObj);
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
            if (listeFichiersCibles.Count > 0)
            {
                propositionsCM = listeFichiersCibles.ToArray();
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
            TypeCarreMagique choix = TypeCarreMagique.ec;
            string sSaisie = "";
            int iSaisie = 0;
            // actualise les propriétés relatives au fichier en fonction de 
            //la saisie utilisateur
            while (iSaisie < 1 || iSaisie > 2)
            {
                Console.WriteLine("Choisisser la catégorie de fichier de carré magique à ouvrir:");
                Console.WriteLine("1. en cours");
                Console.WriteLine("2. résolus");
                sSaisie = Console.ReadLine();
                if (int.TryParse(sSaisie, out iSaisie))
                {
                    if (iSaisie < (int)TypeCarreMagique.ec || iSaisie > (int)TypeCarreMagique.r)
                    {
                        Console.WriteLine("La saisie doit être comprise entre " + (int)TypeCarreMagique.ec + " et " + (int)TypeCarreMagique.r);
                    }
                    else
                    {
                        if (iSaisie == 1)
                        {
                            choix = TypeCarreMagique.ec;
                            sTypeCMCours = "ec";
                            sTypeCMLongs = @"en-cours\";
                            sTypeCMLongsLib = "en cours";
                        }
                        else
                        {
                            choix = TypeCarreMagique.r;
                            sTypeCMCours = "r";
                            sTypeCMLongs = @"resolus\";
                            sTypeCMLongsLib = "résolus";
                        }

                        Console.WriteLine(sTypeCMLongs);

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
            string[] choixPossibles = listeFichiersCibles.ToArray();
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
                        fichierOuverture.TraitementChaine(sChaine);
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
