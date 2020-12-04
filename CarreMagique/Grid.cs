using System;

namespace MagicSquare
{
    public class Grid
    {
        public int numerous;
        public int iteration;
        public int ascendingDiagonal;
        public int downwardDiagonal;
        public int[] totalsByLines;
        public int[] totalsByColumns;
        public Cell cell1;
        public Cell cell2;
        public Cell[,] Checkerboard;
        public bool magicSquareSolved;
        public Persistence persistence;
   
    public void DinamicCreationTwoDimensionalArray()
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
            Uti.Info("Grid", "T2dim", "");
            SizeDetermination();
            Checkerboard = new Cell[numerous, numerous];
            CheckerboardInitialization();
            CheckboardDisplay();
        }
        public Grid(int size)
        {
            Uti.Info("Grid", "Grid", "");
            /* ***************************************************************
             +
             * Fonction pour créer la grille suite à la création d'une persistance pour charger une grille en mémoire
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
            //contenu déplacé dans dans Construction()           
        }
        public void build(int size)
        {
            /* ***************************************************************
             +
             * Fonction pour initialiser la création du damier de la grille et 
             * les tableaux de totaux et les diagonales
             * les paramètres:
             * 1 : iTaille pour avoir la dimension du damier (int)
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
            Uti.Info("Grid", "Grid", "");
            numerous = size;
            //DeterminationTaille();
            magicSquareSolved = false;
            // instanciations 
            Checkerboard = new Cell[numerous, numerous];
            totalsByColumns = new int[numerous];
            totalsByLines = new int[numerous];
            cell1 = new Cell();
            cell2 = new Cell();
            //// initialisation 
            //InitialisationDamier();
        }
        public void Build()
        {
            /* ***************************************************************
             +
             * Fonction pour initialiser la création du damier de la grille et 
             * les tableaux de totaux et les diagonales
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
            Uti.Info("Grid", "Grid", "");
            SizeDetermination();


            magicSquareSolved = false;
            // instanciations 
            Checkerboard = new Cell[numerous, numerous];
            totalsByColumns = new int[numerous];
            totalsByLines = new int[numerous];
            cell1 = new Cell();
            cell2 = new Cell();

        }
        public Grid()
        {
            Uti.Info("Grid", "Grid", "");
            /* ***************************************************************
             +
             * Fonction pour créer la grille suite à la création d'une persistance pour charger une grille en mémoire
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
            // ne fais plus rien depuis la mise en place du fichier json qui appel le constructeur

        }
        public void CheckerboardInitialization()
        {
            /* ***************************************************************
    +
    * Fonction pour remplir le damier de cellules instanciées. La première cellule 
    * a la valeur 1 et la dernière la valeur iNombre*iNombre
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
            Uti.Info("Grid", "InitialisationDamier", "");
            // remplissage du tableau
            int i = 0;
            int j = 0;
            Cell counter = new Cell();
            counter.value = 0;
            foreach (Cell integerNumber in Checkerboard)
            {
                while (i < numerous) // lignes
                {
                    while (j < numerous) // colonnes
                    {
                        // mise à jour objet
                        counter.value++;
                        counter.horizontalPosition = i;
                        counter.verticalPosition = j;
                        // ajout cellule au damier 
                        // instanciation de la cellule du damier
                        Checkerboard[i, j] = new Cell();
                        // recopie de valeurs de la cellule counter dans la cellule du damier
                        Checkerboard[i, j].value = counter.value;
                        Checkerboard[i, j].horizontalPosition = counter.horizontalPosition;
                        Checkerboard[i, j].verticalPosition = counter.verticalPosition;
                        j++;
                    }
                    // passage à une nouvelle ligne
                    if (j >= numerous)
                    {
                        j = 0;
                    }
                    i++;
                }
            }

        }
        public void ChangeGridCellValue(int i, int j, int value)
        {
            /* ***************************************************************
            +
            * Fonction pour modifier la valeur d'une cellule en fonction des coordonnées du damier
            * les paramètres:
            * 1 : i (int) numéro de ligne du damier
            * 2 : j (int) numéro de colonne du damier
            * 3 : valeur (int) valeur à stocker dans la cellule du damier
            * 4 : + (+)
            * 5 : + (+)
            * retour: + (+)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            //Uti.Info("Grid", "ChangeValeurCelluleGrille", "");            
            Checkerboard[i, j].value = value;
        }
        public void ManagmentOfEmptyCharacters(int value)
        {
            /* ***************************************************************
            +
            * Fonction pour introduire des espaces entre les valeurs du damier
            * sur une même ligne
            * les paramètres:
            * 1 : valeur maximale possible dans la grille (int)
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
            //Uti.Info("Grid", "GestionEspaces", "");
            if (value < 10)
            {
                Console.Write("   " + value + " ");
            }
            else if (value < 100)
            {
                Console.Write("  " + value + " ");
            }
            else // < 1000
            {
                Console.Write(" " + value + " ");
            }
        }
        public void ModifyNumber(int value)
        {         /* ***************************************************************
             +
             * Fonction pour modifier iNombre sans changer le caractère private du set de Nombre
             * les paramètres:
             * 1 : nouvelle valeur de iNombre (int)
             * 2 : + (+)
             * 3 : + (+)
             * 4 : + (+)
             * 5 : + (+)
             * retour: la valeur de iNombre (+)
             * exemple(s):
             * +
             * Ce qui est impossible:
             * +
            **************************************************************** */
            Uti.Info("Persistance", "ModifyNumber", "");
            numerous = value;
        }
        public static int DeterminationTailleSansInstance()
        {
            /* ***************************************************************
            +
            * Fonction pour déterminer la taille du carré magique qui va être instancié
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
            Uti.Info("Grid", "DeterminationTaille()", "");
            Console.WriteLine("Indiquez la taille du carré magique?");
            bool isValidEntry = false;
            string input = "";
            int value = 0;
            while (!isValidEntry)
            {
                value = 0;
                input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    if (value < 3)
                    {
                        isValidEntry = false;
                        Console.WriteLine("le plus petit carré magique comprend 3 cases sur 3.");
                    }
                    else
                    {
                        isValidEntry = true;
                        return value;
                    }
                }
                else
                {
                    Console.WriteLine("Conversion impossible.");
                }
            }
            return 0;
        }

        public void MagicSquareManipulation()
        {
            /* ***************************************************************
             +
             * Fonction pour opérer les permutations et résoudre le carré magique
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
            Uti.Info("Grid", "ManipulationCarreMagique", "");
            // affichage du damier            
            bool leave = false;
            int permutationThreshold = 4;
            int permutationToPerform = permutationThreshold;
            CheckboardDisplay();
            do
            {

                ProposesCheckedboardValueToSwap();
                if (IsWon())
                {
                    leave = true;
                }
                else
                {
                    // proposer sauvegarde et arrêt du jeu toutes les (seuilPermutation+1) permutations
                    if (permutationToPerform == 0)
                    {
                        leave = Uti.Quitter("");
                        permutationToPerform = permutationThreshold;
                    }
                }
                permutationToPerform--;
            } while (!leave);
            // proposer de sauvegarder si le joueur quitte le jeu en ayant ou non résolu le carré magique.

            persistence.SuggestSavingTheGrid(leave);
        }

        public void SizeDetermination()
        {
            /* ***************************************************************
            +
            * Fonction pour déterminer la taille du carré magique qui va être instancié
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
            Uti.Info("Grid", "DeterminationTaille()", "");
            Console.WriteLine("Indiquez la taille du carré magique?");
            bool saisieOK = false;
            string saisie = "";
            int valeur = 0;
            while (!saisieOK)
            {
                saisie = Console.ReadLine();
                if (int.TryParse(saisie, out valeur))
                {
                    if (valeur < 3)
                    {
                        saisieOK = false;
                        Console.WriteLine("le plus petit carré magique comprend 3 cases sur 3.");
                    }
                    else
                    {
                        saisieOK = true;
                        numerous = valeur;

                    }
                }
                else
                {
                    Console.WriteLine("Conversion impossible.");
                }
            }
        }
        public void CheckboardDisplay()
        {    /* ***************************************************************
             +
             * Fonction pour afficher le damier de taille grille.Nombre et les totaux 
             * des lignes, des colonnes et des diagonales
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
            Uti.Info("Grid", "AffiDamier", "");
            ResetsTotals();
            // réalisation des totaux
            ProcederTotaux();
            // affichage du tableau
            DescendingDiagonalDisplay();
            // ligne damier
            for (int i = 0; i < numerous; i++)
            {
                // cellule damier
                IsPresentASpaceBefore();
                for (int j = 0; j < numerous; j++)
                {
                    ManagmentOfEmptyCharacters(Checkerboard[i, j].value);
                }
                IsPresentASpaceBefore();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(totalsByLines[i]);
                Console.ResetColor();
                Console.WriteLine();
            }
            AscendingDiagonalDisplay();
            DisplayOfColumnTotals();
            Console.WriteLine();
        }
        public void ProposesCheckedboardValueToSwap()
        {
            /* ***************************************************************
            +
            * Fonction pour demander à l'utilisateur d'entrer les deux valeurs du damier à permuter
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
            Uti.Info("Grid", "ProposerPermutation", "");
            Console.WriteLine("Quelles valeurs de damier souhaitez-vous permuter?");
            Console.WriteLine("Saisissez la première valeur");
            int valeur1 = SaisieValeurPossible();
            Console.WriteLine("Saisissez la deuxième valeur");
            int valeur2 = SaisieValeurPossible();
            TrouverCellule(valeur1, valeur2);
        }
        public int SaisieValeurPossible()
        {
            /* ***************************************************************
            +
            * Fonction pour contrôler que la valeur saisie fait partie des valeurs 
            * admises dans le damier
            * les paramètres:
            * 1 : + (+)
            * 2 : + (+)
            * 3 : + (+)
            * 4 : + (+)
            * 5 : + (+)
            * retour: la valeur acceptable (int)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            Uti.Info("Grid", "SaisieValeurPossible", "");
            int valeur = 0;
            while (valeur < 1 || valeur > numerous * numerous)
            {
                string saisie = Console.ReadLine();
                if (int.TryParse(saisie, out valeur))
                {
                    if (valeur < 0 || valeur > numerous * numerous)
                    {
                        Console.WriteLine("La valeur doit être comprise entre 1 et " + numerous * numerous);
                    }
                    else
                    {
                        Console.WriteLine(valeur);
                    }
                }
                else
                {
                    Console.WriteLine("impossible");
                }
            }
            return valeur;
        }
        public void TrouverCellule(int iSaisieJoueur1, int iSaisieJoueur2)
        {
            /* ***************************************************************
            +
            * Fonction pour chercher les coordonnées respectives des valeurs 
            * à permuter
            * les paramètres:
            * 1 : saisie première valeur à permuter (int)
            * 2 : saisie deuxième valeur à permuter (int)
            * 3 : + (+)
            * 4 : + (+)
            * 5 : + (+)
            * retour: + (+)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            Uti.Info("Grid", "TrouverCellule", "");
            // Chercher une valeur du tableau
            int i = 0;
            int j = 0;
            bool bOkCell1 = false;
            bool bOkCell2 = false;
            Cell compteur = new Cell();
            compteur.value = 0;
            foreach (Cell entier in Checkerboard)
            {
                while (i < numerous) // lignes
                {
                    while (j < numerous) // colonnes
                    {
                        // mise à jour objet
                        compteur.value++;
                        compteur.horizontalPosition = i;
                        compteur.verticalPosition = j;
                        // ajout cellule au damier 
                        if (iSaisieJoueur1 == Checkerboard[i, j].value || iSaisieJoueur2 == Checkerboard[i, j].value)
                        {
                            if (iSaisieJoueur1 == Checkerboard[i, j].value)
                            {
                                cell1.value = Checkerboard[i, j].value;
                                cell1.horizontalPosition = Checkerboard[i, j].horizontalPosition;
                                cell1.verticalPosition = Checkerboard[i, j].verticalPosition;
                                Console.WriteLine(cell1.ToString());
                                bOkCell1 = true;
                            }
                            else
                            {
                                cell2.value = Checkerboard[i, j].value;
                                cell2.horizontalPosition = Checkerboard[i, j].horizontalPosition;
                                cell2.verticalPosition = Checkerboard[i, j].verticalPosition;
                                Console.WriteLine(cell2.ToString());
                                bOkCell2 = true;
                            }
                        }
                        if (bOkCell1 == true)
                        {
                            if (bOkCell2 == true)
                            {
                                PermuterValeurCellules();

                                CheckboardDisplay();
                                return;
                            }
                        }
                        j++;
                    }
                    // passage à une nouvelle ligne
                    if (j >= numerous)
                    {

                        j = 0;
                    }
                    i++;
                }
            }
        }
        public void PermuterValeurCellules()
        {
            /* ***************************************************************
            +
            * Fonction pour les valeurs de deux cellules du damier
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
              avec les valeurs de coordonnées récupérées dans les 
              cellules cellule1 et cellule2. les valeurs correspondantes
              peuvent êtres retrouvées et la permutation peut être faite
              uniquement sur les valeurs, les propriétés coorHori et coorVerti
              restent inchangées.
            */
            Uti.Info("Grid", "PermuterCellules", "");
            Cell transit = new Cell();
            // permutation de valeurs de cellules
            // valeur1 dans damier vers transit
            transit.value = Checkerboard[cell1.horizontalPosition, cell1.verticalPosition].value;
            // valeur2 dans damier vers valeur1 dans damier
            Checkerboard[cell1.horizontalPosition, cell1.verticalPosition].value = Checkerboard[cell2.horizontalPosition, cell2.verticalPosition].value;
            // transit vers valeur2 dans damier
            Checkerboard[cell2.horizontalPosition, cell2.verticalPosition].value = transit.value;
        }
        public void ProcederTotaux()
        {
            /* ***************************************************************
            +
            * Fonction pour vérifier après une permutation si le carré magique 
            * est résolu
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
            Uti.Info("Grid", "ProcederTotaux", "");
            // appel des méthodes pour effectuer les totaux
            SommeColonnes();
            SommeLignes();
            AscendingDiagonalSum();
            SommeDiagDesc();
        }
        public void SommeColonne(int iIndiceColonne)
        {
            /* ***************************************************************

            * Fonction pour effectuer la somme des sommes de valeurs d'une colonne
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
            //Uti.Info("Grid", "SommeColonne", "");
            bool bValeurOk = false;
            while (!bValeurOk)
            {
                if (iIndiceColonne < 0 || iIndiceColonne >= numerous)
                {
                    bValeurOk = false;
                    Uti.MessErr("Indice de colonne doit être compris entre 0 et nombre-1 inclus.");
                    //Uti.Mess("Exception à implémenter?");
                }
                else
                {
                    bValeurOk = true;
                    for (int i = 0; i < numerous; i++)
                    {
                        totalsByColumns[iIndiceColonne] += Checkerboard[i, iIndiceColonne].value;
                    }
                }
            }
        }
        public void SommeColonnes()
        {
            /* ***************************************************************
             +
             * Fonction pour effectuer la somme des nombres de chaque colonne
             * et affectation du résultat dans le tableau totalColonne                
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
            Uti.Info("Grid", "SommeColonnes", "");
            int iValeur = 0;

            for (int i = 0; i < numerous; i++)
            {
                SommeColonne(iValeur);
                iValeur++;
            }
        }
        public void SommeLigne(int iIndiceLigne)
        {
            /* ***************************************************************
            +
            * Fonction pour faire la somme des valeurs d'une ligne
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
            //Uti.Info("Grid", "SommeLigne", "");
            // somme des nombres d'une ligne            
            bool valeurOk = false;
            while (!valeurOk)
            {
                if (iIndiceLigne < 0 || iIndiceLigne >= numerous)
                {
                    valeurOk = false;
                    Uti.MessErr("Indice de Ligne doit être compris entre 0 et nombre-1 inclus.");
                    //Uti.Mess("Exception à implémenter?");
                }
                else
                {
                    valeurOk = true;
                    for (int i = 0; i < numerous; i++)
                    {
                        totalsByLines[iIndiceLigne] += Checkerboard[iIndiceLigne, i].value;
                    }
                }
            }
        }
        public void SommeLignes()
        {
            /* ***************************************************************
            +
            * Fonction pour somme des nombres de chaque Ligne et affectation du 
            * résultat dans le tableau totalLigne  la 
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

            //Uti.Info("Grid", "SommeLignes", "");
            int iValeur = 0;

            for (int i = 0; i < numerous; i++)
            {
                SommeLigne(iValeur);
                iValeur++;
            }
        }
        public void SommeDiagDesc()
        {
            /* ***************************************************************
            +
            * Fonction pour calculer la somme des valeur de la diagonale principale descendante
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
            int i = 0;
            int j = 0;
            while (i < numerous && j < numerous)
            {
                downwardDiagonal += Checkerboard[i, j].value;
                i++;
                j++;
            }
        }
        public void AscendingDiagonalSum()
        {
            /* ***************************************************************
            +
            * Fonction pour calculer la somme des valeur de la diagonale principale ascendante
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
            int i = numerous - 1;
            int j = 0;
            while (i >= 0 && j < numerous)
            {
                ascendingDiagonal += Checkerboard[i, j].value;
                i--;
                j++;
            }
        }
        public bool IsWon()
        {
            /* ***************************************************************
            +
            * Fonction pour féliciter le vainqueur ou l'inviter à poursuivre le jeu
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
            Uti.Info("Grid", "Gagne", "");
            if (TotalsControl())
            {
                Console.WriteLine("Bravo, vous avez résolu le carré magique de " + numerous + ".");
                magicSquareSolved = true;
                return true;
            }
            else
            {
                // perdu il faut décider si poursuite du jeu ou arrêt
                Console.WriteLine("A vous de décider:");
                return false;
            }
        }
        public bool TotalsControl()
        {
            /* ***************************************************************
            +
            * Fonction pour contrôler que les totaux sont identiques ce qui 
            * confirme la résolution du carré magique
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
            // control des valeurs des tableaux
            if (totalsByColumns[0] == SumToFind()) /* si la première valeur du tableau ne donne 
                                                           rien ne correspond pas à la SommeATrouver()
                                                           alors inutile de continuer */
            {

                if (AreEqualsValues(totalsByColumns) && AreEqualsValues(totalsByLines))
                    if (totalsByColumns[0] == totalsByLines[0])
                        if (totalsByColumns[0] == ascendingDiagonal)
                            if (ascendingDiagonal == downwardDiagonal)
                                return true;
                            else
                                return false;
                        else
                            return false;
                    else
                        return false;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public bool AreEqualsValues(int[] array)
        {
            /* ***************************************************************
            +
            * Fonction pour contrôler que les valeurs du tableau en parmètres sont égales
            * entre elles.
            * les paramètres:
            * 1 : tableau d'entiers à contrôler (int[])
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
            int i = 0;
            bool ok = false;
            do
            {
                if (array[i] != array[i + 1])
                    return false;
                else
                    ok = true;
                i++;
            } while (i < (numerous - 1));
            return ok;
        }
        public void DisplayOfColumnTotals()
        {
            /* ***************************************************************
            +
            * Fonction pour afficher le total des colonnes dans une couleur déterminée
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
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int iElt in totalsByColumns)
            {
                ManagmentOfEmptyCharacters(iElt);
            }
            Console.ResetColor();
        }

        public void ResetsTotals()
        {
            /* ***************************************************************
            +
            * Fonction pour raz des totaux de colonnes, lignes, et diagonales depuis 
            * la précédente modification du damier
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
            totalsByColumns = new int[numerous];
            totalsByLines = new int[numerous];
            ascendingDiagonal = 0;
            downwardDiagonal = 0;
        }
        public void AscendingDiagonalDisplay()
        {
            /* ***************************************************************
            +
            * Fonction pour la gestion des espaces selon la valeur du total de la 
            * diagonale ascendante
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (ascendingDiagonal < 100)
                Console.Write("  " + ascendingDiagonal + " ");
            else
                Console.Write(" " + ascendingDiagonal + " ");
            Console.ResetColor();
        }
        public void DescendingDiagonalDisplay()
        {
            /* ***************************************************************
            +
            * Fonction pour la gestion des espaces selon la valeur du total de la 
            * diagonale descendante
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (downwardDiagonal < 100)
                Console.WriteLine("  " + downwardDiagonal + " ");
            else
                Console.WriteLine(" " + downwardDiagonal + " ");
            Console.ResetColor();
        }
        public void IsPresentASpaceBefore()
        {
            // prend en compte la place occupée  par la colonne dévolue aux 
            // diagonales 5 caractères tant que Nombre² est inférieur à 1000
            Console.Write("     ");
        }
        public Cell FindValue(int valueToFind)
        {
            /* ***************************************************************
            +
            * Fonction pour trouver au sein du damier la cellule dont la valeur est celle en paramètre
            * les paramètres:
            * 1 : valeurATrouver : la valeur de la cellule à trouver (int)
            * 2 : + (+)
            * 3 : + (+)
            * 4 : + (+)
            * 5 : + (+)
            * retour: counter qui est chargée des coordonnées de la cellule de la grille avec la valeur cherchée  (cellule)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            //
            if (valueToFind >= Checkerboard[0, 0].value || valueToFind <= Checkerboard[(numerous - 1), (numerous - 1)].value)
            {
                Console.WriteLine("damier[0,0].Valeur : " + Checkerboard[0, 0].value + " damier[Nombre, Nombre].Valeur : " + Checkerboard[(numerous - 1), (numerous - 1)].value);
                int i = 0;
                int j = 0;
                Cell cell = new Cell();
                //cellule.value = 0;
                foreach (Cell cellZ in Checkerboard)
                {
                    while (i < numerous) // lignes
                    {
                        while (j < numerous) // colonnes
                        {

                            // mise à jour objet
                            cell.value++;
                            cell.horizontalPosition = i;
                            cell.verticalPosition = j;
                            // ajout cellule au damier 
                            //   instanciation de la cellule du damier
                            Checkerboard[i, j] = new Cell();
                            //   recopie de valeurs de la cellule counter dans la cellule du damier
                            Checkerboard[i, j].value = cell.value;
                            Checkerboard[i, j].horizontalPosition = cell.horizontalPosition;
                            Checkerboard[i, j].verticalPosition = cell.verticalPosition;
                            if (valueToFind == Checkerboard[i, j].value)
                            {
                                // si la valeur est trouvée elle est copiée dans le counter
                                // avec les coordonnées dans le damier
                                cell.value = Checkerboard[i, j].value;
                                cell.horizontalPosition = Checkerboard[i, j].horizontalPosition;
                                cell.verticalPosition = Checkerboard[i, j].verticalPosition;
                                return cell;
                            }
                            j++;
                        }
                        // passage à une nouvelle ligne
                        if (j >= numerous)
                        {
                            j = 0;
                        }
                        i++;
                    }
                }
                return cell; // ne semble servir à rien mais réclamé par l'IDE
            }
            else
            {
                return null;
            }
        }
        public int SumToFind()
        {
            /* ***************************************************************
            +
            * Fonction pour pour trouver la valeur de la somme du carré resolu
            * pour le carré magique
            * les paramètres:
            * 1 : + (+)
            * 2 : + (+)
            * 3 : + (+)
            * 4 : + (+)
            * 5 : + (+)
            * retour: la somme correcte du carré magique (int)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            Uti.Info("Grid", "SommeATrouver", "");
            // identifie la valeur de la somme à trouver sur les verticales, les horizontales et les grandes diagonales
            int numberToFind = 0;
            // iNombre divisé par deux donne un entier 
            numberToFind = numerous / 2 * (1 + (numerous * numerous));
            if ((numerous % 2) != 0)
            {// si iNombre est impair 
                numberToFind += ((numerous * numerous - 1) / 2) + 1;
            }
            return numberToFind;
        }
    }
}
