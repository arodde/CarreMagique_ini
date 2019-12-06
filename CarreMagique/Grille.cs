using System;

namespace CarreMagique
{
    public class Grille
    {
        private int iNombre;
        private int iIteration;
        private int iDiagAsc;
        private int iDiagDesc;
        private int[] totalParLignes; // somme des j
        private int[] totalParColonnes; // somme des i
        private Cellule cellule1;
        private Cellule cellule2;
        private Cellule[,] damier;
        private bool bCarreMagiqueResolu;
        private Persistance grillePersistance;
        public int INombre
        {
            get => iNombre;
            private set
            {
              //  Console.WriteLine("nombre est actualisé à " + value);
                iNombre = value;
            }
        }
        public int IIteration { get => iIteration; set => iIteration = value; }
        public int IDiagAsc { get => iDiagAsc; set => iDiagAsc = value; }
        public int IDiagDesc { get => iDiagDesc; set => iDiagDesc = value; }
        public int[] TotalParLignes { get => totalParLignes; set => totalParLignes = value; }
        public int[] TotalParColonnes { get => totalParColonnes; set => totalParColonnes = value; }
        public bool BCarreMagiqueResolu { get => bCarreMagiqueResolu; set => bCarreMagiqueResolu = value; }
        public Cellule[,] Damier
        {
            get => damier;
             set => damier = value;
        }
        public Cellule Cellule1 { get => cellule1; set => cellule1 = value; }
        public Cellule Cellule2 { get => cellule2; set => cellule2 = value; }
        internal Persistance GrillePersistance { get => grillePersistance; set => grillePersistance = value; }

        public void T2dimDyna()
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
            Uti.Info("Grille", "T2dim", "");
            DeterminationTaille();
            Damier = new Cellule[INombre, INombre];
            InitialisationDamier();
            AffiDamier();
        }
        public Grille(int iTaille)
        {
            Uti.Info("Grille", "Grille", "");
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
        public void Construire(int iTaille)
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
            Uti.Info("Grille", "Grille", "");
            INombre = iTaille;
            //DeterminationTaille();
            BCarreMagiqueResolu = false;
            // instanciations 
            Damier = new Cellule[INombre, INombre];
            TotalParColonnes = new int[iNombre];
            TotalParLignes = new int[iNombre];
            cellule1 = new Cellule();
            cellule2 = new Cellule();
            //// initialisation 
            //InitialisationDamier();
        }
        public void Construire()
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
            Uti.Info("Grille", "Grille", "");
            DeterminationTaille();

