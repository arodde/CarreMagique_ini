using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CarreMagique
{
    class Menu
    {
        public void DefinitionCarreMagique()
        {
            Console.WriteLine("Règles du carré magique");
            Console.WriteLine("Ce jeu mathématique consiste à disposer dans une grille carré " +
                "les nombres en commençant par 1 et en incrémentant de 1. La plus forte valeur " +
                "est de n² pour un carré de n cases sur n. " +
                "Pour résoudre le carré magique il faut disposer les nombres dans la grille de " +
                "façon à ce que la somme des valeurs sur chaque colonne, sur chaque ligne et " +
                "sur chaque diagonale de n cases soient identiques.");
            Console.WriteLine("A vous de jouer!!!");

        }

        public void NouveauCarreMagique()
        {
            Uti.Info("Menu", "NouveauCarreMagique", "");
            // contenu de Main chargé dans le menu
            Persistance persistance = new Persistance();
            Grille grille = new Grille(persistance);


            /*
             * Comment charger depuis la mémoire le fichier en cours?    
             * Quel objet créé avant le damier avec son constructeur 
             * qui définit sa taille?
             * Ou la persistance qui permet de sélectionner une sauvegarde
             * d'un damier d'une taille définie?
             */
            grille.AffiDamier();
            bool quitter = false;
            int cpt = 0;
            do
            {
                grille.ProposerPermutation();
                if (grille.Gagne())
                {
                    
                    quitter = true;
                }
                else
                {
                    // proposer sauvegarde et arrêt du jeu toutes les 4 permutations

                    if (cpt == 3)
                    {
                        quitter = Uti.Quitter("");
                        cpt = 0;
                    }
                }
                cpt++;
            } while (!quitter);
            // proposer de sauvegarder si le joueur quitte le jeu en ayant ou non résolu le carré magique.
            if (quitter)
            {
                if (Uti.Action("sauvegarder", "Sauvegarde lancée.", "Perte du damier actuel", ""))
                {
                    // l'objet persistance est implémenté à ce stade pour ne pas encombrer la mémoire
                    /*
                     * si la persistance au moyen d'un objet extérieur
                     * n'est pas concluante, les fonctions de la classe 
                     * seront réintégrées dans la classe qui a le damier
                     */

                    persistance.SauvegarderDansFichierTxt(grille);
                }
            }
        }
        public void CarreMagiqueEnMemoire()
        {
            Uti.Info("Menu", "CarreMagiqueEnMemoire", "");
            /*
             *  consulter le dossier de sauvegarde et le fichier de 
             *  sauvegarde si dossier n'existe pas le créer sinon 
             *  aller dedans si aucun fichier alors dire aucun fichier
             *  sinon l'ouvrir lire le nombre créer le damier et le 
             *  remplir de chaque valeur rencontrée
             */
            Persistance persistance = new Persistance();
            persistance.VerifExistenceSauvegarde();
        }
        public void MenuJeu()
        {
            Uti.Info("Menu", "MenuJeu", "");
            // mise en forme
            string sl = "\n";
            string tbl = "\t";
            // élaboration du menu
            string sMenu = "MENU" + sl + tbl;
            sMenu += "1. Règles du jeu le carré magique." + sl + tbl;
            sMenu += "2. Résoudre un nouveau Carré magique." + sl + tbl;
            sMenu += "3. Charger un carré magique en mémoire." + sl + tbl;
            // affichage menu
            Console.WriteLine(sMenu);
        }
        public void MethodesMenuJeu()
        {
            Uti.Info("Menu", "MethodesMenuJeu", "");
            //string sl = "\n";
            //string tbl = "\t";
            string sInput = "";
            // menu
            int iTheme = 0;
            int nbOptionMenu = 3;
            bool okSaisie = false;

            // charge le menu l'option choisie puis repropose le menu
            do
            {
                MenuJeu();
                while (!okSaisie)
                {

                    Console.WriteLine("Votre choix doit être compris entre 1 et " + nbOptionMenu + ".");
                    // récupération d'une chaine pour la convertir en entier
                    sInput = Console.ReadLine();
                    if (int.TryParse(sInput, out iTheme))
                    {
                        Console.WriteLine(iTheme);
                        if (iTheme < 1 || iTheme > nbOptionMenu)
                        {
                            okSaisie = false;
                        }
                        else
                        {
                            okSaisie = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Impossible " + sInput + " ne peut être converti en entier.\nVeuillez saisir un entier");
                    }

                }
                switch (iTheme) // à chaque thème déclaration des variables dans la portée suffisante pour éviter les variables globales
                {
                    case 1:
                        DefinitionCarreMagique();
                        break;
                    case 2:
                        NouveauCarreMagique();
                        break;
                    case 3:
                        CarreMagiqueEnMemoire();
                        break;
                }
                okSaisie = false;
            } while (!(Uti.Quitter("")));

        }
    }
}

