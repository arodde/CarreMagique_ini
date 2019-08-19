using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CarreMagique
{
    class Menu
    {
        private Grille grille;
        private Persistance persistance;
        public void DefinitionCarreMagique()
        {// les régles du jeu...
            Console.WriteLine("Règles du carré magique");
            Console.WriteLine("Ce jeu mathématique consiste à disposer dans une grille carré " +
                "les nombres en commençant par 1 et en incrémentant de 1. La plus forte valeur " +
                "est de n² pour un carré de n cases sur n. " +
                "Pour résoudre le carré magique il faut disposer les nombres dans la grille de " +
                "façon à ce que la somme des valeurs sur chaque colonne, sur chaque ligne et " +
                "sur chaque diagonale de n cases soient identiques.");
            Console.WriteLine("A vous de jouer!!!");

        }

        public void PréparationCarreMagique()
        {
            /* ***************************************************************
             +
             * Fonction pour créer une instance de menu qui va 
             *   - créer l'instance de persistance
             *   - créer la grille la persistance en paramètre
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
            Uti.Info("Menu", "PréparationCarreMagique", "");
            //// contenu de Main chargé dans le menu
            // persistance = new Persistance();
            // grille = new Grille();
            //// initialisation 
            //grille.InitialisationDamier();
            //if (grille.Nombre != 0)
            //{
            //    grille.SommeATrouver().ToString();
            //}
            //else
            //{
            //    Console.WriteLine("y a rien!!!");
            //}
            CreationCarreMagique();

            //// affichage du damier
            //grille.AffiDamier();

            //bool quitter = false;
            //int cpt = 0;
            //do
            //{
            //    grille.ProposerPermutation();
            //    if (grille.Gagne())
            //    {

            //        quitter = true;
            //    }
            //    else
            //    {
            //        // proposer sauvegarde et arrêt du jeu toutes les 4 permutations

            //        if (cpt == 3)
            //        {
            //            quitter = Uti.Quitter("");
            //            cpt = 0;
            //        }
            //    }
            //    cpt++;
            //} while (!quitter);
            //// proposer de sauvegarder si le joueur quitte le jeu en ayant ou non résolu le carré magique.
            //if (quitter)
            //{
            //    if (Uti.Action("sauvegarder", "Sauvegarde lancée.", "Perte du damier actuel", ""))
            //    {



            //        persistance.SauvegarderDansFichierTxt(grille);
            //    }
            //}
            grille.ManipulationCarreMagique();
        }
        public void CreationCarreMagique()
        {
            /* ***************************************************************
             +
             * Fonction pour créer le carré magique s'il n'existe pas
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
            Uti.Info("Menu", "CreationCarreMagique", "");
            // contenu de Main chargé dans le menu
            persistance = new Persistance();
            grille = new Grille();
            // initialisation 
            grille.InitialisationDamier();
            if (grille.Nombre != 0)
            {
                grille.SommeATrouver().ToString();
            }
            else
            {
                Console.WriteLine("y a rien!!!");
            }
        }



        public void CarreMagiqueEnMemoire()
        {
            /* ***************************************************************
            +
            * Fonction pour aller chercher le contenu d'un fichier en mémoire s'il existe
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
            Uti.Info("Menu", "CarreMagiqueEnMemoire", "");

            /*
             *  consulter le dossier de sauvegarde et le fichier de 
             *  sauvegarde si dossier n'existe pas le créer sinon 
             *  aller dedans si aucun fichier alors dire aucun fichier
             *  sinon l'ouvrir lire le nombre créer le damier et le 
             *  remplir de chaque valeur rencontrée
             */
            Persistance persistance = new Persistance();
            string NomFichier = persistance.RetourneAdresseDossierSvg();
            Uti.Mess("affichage de tous les fichiers confondus");
            persistance.AfficheListeFichiersExistants();
            // lancer les permutations
            this.persistance = persistance;
            this.grille = persistance.GrillePersistance;
            this.grille.Persistance = this.persistance;
            this.grille.ManipulationCarreMagique();
        }
        public void MenuJeu()
        {
            /* ***************************************************************
            +
            * Fonction pour afficher les options disponibles au menu
            * - afficher les règles du jeu
            * - créer un carré magique de la taille souhaitée et le résoudre
            * - charger un carré magique en cours de résolution depuis un fichier
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
            /* ***************************************************************
            +
            * Fonction pour permettre au programme de vérifier la saisie utilisateur 
            * et le diriger si elle est correcte vers le bon embranchement de switch
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
                        PréparationCarreMagique();
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