            BCarreMagiqueResolu = false;
            // instanciations 
            Damier = new Cellule[INombre, INombre];
            TotalParColonnes = new int[iNombre];
            TotalParLignes = new int[iNombre];
            cellule1 = new Cellule();
            cellule2 = new Cellule();
            
        }
        public Grille()
        {
            Uti.Info("Grille", "Grille", "");
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
        public void InitialisationDamier()
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
            Uti.Info("Grille", "InitialisationDamier", "");
            // remplissage du tableau
            int i = 0;
            int j = 0;
            Cellule compteur = new Cellule();
            compteur.IValeur = 0;
            foreach (Cellule entier in Damier)
            {
                while (i < INombre) // lignes
                {
                    while (j < INombre) // colonnes
                    {
                        // mise à jour objet
                        compteur.IValeur++;
                        compteur.ICoorHori = i;
                        compteur.ICoorVerti = j;
                        // ajout cellule au damier 
                        // instanciation de la cellule du damier
                        Damier[i, j] = new Cellule();
                        // recopie de valeurs de la cellule compteur dans la cellule du damier
                        Damier[i, j].IValeur = compteur.IValeur;
                        Damier[i, j].ICoorHori = compteur.ICoorHori;
                        Damier[i, j].ICoorVerti = compteur.ICoorVerti;
                        j++;
                    }
                    // passage à une nouvelle ligne
                    if (j >= INombre)
                    {
                        j = 0;
                    }
                    i++;
                }
            }
            
        }
        public void ChangeValeurCelluleGrille(int i, int j, int iValeur)
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
            //Uti.Info("Grille", "ChangeValeurCelluleGrille", "");            
            damier[i, j].IValeur = iValeur;
        }
        public void GestionEspaces(int iValeur)
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
            //Uti.Info("Grille", "GestionEspaces", "");
            if (iValeur < 10)
            {
                Console.Write("   " + iValeur + " ");
            }
            else if (iValeur < 100)
            {
                Console.Write("  " + iValeur + " ");
            }
            else // < 1000
            {
                Console.Write(" " + iValeur + " ");
            }
        }
        public void ModifierNombre(int iValeur)
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
            Uti.Info("Persistance", "ModifierNombre", "");
            INombre = iValeur;
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
            Uti.Info("Grille", "DeterminationTaille()", "");
            Console.WriteLine("Indiquez la taille du carré magique?");
            bool saisieOK = false;
            string saisie = "";
            int valeur = 0;
            while (!saisieOK)
            {
                valeur = 0;
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
                        return valeur;
                    }
                }
                else
                {
                    Console.WriteLine("Conversion impossible.");
                }
            }
            return 0;
        }

        public void ManipulationCarreMagique()
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
            Uti.Info("Grille", "ManipulationCarreMagique", "");
            // affichage du damier            
            bool bQuitter = false;
            int iSeuilPermutations = 4;
            int iPermutationsAEffectuer = iSeuilPermutations;
            AffiDamier();
            do
            {

                ProposerValeursDamierAPermuter();
                if (Gagne())
                {
                    bQuitter = true;
                }
                else
                {
                    // proposer sauvegarde et arrêt du jeu toutes les (seuilPermutation+1) permutations
                    if (iPermutationsAEffectuer == 0)
                    {
                        bQuitter = Uti.Quitter("");
                        iPermutationsAEffectuer = iSeuilPermutations;
                    }
                }
                iPermutationsAEffectuer--;
            } while (!bQuitter);
            // proposer de sauvegarder si le joueur quitte le jeu en ayant ou non résolu le carré magique.

            grillePersistance.ProposerSauvegarderGrille(bQuitter);
        }

        public void DeterminationTaille()
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
            Uti.Info("Grille", "DeterminationTaille()", "");
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
                        INombre = valeur;

                    }
                }
                else
                {
                    Console.WriteLine("Conversion impossible.");
                }
            }
        }
        public void AffiDamier()
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
            Uti.Info("Grille", "AffiDamier", "");
            ReinitialisationTotaux();
            // réalisation des totaux
            ProcederTotaux();
            // affichage du tableau
            AffiDiagDesc();
            // ligne damier
            for (int i = 0; i < INombre; i++)
            {
                // cellule damier
                EspaceAvant();
                for (int j = 0; j < INombre; j++)
                {
                    GestionEspaces(Damier[i, j].IValeur);
                }
                EspaceAvant();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(TotalParLignes[i]);
                Console.ResetColor();
                Console.WriteLine();
            }
            AffiDiagAsc();
            AffiTotalColonnes();
            Console.WriteLine();
        }
        public void ProposerValeursDamierAPermuter()
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
            Uti.Info("Grille", "ProposerPermutation", "");
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
            Uti.Info("Grille", "SaisieValeurPossible", "");
            int valeur = 0;
            while (valeur < 1 || valeur > INombre * INombre)
            {
                string saisie = Console.ReadLine();
                if (int.TryParse(saisie, out valeur))
                {
                    if (valeur < 0 || valeur > INombre * INombre)
                    {
                        Console.WriteLine("La valeur doit être comprise entre 1 et " + INombre * INombre);
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
            Uti.Info("Grille", "TrouverCellule", "");
            // Chercher une valeur du tableau
            int i = 0;
            int j = 0;
            bool bOkCell1 = false;
            bool bOkCell2 = false;
            Cellule compteur = new Cellule();
            compteur.IValeur = 0;
            foreach (Cellule entier in Damier)
            {
                while (i < INombre) // lignes
                {
                    while (j < INombre) // colonnes
                    {
                        // mise à jour objet
                        compteur.IValeur++;
                        compteur.ICoorHori = i;
                        compteur.ICoorVerti = j;
                        // ajout cellule au damier 
                        if (iSaisieJoueur1 == Damier[i, j].IValeur || iSaisieJoueur2 == Damier[i, j].IValeur)
                        {
                            if (iSaisieJoueur1 == Damier[i, j].IValeur)
                            {
                                cellule1.IValeur = Damier[i, j].IValeur;
                                cellule1.ICoorHori = Damier[i, j].ICoorHori;
                                cellule1.ICoorVerti = Damier[i, j].ICoorVerti;
                                Console.WriteLine(Cellule1.ToString());
                                bOkCell1 = true;
                            }
                            else
                            {
                                cellule2.IValeur = Damier[i, j].IValeur;
                                cellule2.ICoorHori = Damier[i, j].ICoorHori;
                                cellule2.ICoorVerti = Damier[i, j].ICoorVerti;
                                Console.WriteLine(Cellule2.ToString());
                                bOkCell2 = true;
                            }
                        }
                        if (bOkCell1 == true)
                        {
                            if (bOkCell2 == true)
                            {
                                PermuterValeurCellules();

                                AffiDamier();
                                return;
                            }
                        }
                        j++;
                    }
                    // passage à une nouvelle ligne
                    if (j >= INombre)
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
            Uti.Info("Grille", "PermuterCellules", "");
            Cellule transit = new Cellule();
            // permutation de valeurs de cellules
            // valeur1 dans damier vers transit
            transit.IValeur = Damier[cellule1.ICoorHori, cellule1.ICoorVerti].IValeur;
            // valeur2 dans damier vers valeur1 dans damier
            Damier[cellule1.ICoorHori, cellule1.ICoorVerti].IValeur = Damier[cellule2.ICoorHori, cellule2.ICoorVerti].IValeur;
            // transit vers valeur2 dans damier
            Damier[cellule2.ICoorHori, cellule2.ICoorVerti].IValeur = transit.IValeur;
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
            Uti.Info("Grille", "ProcederTotaux", "");
            // appel des méthodes pour effectuer les totaux
            SommeColonnes();
            SommeLignes();
            SommeDiagAsc();
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
            //Uti.Info("Grille", "SommeColonne", "");
            bool bValeurOk = false;
            while (!bValeurOk)
            {
                if (iIndiceColonne < 0 || iIndiceColonne >= iNombre)
                {
                    bValeurOk = false;
                    Uti.MessErr("Indice de colonne doit être compris entre 0 et nombre-1 inclus.");
                    //Uti.Mess("Exception à implémenter?");
                }
                else
                {
                    bValeurOk = true;
                    for (int i = 0; i < iNombre; i++)
                    {
                        TotalParColonnes[iIndiceColonne] += damier[i, iIndiceColonne].IValeur;
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
            Uti.Info("Grille", "SommeColonnes", "");
            int iValeur = 0;

            for (int i = 0; i < iNombre; i++)
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
            //Uti.Info("Grille", "SommeLigne", "");
            // somme des nombres d'une ligne            
            bool valeurOk = false;
            while (!valeurOk)
            {
                if (iIndiceLigne < 0 || iIndiceLigne >= iNombre)
                {
                    valeurOk = false;
                    Uti.MessErr("Indice de Ligne doit être compris entre 0 et nombre-1 inclus.");
                    //Uti.Mess("Exception à implémenter?");
                }
                else
                {
                    valeurOk = true;
                    for (int i = 0; i < iNombre; i++)
                    {
                        TotalParLignes[iIndiceLigne] += damier[iIndiceLigne, i].IValeur;
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

            //Uti.Info("Grille", "SommeLignes", "");
            int iValeur = 0;

            for (int i = 0; i < iNombre; i++)
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
            while (i < iNombre && j < iNombre)
            {
                IDiagDesc += Damier[i, j].IValeur;
                i++;
                j++;
            }
        }
        public void SommeDiagAsc()
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
            int i = iNombre - 1;
            int j = 0;
            while (i >= 0 && j < iNombre)
            {
                IDiagAsc += Damier[i, j].IValeur;
                i--;
                j++;
            }
        }
        public bool Gagne()
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
            Uti.Info("Grille", "Gagne", "");
            if (ControleTotaux())
            {
                Console.WriteLine("Bravo, vous avez résolu le carré magique de " + INombre + ".");
                BCarreMagiqueResolu = true;
                return true;
            }
            else
            {
                // perdu il faut décider si poursuite du jeu ou arrêt
                Console.WriteLine("A vous de décider:");
                return false;
            }
        }
        public bool ControleTotaux()
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
            if (totalParColonnes[0] == SommeATrouver()) /* si la première valeur du tableau ne donne 
                                                           rien ne correspond pas à la SommeATrouver()
                                                           alors inutile de continuer */
            {

                if (ValeursEgales(TotalParColonnes) && ValeursEgales(TotalParLignes))
                    if (TotalParColonnes[0] == TotalParLignes[0])
                        if (TotalParColonnes[0] == IDiagAsc)
                            if (IDiagAsc == IDiagDesc)
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
        public bool ValeursEgales(int[] tab)
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
                if (tab[i] != tab[i + 1])
                    return false;
                else
                    ok = true;
                i++;
            } while (i < (INombre - 1));
            return ok;
        }
        public void AffiTotalColonnes()
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
            foreach (int iElt in totalParColonnes)
            {
                GestionEspaces(iElt);
            }
            Console.ResetColor();
        }

        public void ReinitialisationTotaux()
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
            TotalParColonnes = new int[iNombre];
            TotalParLignes = new int[iNombre];
            IDiagAsc = 0;
            IDiagDesc = 0;
        }
        public void AffiDiagAsc()
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
            if (IDiagAsc < 100)
                Console.Write("  " + IDiagAsc + " ");
            else
                Console.Write(" " + IDiagAsc + " ");
            Console.ResetColor();
        }
        public void AffiDiagDesc()
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
            if (IDiagDesc < 100)
                Console.WriteLine("  " + IDiagDesc + " ");
            else
                Console.WriteLine(" " + IDiagDesc + " ");
            Console.ResetColor();
        }
        public void EspaceAvant()
        {
            // prend en compte la place occupée  par la colonne dévolue aux 
            // diagonales 5 caractères tant que Nombre² est inférieur à 1000
            Console.Write("     ");
        }
        public Cellule TrouverValeur(int iValeurATrouver)
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
            * retour: compteur qui est chargée des coordonnées de la cellule de la grille avec la valeur cherchée  (cellule)
            * exemple(s):
            * +
            * Ce qui est impossible:
            * +
           **************************************************************** */
            //
            if (iValeurATrouver >= damier[0, 0].IValeur || iValeurATrouver <= damier[(INombre - 1), (INombre - 1)].IValeur)
            {
                Console.WriteLine("damier[0,0].Valeur : " + damier[0, 0].IValeur + " damier[Nombre, Nombre].Valeur : " + damier[(INombre - 1), (INombre - 1)].IValeur);
                int i = 0;
                int j = 0;
                Cellule cellule = new Cellule();
                cellule.IValeur = 0;
                foreach (Cellule cell in Damier)
                {
                    while (i < INombre) // lignes
                    {
                        while (j < INombre) // colonnes
                        {

                            // mise à jour objet
                            cellule.IValeur++;
                            cellule.ICoorHori = i;
                            cellule.ICoorVerti = j;
                            // ajout cellule au damier 
                            //   instanciation de la cellule du damier
                            Damier[i, j] = new Cellule();
                            //   recopie de valeurs de la cellule compteur dans la cellule du damier
                            Damier[i, j].IValeur = cellule.IValeur;
                            Damier[i, j].ICoorHori = cellule.ICoorHori;
                            Damier[i, j].ICoorVerti = cellule.ICoorVerti;
                            if (iValeurATrouver == Damier[i, j].IValeur)
                            {
                                // si la valeur est trouvée elle est copiée dans le compteur
                                // avec les coordonnées dans le damier
                                cellule.IValeur = Damier[i, j].IValeur;
                                cellule.ICoorHori = Damier[i, j].ICoorHori;
                                cellule.ICoorVerti = Damier[i, j].ICoorVerti;
                                return cellule;
                            }
                            j++;
                        }
                        // passage à une nouvelle ligne
                        if (j >= INombre)
                        {
                            j = 0;
                        }
                        i++;
                    }
                }
                return cellule; // ne semble servir à rien mais réclamé par l'IDE
            }
            else
            {
                return null;
            }
        }
        public int SommeATrouver()
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
            Uti.Info("Grille", "SommeATrouver", "");
            // identifie la valeur de la somme à trouver sur les verticales, les horizontales et les grandes diagonales
            int iNombreAtrouver = 0;
            // iNombre divisé par deux donne un entier 
            iNombreAtrouver = iNombre / 2 * (1 + (iNombre * iNombre));
            if ((INombre % 2) != 0)
            {// si iNombre est impair 
                iNombreAtrouver += ((iNombre * iNombre - 1) / 2) + 1;
            }
            return iNombreAtrouver;
        }
    }
}
