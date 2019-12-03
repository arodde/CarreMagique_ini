using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CarreMagique
{
    class Menu
    {
        private Grille menuGrille;
        private Persistance menuPersistance;
        enum optionMenu
        {
            PreparationCarreMagique = 2,
            CreationCarreMagique
        }
        public Menu()
        {
            menuPersistance = new Persistance();

        }
        public void DefinitionCarreMagique()
        {
            // les régles du jeu...
          

            Console.WriteLine("Règles du carré magique\n\n" +
                "Ce jeu mathématique consiste à disposer dans une grille carré.\n" +
                "Les nombres en commençant par 1 et en incrémentant de 1.\n" +
                "La plus forte valeur est de n² pour un carré de n cases sur n.\n" +
                "Pour résoudre le carré magique il faut disposer les nombres\n" +
                "dans la grille de façon à ce que la somme des valeurs sur\n" +
                "chaque colonne, sur chaque ligne et sur chaque diagonale\n" +
                "de n cases soient identiques.\n\n");
            Console.WriteLine("A vous de jouer!!!");

        }

        public void PreparationCarreMagique()
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
            CreationCarreMagique();
            // affichage du damier et résolution
            menuGrille.ManipulationCarreMagique();
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
            menuGrille = new Grille();
            menuGrille.Construire();
            // initialisation 
            menuGrille.InitialisationDamier();
            menuPersistance.PersistanceGrille = menuGrille;
            menuGrille.GrillePersistance = menuPersistance;
            if (menuGrille.INombre != 0)
            {
                menuGrille.SommeATrouver().ToString();
            }
            else
            {
                Console.WriteLine("Le damier de la grille ne peut pas être créé.");
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
             *  sinon l'ouvrir lire le iNombre créer le damier et le 
             *  remplir de chaque valeur rencontrée
             */
            menuPersistance.DefinirEmplacementDossierRacine();

            string NomFichier = menuPersistance.RetourneAdresseDossierSvg();
            Console.WriteLine("Choisissez une valeur de carré magique parmi ceux présentés.");
            menuPersistance.AfficheListeFichiersExistants();
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
            optionMenu choixDOption = 0;

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
                        menuPersistance.OptionMenu = (int)optionMenu.PreparationCarreMagique;
                        PreparationCarreMagique();

                        break;
                    case 3:
                        menuPersistance.OptionMenu = (int)optionMenu.CreationCarreMagique;
                        CarreMagiqueEnMemoire();
                        break;
                }
                if (menuPersistance != null)
                {
                    menuPersistance.Reinitialiser();
                }

                okSaisie = false;
            } while (!(Uti.Quitter(" CARRE MAGIQUE?")));
        }
    }
}

