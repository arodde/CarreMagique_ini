using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace MagicSquare
{
    class Menu
    {
        private Grid grid;
        private Persistence persistence;
        enum optionMenu
        {
            PreparationCarreMagique = 2,
            CreationCarreMagique
        }
        public Menu()
        {
            persistence = new Persistence();

        }
        public void givesMagicSquareDefinition()
        {
            // les règles du jeu...


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

        public void MagicSquarePreparation()
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
            MagicSquareCreation();
            // affichage du damier et résolution
            grid.MagicSquareManipulation();
        }
        public void MagicSquareCreation()
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
            grid = new Grid();
            grid.Build();
            // initialisation 
            grid.CheckerboardInitialization();
            persistence.grid = grid;
            grid.persistence = persistence;
            if (grid.numerous != 0)
            {
                grid.SumToFind().ToString();
            }
            else
            {
                Console.WriteLine("Le damier de la grille ne peut pas être créé.");
            }
        }



        public void MagicSquareInMemory()
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
            persistence.SetRootFolderLocation();

            string NomFichier = persistence.returnsAddressBackUpFolder();
            Console.WriteLine("Choisissez une valeur de carré magique parmi ceux présentés.");
            persistence.DisplayListOfExistingFiles();
        }
        public void GameMenu()
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
            string lienBreak = "\n";
            string tabulation = "\t";
            // élaboration du menu
            string menu = "MENU" + lienBreak + tabulation;
            menu += "1. Règles du jeu le carré magique." + lienBreak + tabulation;
            menu += "2. Résoudre un nouveau Carré magique." + lienBreak + tabulation;
            menu += "3. Charger un carré magique en mémoire." + lienBreak + tabulation;
            // affichage menu
            Console.WriteLine(menu);
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
            int numberOfOptionsAvailable = 3;
            optionMenu chosenOption = 0;

            bool isCorrectInput = false;

            // charge le menu l'option choisie puis repropose le menu
            do
            {

                GameMenu();
                while (!isCorrectInput)
                {
                    Console.WriteLine("Votre choix doit être compris entre 1 et " + numberOfOptionsAvailable + ".");
                    // récupération d'une chaine pour la convertir en entier
                    sInput = Console.ReadLine();
                    if (int.TryParse(sInput, out iTheme))
                    {
                        Console.WriteLine(iTheme);
                        if (iTheme < 1 || iTheme > numberOfOptionsAvailable)
                        {
                            isCorrectInput = false;
                        }
                        else
                        {
                            isCorrectInput = true;
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
                        givesMagicSquareDefinition();
                        break;
                    case 2:
                        persistence.selectedMenuOption = (int)optionMenu.PreparationCarreMagique;
                        MagicSquarePreparation();

                        break;
                    case 3:
                        persistence.selectedMenuOption = (int)optionMenu.CreationCarreMagique;
                        MagicSquareInMemory();
                        break;
                }
                if (persistence != null)
                {
                    persistence.Reset();
                }

                isCorrectInput = false;
            } while (!(Uti.Quitter(" CARRE MAGIQUE?")));
        }
    }
}

