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
            dossSvg =  @"svg\";

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
                Directory.CreateDirectory(racine+ dossSvg);
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
                        // remplir avec le damier le fichier 
                        try
                        {
                            // code provoquant une exception
                            for (int j = 0; j < grillePersistance.Nombre; j++)
                            {
                                for (int i = 0; i < grillePersistance.Nombre; i++)
                                {                                   
                                    // inscrire dans le fichier                                    
                                    sw.Write(grillePersistance.Damier[i, j].Valeur);
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
        public void VerifExistenceSauvegarde()
        {
            bool sauvegardeARestaurer = true;
            // tant que sauvegardeARestaurer est vrai

            while (sauvegardeARestaurer)
            {
                // dossier: test 
                string str = racine + dossSvg;
                if (!Directory.Exists(racine + dossSvg))
                {
                    sauvegardeARestaurer = false;
                    Console.WriteLine("Aucun dossier de sauvegarde à restaurer.");
                    //Console.WriteLine(racine + dossSvg);
                }
                else
                {
                    Console.WriteLine("fichier de sauvegarde trouvé.");
                    //Console.WriteLine(racine + dossSvg);

                    // dossier: resolu ou en-cours
                    // afficher les fichiers existants
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
            }


        }
    }
}
