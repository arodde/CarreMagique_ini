using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CarreMagique
{
    public class Persistance
    {
        // module pour sauvegarder dans un fichier le damier ou restituer un fichier dans le programme
        Grille grillePersistance;
        private string racine;
        private string dossSvg;
        private string typeFinalisationCarreMagique;
        enum typeCarreMagique
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
            /* un moyen de permettre à l'utilisateur de fournir une autre adresse de racine
            devra être prévu */
            racine = @"C:\Users\demon\source\CarreMagique\CarreMagique\test\";
            dossSvg = @"svg\";

        }
        public string RetourneAdresseDossierSvg()
        {
            return racine + dossSvg;
        }
        public void SauvegarderDansFichierTxt(Grille pGrille)
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
            Uti.Info("Persistance", "SauvegarderDansFichier", "");

            string dossParent = "";
            //bool ok = false;
            grillePersistance = pGrille;
            //accéder au dossier de sauvegarde svg
            //    s'il n'existe pas 
            //       le créer 

            if (!(Directory.Exists(racine + dossSvg)))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(racine + dossSvg);
            }

            //    si carre résolu
            //if (grillePersistance.Gagne())
            if (grillePersistance.CarreMagiqueResolu)
            {

                //        aller au dossier des solutions 
                //            s'il n'existe pas 
                //               le créer 
                dossParent = @"resolus\";
                dossSvg += dossParent;
                if (!Directory.Exists(dossSvg + dossParent))
                {
                    CreationFichierSauvegarde(dossSvg, dossParent);
                }





                Console.WriteLine("Sauvegarder l'état actuel du damier pour reprendre le jeu plus tard.");
            }
            else
            {
                //    sinon
                //        aller dans dossier des carrés en cours de résolutions
                //            s'il n'existe pas 
                //                le créer 

                dossParent += @"en-cours\";
                //dossSvg += dossParent;
                // prépare le nom du fichier de sauvegarde et crée le fichier de sauvegarde



                Console.WriteLine("Sauvegarder du carré magique résolu.");
            }
            // accéder au sous dossier 'resolus' ou 'en-cours'

            if (!Directory.Exists(racine + dossSvg + dossParent))
            {
                Console.WriteLine("Création du dossier de sauvegarde");
                Directory.CreateDirectory(racine + dossSvg + dossParent);
            }
            // créer le fichier de sauvegarde
            CreationFichierSauvegarde(racine + dossSvg, dossParent);
        }
        public void ChargerDepuisFichierTxt()
        {         /* ***************************************************************
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
            Uti.Info("Persistance", "ChargerDepuisFichier", "");
            Console.WriteLine("Souhaitez vous charger un carré magique sauvegarder?");
        }
        public void CreationFichierSauvegarde(string dossSvg, string dossParent)
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
            Uti.Info("Persistance", "CreationFichierSauvegarde", "");
            // prépare le nom du fichier de sauvegarde et crée le fichier de sauvegarde
            bool ok = false;
            int indice = 0;
            string tf = CategorieFichier(dossParent);
            string nomFichier = "";

            //        préparer nom fichier de sauvegarde : cm+grille.nombre+ec+n+.txt

            nomFichier = dossSvg + dossParent + "cm" + grillePersistance.Nombre + tf + indice + ".txt";//        si existe déja 
            ok = false;
            while (!ok)
            {
                if (File.Exists(nomFichier))
                {
                    //            ajouter incrémentation
                    indice++;
                    nomFichier = dossSvg + dossParent + "cm" + grillePersistance.Nombre + tf + indice + ".txt";


                    Console.WriteLine("incrémentation.");
                }
                else
                {
                    //        créer fichier
                    using (StreamWriter sw = File.CreateText(nomFichier))
                    {
                        sw.WriteLine(nomFichier);
                        sw.WriteLine();
                        sw.WriteLine("Carré magique de " + grillePersistance.Nombre);
                        sw.WriteLine("***");
                        sw.WriteLine(grillePersistance.SommeATrouver().ToString());
                        sw.WriteLine("***");
                        // remplir avec le damier le fichier 
                        try
                        {
                            // code provoquant une exception
                            for (int j = 0; j < grillePersistance.Nombre; j++)
                            {
                                for (int i = 0; i < grillePersistance.Nombre; i++)
                                {
                                    // inscrire dans le fichier                                    
                                    sw.Write(grillePersistance.Damier[i, j].Valeur + "-");
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
                    ok = true;
                    /////
                    //string path = @"C:\Users\demon\source\testouille\testouille\test\plop.txt";
                    //if (!File.Exists(path))
                    //{
                    //    // Create a file to write to.
                    //    using (StreamWriter sw = File.CreateText(path))
                    //    {
                    //        sw.WriteLine("Hello");
                    //        sw.WriteLine("And");
                    //        sw.WriteLine("Welcome");
                    //    }
                    //}
                    /////
                    Console.WriteLine(nomFichier);
                }
            }
        }
        public string CategorieFichier(string dossParent)
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
            if (dossParent == @"en-cours\")
            {
                return "ec";
            }
            else
            {
                return "r";
            }
        }
        public void CreerDossierALEmplacement(string chemin)
        {         /* ***************************************************************
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
            Uti.Info("Persistance", "CreerDossierALEmplacement", "");
            // crée un dossier à l'emplacement spécifier s'il n'existe pas, rien s'il existe déjà
            if (!Directory.Exists(chemin))
            {
                Directory.CreateDirectory(chemin);
                Console.WriteLine("Création dossier à l'emplacement " + chemin + ".");
            }
        }
        public void PresenceDossier(string nomDossier)
        {

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
            bool sauvegardeARestaurer = true;

            // tant que sauvegardeARestaurer est vrai

            //while (sauvegardeARestaurer)
            //{
            // dossier: test 
            string str = racine + dossSvg;
            int nResultat = 0;
            string sResultat = "";
            if (!Directory.Exists(racine + dossSvg))
            {
                sauvegardeARestaurer = false;
                Console.WriteLine("Aucun dossier de sauvegarde à restaurer.");
                //Console.WriteLine(racine + dossSvg);
            }
            else
            {
                Console.WriteLine("fichier de sauvegarde trouvé.");
                string[] tabec = new string[100];
                string[] tabr = new string[100];
                List<string> listeFichiersEC = new List<string>();
                List<string> listeFichiersR = new List<string>();
                int i = 0;
                // récupération des chemins de dossiers contenant les fichiers de 
                // sauvegarde s'ils existent
                if (Directory.Exists(racine + dossSvg + "en-cours"))
                {
                    // afficher les fichiers existants
                    Console.WriteLine("le fichier en-cours existe");
                    //sauvegardeARestaurer = true;
                    tabec = Directory.GetFiles(racine + dossSvg + "en-cours");
                }
                //else
                //{
                //    sauvegardeARestaurer = false;
                //}
                if (Directory.Exists(racine + dossSvg + "resolus"))
                {
                    // afficher les fichiers existants
                    Console.WriteLine("le fichier resolus existe");
                    //sauvegardeARestaurer = true;
                    tabr = Directory.GetFiles(racine + dossSvg + "resolus");
                }
                //else
                //{
                //    sauvegardeARestaurer = false;
                //}

                // ajout au tableau des titres de fichiers existants dans les listes 'en cours' et 'resolus'

                foreach (string s in tabec)
                {
                    if (s != "")
                    {
                        i++;
                        listeFichiersEC.Add("** " + i + " ** " + s);
                    }

                }


                foreach (string s in tabr)
                {

                    if (s != "")
                    {
                        i++;
                        listeFichiersR.Add("** " + i + " ** " + s);
                    }

                }
                // affichage de la liste de fichiers
                Console.WriteLine(" Les carrés magiques en cours :");
                foreach (string s in listeFichiersEC)
                {

                    //Console.WriteLine(s);
                    nResultat = s.LastIndexOf(@"\");
                    //Console.WriteLine("position de " + @"\" + " dans " + s+" est "+ nResultat.ToString());
                    // prélève la sous-chaine correspondant au non du dossier
                    sResultat = s.Substring((nResultat + 1), (s.Length - nResultat - 1));
                    // donne le nom du fichier seul
                    Console.WriteLine(sResultat);

                    // ouvrir le fichier
                    //OuvrirFichier(sResultat);
                }
                // affichage de la liste de fichiers
                Console.WriteLine(" Les carrés magiques résolus :");
                foreach (string s in listeFichiersR)
                {

                    //Console.WriteLine(s);
                    nResultat = s.LastIndexOf(@"\");
                    //Console.WriteLine("position de " + @"\" + " dans " + s+" est "+ nResultat.ToString());
                    // prélève la sous-chaine correspondant au non du dossier
                    sResultat = s.Substring((nResultat + 1), (s.Length - nResultat - 1));
                    // donne le nom du fichier seul
                    Console.WriteLine(sResultat);

                    //// ouvrir le fichier
                    //OuvrirFichier(sResultat);
                }


                //sauvegardeARestaurer = false;
                // saisir la taille du carré magique - le nombre après cm dans le fichier
                // saisir le numéro du fichier - le nombre après r ou ec dans le fichier
                // lire le fichier trouver les ***
                // collecter dans une chaine tout le damier
                // tant que la chaine n'est pas terminée
                //  décomposer la chaîne pour récupérer les souschaines de nombres et 
                //  la convertir en entier pour 
                //  la placer dans le damier
                // afficher le damier
                // jouer comme dans l'option 2 du menu avec ce damier
            }
            //}


        }
        public void OuvrirFichier(string nomFichier)
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

            // le fichier comprend seulement le nom du fichier.

            // récupérer la taille du carré magique

            // récupérer l'occurrence du carré magique


            //string resultat = "";
            Console.WriteLine("ouvrir fichiers de carrés magiques résolus ou en cours?");

            ChoixTypeFichier();
            string chemin = racine + dossSvg + typeFinalisationCarreMagique;
            Console.WriteLine(chemin);
            
            ChoixFichierAOuvrir();
        }

        public void ChoixFichierAOuvrir()
        {
            Uti.Info("Persistance", "ChoixFichierAOuvrir", "");
            /* ***************************************************************
                   OuvrirFichier

             * Fonction pour que l'utilisateur précise quelle fichier il veut 
             * ouvrir en spécitiant :
             *   - la taille du carré
             *   - la nature en-cours ou résolu du fichier
             *   - l'occurrence
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
            string nomFichier = "cm";
            Console.WriteLine("Tapez le nom du fichier");

            string chemin = racine + dossSvg;
            if (Directory.Exists(chemin + typeFinalisationCarreMagique + nomFichier))
            {
                // alors chercher le dossier
                Console.WriteLine("Ce dossier est trouvable.");
            }
            else
            {
                Console.WriteLine("Ce dossier est introuvable.");
            }
            ChoixTypeFichier();



        }
        public void ChoixTypeFichier()
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
            typeCarreMagique choix = typeCarreMagique.ec;
            string saisie = "";
            int nSaisie = 0;


            while (nSaisie < 1 || nSaisie > 2)
            {
                Console.WriteLine("Choisisser le fichier de carré magique à ouvrir:");
                Console.WriteLine("1. en cours");
                Console.WriteLine("2. résolu");
                saisie = Console.ReadLine();
                if (int.TryParse(saisie, out nSaisie))
                {
                    if (nSaisie < (int)typeCarreMagique.ec || nSaisie > (int)typeCarreMagique.r)
                    {
                        Console.WriteLine("La saisie doit être comprise entre " + (int)typeCarreMagique.ec + " et " + (int)typeCarreMagique.r);
                    }
                    else
                    {
                        if (nSaisie == 1)
                        {
                            choix = typeCarreMagique.ec;
                            typeFinalisationCarreMagique = @"en-cours\";
                        }
                        else
                        {
                            choix = typeCarreMagique.r;
                            typeFinalisationCarreMagique = @"resolus\";
                        }
                        typeFinalisationCarreMagique = choix.ToString();
                        Console.WriteLine(typeFinalisationCarreMagique);
                      
                    }

                }
                else
                {
                    Console.WriteLine("Cette saisie n'est pas un entier.");
                }
            }



        }
        public void Intru_ManipulationDeString()
        {
            Uti.Info("TestsDeveloppement", "ManipulationDeString", "");
            string alphabet = "abcdefghijklmnopqrsmnoptuvwxyz";
            string pasDeF = "abcdeghijklmnopqrstuvwxyz";
            string echantillon = "mnop";
            string echantillon2 = "smnop";
            string resultat = "";


            int nResultat = 0;
            bool bResultat = false;
            char[] monTabChar = new char[100];
            // retrait de la sous-chaîne depuis la position en paramètre p1 jusqu'à la fin de la chaîne
            Uti.Mess("SubString 1p");
            resultat = alphabet.Substring(10);
            Console.WriteLine(alphabet);
            Console.WriteLine(resultat);
            // retrait de la sous-chaîne depuis la position en p1 pour la quantité de caractères en p2
            Uti.Mess("SubString 2p");
            resultat = alphabet.Substring(3, 10);
            Console.WriteLine(alphabet);
            Console.WriteLine(resultat);
            // donne la position de la première occurence du caractère dans la chaine
            Uti.Mess("IndexOf");
            nResultat = alphabet.IndexOf("d");
            Console.WriteLine(nResultat.ToString());
            // trouver ou non un caractère
            Uti.Mess("Contains");
            bResultat = alphabet.Contains("f");
            if (bResultat)
            {
                Console.WriteLine("le caractère f est trouvé.");
            }
            else
            {
                Console.WriteLine("le caractère f n'est pas trouvé.");
            }
            bResultat = pasDeF.Contains("f");
            if (bResultat)
            {
                Console.WriteLine(" le caractère f est trouvé.");
            }
            else
            {
                Console.WriteLine("le caractère f n'est pas trouvé.");
            }
            // copier une sous-chaine dans un tableau de char
            Uti.Mess("CopyTo");
            alphabet.CopyTo(3, monTabChar, 4, 9);
            Console.Write("*");
            foreach (char c in monTabChar)
            {
                Console.Write(c + "-");
            }
            Console.WriteLine("*");
            Console.WriteLine(monTabChar);
            // insertion d'une chaine dans une autre
            Uti.Mess("Insert");
            resultat = alphabet.Insert(6, nResultat.ToString());
            Console.WriteLine(resultat);
            // donne l'index de position du tableau de char dans la chaîne
            Console.WriteLine(alphabet);
            nResultat = alphabet.IndexOfAny(echantillon.ToCharArray());
            Console.WriteLine(nResultat.ToString());
            // position de m dans la première occurence de mnop dans alphabet
            Uti.Mess("IndexOfAny");
            Console.WriteLine(alphabet);
            nResultat = alphabet.IndexOfAny(echantillon.ToCharArray());
            Console.WriteLine(nResultat.ToString() + " position de " + echantillon + " dans " + alphabet);
            // position de p dans la dernière occurence de mnop dans alphabet
            Uti.Mess("LastIndexOfAny");
            Console.WriteLine(alphabet);
            nResultat = alphabet.LastIndexOfAny(echantillon.ToCharArray());
            Console.WriteLine(nResultat.ToString() + " position de " + echantillon + " dans " + alphabet);
            string s1 = "cm4ec0.txt";
            char c1 = 'm';
            char c2 = 'e';
            string sr = Uti.ExtractionChainesEntreDeuxCaracteres(s1, c1, 1, c2, 1);
            Console.WriteLine(sr);
            c1 = 'c';
            c2 = '.';
            sr = Uti.ExtractionChainesEntreDeuxCaracteres(s1, c1, 2, c2, 1);
            Console.WriteLine(sr);
            Console.WriteLine();
            string sch = Uti.ExtractionChainesEntreDeuxCaracteres("salut \"coco\" t'aimes la banane?", '"', 1, '"', 2);
            Console.WriteLine(sch);
            Console.WriteLine();
            sch = Uti.ExtractionChainesEntreDeuxCaracteres("salut \"coco\" t'aimes la banane?", '\\', 2, '\\', 4);
            Console.WriteLine(sch);
            Console.WriteLine();
        }
        //

    }
}