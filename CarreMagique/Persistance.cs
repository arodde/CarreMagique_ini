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

        public Persistance()
        {
            Uti.Info("Persistance", "Persistance", "");
            racine = @"C:\Users\demon\source\CarreMagique\CarreMagique\test\";
            dossSvg = @"svg\";

        }
        public void SauvegarderDansFichierTxt(Grille pGrille)
        {
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
                //dossSvg += dossParent;
                //               if (!Directory.Exists(dossSvg + dossParent))
                //               {
                //CreationFichierSauvegarde(dossSvg, dossParent);
                //               }





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
        {
            Uti.Info("Persistance", "ChargerDepuisFichier", "");
            Console.WriteLine("Souhaitez vous charger un carré magique sauvegarder?");
        }
        public void CreationFichierSauvegarde(string dossSvg, string dossParent)
        {
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
        {
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
        public string VerifExistenceSauvegarde()
        {
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
                //Console.WriteLine(racine + dossSvg);
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
                    OuvrirFichier(sResultat);
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

                    // ouvrir le fichier
                    OuvrirFichier(sResultat);
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
            return sResultat;

        }
        public void OuvrirFichier(string nomFichier)
        {
            Uti.Info("Persistance", "OuvrirFichier", "");
            /* ***************************************************************
                   OuvrirFichier

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

            //string resultat = "";
            int longueur = 0;
            int posiIndex = 0;
            if (posiIndex < nomFichier.Length)
            {
                // retrait de la sous-chaîne depuis la position en paramètre p1 jusqu'à la fin de la chaîne
                //Uti.Mess("SubString 1p");
                //resultat = nomFichier.Substring(18);
                Console.WriteLine(nomFichier);
                //Console.WriteLine(resultat);
            }
            else
            {
                Console.WriteLine("cette position dépasse la taille de la chaîne");
            }
            if (posiIndex < nomFichier.Length)
            {
                if (longueur <= (nomFichier.Length - posiIndex))
                {
                    // retrait de la sous-chaîne depuis la position en p1 pour la quantité de caractères en p2
                    //Uti.Mess("SubString 2p");
                    //resultat = nomFichier.Substring(3, 18);
                    Console.WriteLine(nomFichier);
                    //Console.WriteLine(resultat);
                }
                else
                {
                    Console.WriteLine("la sous chaine va au-delà de la fin de la chaîne principale");
                }
            }
            else
            {
                Console.WriteLine("cette position dépasse la taille de la chaîne");
            }


        }
        public void ManipulationDeString()
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