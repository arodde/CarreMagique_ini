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
        private string typeCMLongs;
        private string typeCMCours;
        private string typeCMLongsLib;

        List<string> listeFichiersCibles;
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
                    /*
                     le contenu du fichier doit obéir à la structure suivante
                     ligne 1 : chemin du fichier lors sauvegarde
                     ligne 2 : "Carré magique de "
                     ligne 3 : grille.Nombre
                     ligne  : ***
                     ligne  : total à obtenir sur la résolution du carré magique
                     ligne  : ***
                     lignes suivantes  : les valeurs du carré magique par ligne. 
                     chaque valeur est suivi du tiret "-". Le tiret est directement 
                     suivi de la valeur suivante de la même ligne.
                     */
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
        public bool PresenceDossierSvg()
        {
            if (Directory.Exists(racine))
            {
                if (Directory.Exists(racine + dossSvg))
                    return true;
                else
                {
                    Console.WriteLine("Le dossier " + racine + " existe mais le dossier " + dossSvg + " est manquant.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool PresenceDossier(string nomDossier)
        {
            if (Directory.Exists(racine + dossSvg + nomDossier))
            {
                return true;
            }
            else
            {
                Console.WriteLine("le dossier " + nomDossier + " n'existe pas.");
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
            //bool sauvegardeARestaurer = true;

            // tant que sauvegardeARestaurer est vrai

            //while (sauvegardeARestaurer)
            //{
            // dossier: test 
            string str = racine + dossSvg;
            int nResultat = 0;
            string sResultat = "";
            string cheminFichier = "";
            //if (!Directory.Exists(racine + dossSvg))
            //{
            //    sauvegardeARestaurer = false;
            //    Console.WriteLine("Aucun dossier de sauvegarde à restaurer.");
            //    //Console.WriteLine(racine + dossSvg);
            //}
            //else
            //{
            if (!PresenceDossierSvg())
            {
                Console.WriteLine("Aucune sauvegarde à ce jour.");
            }
            else
            {
                Console.WriteLine("fichier de sauvegarde trouvé.");
                // -- -- --
                int i = 0;
                // choisi entre fichiers résolus ou en cours
                ChoixTypeFichier();
                // affiche les fichiers selon le choix réalisé
                AfficheListeFichiersExistantsCibles();
                // choix du numéro du carré magique
                SelectionCMSelonTaille();
                // limitation liste à des propostions pour une seule liste de fichiers de mêmes taille
                ChoixOccurrence();
                // choix de l'utilisateur
                cheminFichier = ChoixOccurrenceFichierTailleDeterminee();
                // ouverture du fichier
                OuvrirFichier(cheminFichier);
            }


            //}
            //}

        }
        public void AfficheListeFichiersExistantsCibles()
        {
            // -- -- --
            Uti.Info("Persistance", "AfficheListeFichiersExistantsEC", "");
            int nResultat = 0;
            string sResultat = "";
            int i = 0;
            string[] tabCibles = new string[100];
            listeFichiersCibles = new List<string>();
            // récupération des chemins de dossiers contenant les fichiers de sauvegarde s'ils existent
            if (typeCMLongs == @"en-cours\" || typeCMLongs == @"resolus\")
            {
                if (PresenceDossier(typeCMLongs))
                {
                    // afficher les fichiers existants
                    Console.WriteLine("le fichier " + typeCMLongsLib + " existe");
                    //sauvegardeARestaurer = true;
                    tabCibles = Directory.GetFiles(racine + dossSvg + typeCMLongs);
                }
                //else
                //{
                //    sauvegardeARestaurer = false;
                //}
                // ajout au tableau des titres de fichiers existants dans la liste concernée 


                foreach (string cheminFichier in tabCibles)
                {
                    if (cheminFichier != "")
                    {
                        i++;
                        listeFichiersCibles.Add(cheminFichier);
                    }
                }
                // affichage de la liste de fichiers
                Console.WriteLine(" Les carrés magiques " + typeCMLongsLib + ":");
                foreach (string s in listeFichiersCibles)
                {
                    //Console.WriteLine(s);
                    nResultat = s.LastIndexOf(@"\");
                    //Console.WriteLine("position de " + @"\" + " dans " + s+" est "+ nResultat.ToString());
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = s.Substring((nResultat + 1), (s.Length - nResultat - 1));
                    // donne le nom du fichier seul
                    Console.WriteLine(sResultat);
                }
            }
        }

        public void OuvrirFichier(string cheminFichier)
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

            List<string> listeContenuFichier = new List<string>();
            int compteurMarqueur = 0;
            int valeur = 0;

            string fragment = "";
            //string resultat = "";
            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int[] tab;
            int lecteur = 0;
            string ligne = "";
            string[] tabContenuFichier;
            Console.WriteLine(cheminFichier);


            // remplissage liste contenu fichier
            using (StreamReader sr = File.OpenText(cheminFichier))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    listeContenuFichier.Add(s);
                }
            }
            tabContenuFichier = listeContenuFichier.ToArray();
            /*
             convention liée à la structure du fichier
             ligne 1 d'indice l 0 de tabContenuFichier
             ligne 4 d'incice l 3 nombre 
             ligne 6 d'incice l 5 total à trouver
             ligne 8 d'incice l 7 début des valeurs du carré magique             
             */
            // affichage contenu fichier
            tab = new int[grillePersistance.Nombre * grillePersistance.Nombre];
            for (l = 0; l < tabContenuFichier.Length; l++)
            {
                if (l >= 7)
                {
                    ligne = tabContenuFichier[l];
                    // ligne à traiter pour extraire les valeurs
                    foreach (char caractere in ligne)
                    {
                        if (caractere != '-')
                        {
                            fragment += caractere;
                            // conversion du fragment en entier
                            if (int.TryParse(fragment, out valeur))
                            {
                                //tab[i, j] = valeur;
                                tab[k] = valeur;
                                Console.WriteLine("indice " + k + " valeur " + tab[k]);
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("impossible");
                            }
                        }
                        else
                        {
                            fragment = "";
                        }

                    }

                }
            }
            // charger depuis le tableau une dimension la grille du damier
            i = 0;
            j = 0;
            k = 0;           
            for (i = 0; i < grillePersistance.Nombre; i++)
            {
                for (j = 0; j < grillePersistance.Nombre; j++)
                {
                    grillePersistance.ChangeValeurCelluleGrille(i, j, tab[k]);
                    k++;
                }
            }   
            //afficher le damier
            grillePersistance.AffiDamier();
            Console.WriteLine();
            // comment jouer avec maintenant
        }

        public void ChoixFichierAOuvrir(Grille grille)
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
            string nomFichier = "";
            //Console.WriteLine("Tapez le nom du fichier");
            // fichier en-cours ou résolus?
            ChoixTypeFichier();
            // vérification que ce dossier existe ...
            string chemin = racine + dossSvg;
            if (Directory.Exists(chemin + typeCMLongs + nomFichier))
            {
                // alors chercher le dossier
                Console.WriteLine("Ce dossier est existe.");
            }
            else
            {
                Console.WriteLine("Ce dossier est introuvable.");
            }
            // affichage des fichiers de ce dossiers




        }
        public void InterrogeUtilisateurSurFichierAOuvrir(Grille pGrille)
        {
            /* ***************************************************************
                  OuvrirFichier

            * Fonction pour 
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
            Uti.Info("Persistance", "InterrogeUtilisateurSurFichierAOuvrir", "");
            //// choix entre fichier résolu et en cours
            //ChoixTypeFichier();
            // demander la taille du carré
            grillePersistance = pGrille;
            Uti.MessErr("grille toujours nulle?");
            grillePersistance.DeterminationTaille();

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
            char carac = ' ';
            string sResultat = "";
            int ordre = 0;
            int nResultat = 0;
            int precedent = 0;
            //int tailleDemandee = 0;
            //string chaine = "";
            List<string> listeFichiersRetenus = new List<string>();
            // demande taille pour carré magique

            // instanciation grille
            grillePersistance = new Grille(Grille.DeterminationTailleSansInstance());
            //grillePersistance.SaisieValeurPossible();
            //chaine = Console.ReadLine();


            // affichage
            if (typeCMCours == "ec")
            {
                carac = 'e';
                foreach (string nomFichier in listeFichiersCibles)
                {
                    nResultat = nomFichier.LastIndexOf(@"\");
                    //Console.WriteLine("position de " + @"\" + " dans " + s+" est "+ nResultat.ToString());
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = nomFichier.Substring((nResultat + 1), (nomFichier.Length - nResultat - 1));
                    if (nResultat != precedent)
                    {
                        //ordre++;
                        ordre = listeFichiersCibles.IndexOf(nomFichier) + 1;
                        // si le fichier correspond à la valeur du carré magique, afficher le nom
                        // du fichier et le stocker dans la list
                        if (Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, carac, 1) == grillePersistance.Nombre.ToString())
                        {
                            //Console.WriteLine(" " + ordre + " " + Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, carac, 1));
                            listeFichiersRetenus.Add(nomFichier);
                        }
                    }
                }
            }
            else
            {
                carac = 'r';
                foreach (string nomFichier in listeFichiersCibles)
                {
                    nResultat = nomFichier.LastIndexOf(@"\");
                    //Console.WriteLine("position de " + @"\" + " dans " + nomFichier +" est "+ nResultat.ToString());
                    // prélève la sous-chaine correspondant au nom du dossier
                    sResultat = nomFichier.Substring((nResultat + 1), (nomFichier.Length - nResultat - 1));
                    if (nResultat != precedent)
                    {
                        //ordre++;
                        ordre = listeFichiersCibles.IndexOf(nomFichier) + 1;
                        // si le fichier correspond à la valeur du carré magique, afficher le nom
                        // du fichier et le stocker dans la list
                        if (Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, carac, 1) == grillePersistance.Nombre.ToString())
                        {
                            //Console.WriteLine(" " + ordre + " " + Uti.ExtractionChainesEntreDeuxCaracteres(sResultat, 'm', 1, carac, 1));
                            listeFichiersRetenus.Add(nomFichier);
                        }
                    }
                }
            }
            listeFichiersCibles = null;
            listeFichiersCibles = listeFichiersRetenus;

        }
        public void ChoixOccurrence()
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
            int indice = 0;
            propositionsCM = listeFichiersCibles.ToArray();
            Console.WriteLine("les propositions:");
            foreach (string proposition in propositionsCM)
            {
                Console.WriteLine(indice + ". " + proposition);
                indice++;
            }

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
            TypeCarreMagique choix = TypeCarreMagique.ec;
            string saisie = "";
            int nSaisie = 0;


            while (nSaisie < 1 || nSaisie > 2)
            {
                Console.WriteLine("Choisisser le fichier de carré magique à ouvrir:");
                Console.WriteLine("1. en cours");
                Console.WriteLine("2. résolus");
                saisie = Console.ReadLine();
                if (int.TryParse(saisie, out nSaisie))
                {
                    if (nSaisie < (int)TypeCarreMagique.ec || nSaisie > (int)TypeCarreMagique.r)
                    {
                        Console.WriteLine("La saisie doit être comprise entre " + (int)TypeCarreMagique.ec + " et " + (int)TypeCarreMagique.r);
                    }
                    else
                    {
                        if (nSaisie == 1)
                        {
                            choix = TypeCarreMagique.ec;
                            typeCMCours = "ec";
                            typeCMLongs = @"en-cours\";
                            typeCMLongsLib = "en cours";
                        }
                        else
                        {
                            choix = TypeCarreMagique.r;
                            typeCMCours = "r";
                            typeCMLongs = @"resolus\";
                            typeCMLongsLib = "résolus";
                        }

                        Console.WriteLine(typeCMLongs);

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
            Uti.Info("TestsDeveloppement", "ChoixOccurrenceFichierTailleDetermine", "");
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
            string saisie = "";
            //int nSaisie = 0;
            int indice = 99;
            string chaine = "";
            int nResultat = 0;
            string sResultat = "";
            bool okIndice = false;
            // conversion liste en tableau
            string[] choixPossibles = listeFichiersCibles.ToArray();
            // demande le fichier à ouvrir jusqu'à avoir une proposition acceptable et l'ouvre
            // ouverture de fichier avec le chemin
            while (!okIndice)
            {
                Console.WriteLine("votre proposition?");
                saisie = Console.ReadLine();
                if (int.TryParse(saisie, out indice))
                {
                    // l'indicie d'occurrence commence à partir de 0
                    if (indice >= 0 && indice < choixPossibles.Length)
                    {
                        chaine = choixPossibles[indice];
                        //
                        nResultat = chaine.LastIndexOf(@"\");
                        //Console.WriteLine("position de " + @"\" + " dans " + s+" est "+ nResultat.ToString());
                        // prélève la sous-chaine correspondant au nom du dossier
                        sResultat = chaine.Substring((nResultat + 1), (chaine.Length - nResultat - 1));
                        Console.WriteLine(sResultat);
                        okIndice = true;
                    }
                }
                else
                {
                    Console.WriteLine("impossible");
                }
            }
            // retourne le chemin du fichier à ouvrir
            return chaine;
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