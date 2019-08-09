using System;

namespace CarreMagique
{
    public class Grille
    {
        private int nombre;
        private Cellule[,] damier;
        private int iteration;
        public int Nombre
        {
            get
            {
                return nombre;
            }
            private set
            {
                nombre = value;
            }
        }
        public Cellule[,] Damier
        {
            get
            {
                return damier;
            }
            private set
            {
                damier = value;
            }
        }
        private int[] totalParLignes; // somme des j
        private int[] totalParColonnes; // somme des i
        private int diagAsc;
        private int diagDesc;
        private Cellule cellule1;
        private Cellule cellule2;
        public int[] TotalParLignes { get => totalParLignes; set => totalParLignes = value; }
        public int[] TotalParColonnes { get => totalParColonnes; set => totalParColonnes = value; }
        public int DiagAsc { get => diagAsc; set => diagAsc = value; }
        public int DiagDesc { get => diagDesc; set => diagDesc = value; }
        public Cellule Cellule1 { get => cellule1; set => cellule1 = value; }
        public Cellule Cellule2 { get => cellule2; set => cellule2 = value; }
        public int Iteration { get => iteration; set => iteration = value; }
        internal Persistance Persistance { get => persistance; set => persistance = value; }
        public bool CarreMagiqueResolu { get => carreMagiqueResolu; set => carreMagiqueResolu = value; }

        private bool carreMagiqueResolu;
        private Persistance persistance;
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
            Uti.Info("DesTableaux", "T2dim", "");
            DeterminationTaille();

            Damier = new Cellule[Nombre, Nombre];


            InitialisationDamier();
            AffiDamier();

        }
        public Grille(Persistance pPersistance)
        {
            /* ***************************************************************
    +
    * Fonction pour créer la persistance suite à la création d'une grille à sauvegarder
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
            Uti.Info("Grille", "Grille", "1p");
            Persistance = new Persistance();
            Persistance = pPersistance;
            DeterminationTaille();
            CarreMagiqueResolu = false;
            // instanciations 
            Damier = new Cellule[Nombre, Nombre];
            TotalParColonnes = new int[nombre];
            TotalParLignes = new int[nombre];
            cellule1 = new Cellule();
            cellule2 = new Cellule();
            //// initialisation 
            //InitialisationDamier();

           
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
            DeterminationTaille();
            CarreMagiqueResolu = false;
            // instanciations 
            Damier = new Cellule[Nombre, Nombre];
            TotalParColonnes = new int[nombre];
            TotalParLignes = new int[nombre];
            cellule1 = new Cellule();
            cellule2 = new Cellule();
            // initialisation 
            InitialisationDamier();
        }
        public void InitialisationDamier()
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
            Uti.Info("Grille", "InitialisationDamier", "");

            // remplissage du tableau
            int i = 0;
            int j = 0;
            Cellule compteur = new Cellule();
            compteur.Valeur = 0;
            foreach (Cellule entier in Damier)
            {
                while (i < Nombre) // lignes
                {
                    while (j < Nombre) // colonnes
                    {
                        // mise à jour objet
                        compteur.Valeur++;
                        compteur.CoorHori = i;
                        compteur.CoorVerti = j;
                        // ajout cellule au damier 
                        // instanciation de la cellule du damier
                        Damier[i, j] = new Cellule();
                        // recopie de valeurs de la cellule compteur dans la cellule du damier
                        Damier[i, j].Valeur = compteur.Valeur;
                        Damier[i, j].CoorHori = compteur.CoorHori;
                        Damier[i, j].CoorVerti = compteur.CoorVerti;
                        j++;
                    }
                    // passage à une nouvelle ligne
                    if (j >= Nombre)
                    {

                        j = 0;
                    }
                    i++;
                }
            }
        }
        public void GestionEspaces(int valeur)
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
            //Uti.Info("Grille", "GestionEspaces", "");
            if (valeur < 10)
            {
                Console.Write("   " + valeur + " ");
            }
            else if (valeur < 100)
            {
                Console.Write("  " + valeur + " ");
            }
            else // < 1000
            {
                Console.Write(" " + valeur + " ");
            }
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
                saisie = "";
                valeur = 0;
                saisie = Console.ReadLine();
                if (int.TryParse(saisie, out valeur))
                {
                    //Console.WriteLine("conversion réussie : " + valeur);
                    if (valeur < 3)
                    {
                        saisieOK = false;
                        Console.WriteLine("le plus petit carré magique comprend 3 cases sur 3.");
                    }
                    else
                    {
                        saisieOK = true;
                        Nombre = valeur;
                    }
                }
                else
                {
                    Console.WriteLine("Conversion impossible.");
                }
            }
        }
        public void AffiDamier()
        {         /* ***************************************************************
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
            for (int i = 0; i < Nombre; i++)
            {

                // cellule damier
                EspaceAvant();
                for (int j = 0; j < Nombre; j++)
                {
                    GestionEspaces(Damier[i, j].Valeur);
                }
                EspaceAvant();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(TotalParLignes[i]);
                Console.ResetColor();
                Console.WriteLine();
            }

            AffiDiagAsc();
            AffiTotalColonnes();
            Console.WriteLine();
        }
        public void ProposerPermutation()
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
            Uti.Info("Grille", "ProposerPermutation", "");

            Console.WriteLine("Quelles valeurs de damier souhaitez-vous permuter?");
            //string saisie1 = Console.ReadLine();
            //string saisie2 = Console.ReadLine();
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
            Uti.Info("Grille", "SaisieValeurPossible", "");
            int valeur = 0;
            while (valeur < 1 || valeur > Nombre * Nombre)
            {
                string saisie = Console.ReadLine();
                //string chaine1 = Console.ReadLine();
                if (int.TryParse(saisie, out valeur))
                {
                    if (valeur < 0 || valeur > Nombre * Nombre)
                    {
                        Console.WriteLine("La valeur doit être comprise entre 1 et " + Nombre * Nombre);
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
        public void TrouverCellule(int SaisieJoueur1, int SaisieJoueur2)
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
            Uti.Info("Grille", "TrouverCellule", "");
            // Chercher une valeur du tableau
            int i = 0;
            int j = 0;
            bool okCell1 = false;
            bool okCell2 = false;
            Cellule compteur = new Cellule();
            compteur.Valeur = 0;
            foreach (Cellule entier in Damier)
            {
                while (i < Nombre) // lignes
                {
                    while (j < Nombre) // colonnes
                    {

                        // mise à jour objet
                        compteur.Valeur++;
                        compteur.CoorHori = i;
                        compteur.CoorVerti = j;

                        // ajout cellule au damier 

                        if (SaisieJoueur1 == Damier[i, j].Valeur || SaisieJoueur2 == Damier[i, j].Valeur)
                        {
                            if (SaisieJoueur1 == Damier[i, j].Valeur)
                            {
                                cellule1.Valeur = Damier[i, j].Valeur;
                                cellule1.CoorHori = Damier[i, j].CoorHori;
                                cellule1.CoorVerti = Damier[i, j].CoorVerti;
                                Console.WriteLine(Cellule1.ToString());
                                okCell1 = true;
                            }
                            else
                            {
                                cellule2.Valeur = Damier[i, j].Valeur;
                                cellule2.CoorHori = Damier[i, j].CoorHori;
                                cellule2.CoorVerti = Damier[i, j].CoorVerti;
                                Console.WriteLine(Cellule2.ToString());
                                okCell2 = true;
                            }
                        }

                        if (okCell1 == true)
                        {
                            if (okCell2 == true)
                            {
                                PermuterValeurCellules();

                                AffiDamier();
                                return;
                            }
                        }

                        j++;
                    }
                    // passage à une nouvelle ligne
                    if (j >= Nombre)
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
            transit.Valeur = Damier[cellule1.CoorHori, cellule1.CoorVerti].Valeur;

            // valeur2 dans damier vers valeur1 dans damier
            Damier[cellule1.CoorHori, cellule1.CoorVerti].Valeur = Damier[cellule2.CoorHori, cellule2.CoorVerti].Valeur;

            // transit vers valeur2 dans damier
            Damier[cellule2.CoorHori, cellule2.CoorVerti].Valeur = transit.Valeur;

            // rapport de situation
            //Uti.Sep("*", 40);
            //Console.WriteLine("transit\n : " + transit.ToString());
            //Uti.Sep(".", 40);
            //Console.WriteLine("cellule1\n : " + cellule1.ToString());
            //Uti.Sep("-", 40);
            //Console.WriteLine("Damier[cellule1.CoorHori, cellule1.CoorVerti]\n : " + Damier[cellule1.CoorHori, cellule1.CoorVerti].ToString());
            //Uti.Sep(".", 40);
            //Console.WriteLine("cellule2\n : " + cellule2.ToString());
            //Uti.Sep("-", 40);
            //Console.WriteLine("Damier[cellule2.CoorHori, cellule2.CoorVerti]\n : " + Damier[cellule2.CoorHori, cellule2.CoorVerti].ToString());
            //Uti.Sep("*", 40);
            //// reaffectation pour contrôle
            //cellule1.Valeur = Damier[cellule1.CoorHori, cellule1.CoorVerti].Valeur;
            //cellule2.Valeur = Damier[cellule2.CoorHori, cellule2.CoorVerti].Valeur;
            // contrôle
            //if (Damier[cellule1.CoorHori, cellule1.CoorVerti].Valeur == cellule1.Valeur)
            //{
            //    Console.WriteLine("la valeur 1 n'a pas permutée et reste : " + Damier[0, 0].Valeur + " de coordonnées : " + Damier[0, 0].CoorHori + " " + Damier[0, 0].CoorVerti);
            //}
            //else
            //{
            //    Console.WriteLine("la valeur 1 est devenue : " + Damier[0, 0].Valeur + " de coordonnées : " + Damier[0, 0].CoorHori + " " + Damier[0, 0].CoorVerti);
            //}
            //if (Damier[cellule2.CoorHori, cellule2.CoorVerti].Valeur == cellule2.Valeur)
            //{
            //    Console.WriteLine("la valeur 2 n'a pas permutée et reste : " + Damier[0, 1].Valeur + " de coordonnées : " + Damier[0, 1].CoorHori + " " + Damier[0, 1].CoorVerti);
            //}
            //else
            //{
            //    Console.WriteLine("la valeur 1 est devenue : " + Damier[0, 1].Valeur + " de coordonnées : " + Damier[0, 1].CoorHori + " " + Damier[0, 1].CoorVerti);
            //}

        }
        public void ProcederTotaux()
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
            Uti.Info("Grille", "ProcederTotaux", "");
            // appel des méthodes
            SommeColonnes();
            SommeLignes();
            SommeDiagAsc();
            SommeDiagDesc();
            // affichage
            //Console.WriteLine("Colonnes : ");
            //AffiTotalColonnes();
            //Console.WriteLine();
            //Console.WriteLine("Lignes : ");
            //AffiTotalLignes();
            //Console.WriteLine();
            //Console.WriteLine("Diagonales : ");
            //Console.WriteLine("DiagAsc : " + DiagAsc);
            //Console.WriteLine("DiagDesc : " + DiagDesc);
        }
        public void SommeColonne(int IndiceColonne)
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
            //Uti.Info("Grille", "SommeColonne", "");
            // somme des nombres d'une colonne            
            bool valeurOk = false;
            while (!valeurOk)
            {
                if (IndiceColonne < 0 || IndiceColonne >= nombre)
                {
                    valeurOk = false;
                    Uti.MessErr("Indice de colonne doit être compris entre 0 et nombre-1 inclus.");
                    Uti.Mess("Exception à implémenter?");
                }
                else
                {
                    valeurOk = true;
                    for (int i = 0; i < nombre; i++)
                    {
                        TotalParColonnes[IndiceColonne] += damier[i, IndiceColonne].Valeur;
                    }
                }
            }
        }
        public void SommeColonnes()
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
            // somme des nombres de chaque colonne et affectation du résultat dans le tableau totalColonne 
            Uti.Info("Grille", "SommeColonnes", "");
            int valeur = 0;

            for (int i = 0; i < nombre; i++)
            {
                SommeColonne(valeur);
                valeur++;
                //Uti.Mess("la colonne " + i + "est calculée.");
            }
        }
        public void SommeLigne(int IndiceLigne)
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
            //Uti.Info("Grille", "SommeLigne", "");
            // somme des nombres d'une ligne            
            bool valeurOk = false;
            while (!valeurOk)
            {
                if (IndiceLigne < 0 || IndiceLigne >= nombre)
                {
                    valeurOk = false;
                    Uti.MessErr("Indice de Ligne doit être compris entre 0 et nombre-1 inclus.");
                    Uti.Mess("Exception à implémenter?");
                }
                else
                {
                    valeurOk = true;
                    for (int i = 0; i < nombre; i++)
                    {
                        TotalParLignes[IndiceLigne] += damier[IndiceLigne, i].Valeur;
                    }
                }
            }
        }
        public void SommeLignes()
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
            // somme des nombres de chaque Ligne et affectation du résultat dans le tableau totalLigne 
            //Uti.Info("Grille", "SommeLignes", "");
            int valeur = 0;

            for (int i = 0; i < nombre; i++)
            {
                SommeLigne(valeur);
                valeur++;
                //Uti.Mess("la Ligne " + i + "est calculée.");
            }
        }
        public void SommeDiagDesc()
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
            // calcule la somme des valeur de la diagonale principale descendante
            int i = 0;
            int j = 0;
            while (i < nombre && j < nombre)
            {
                DiagDesc += Damier[i, j].Valeur;
                i++;
                j++;
            }
        }
        public void SommeDiagAsc()
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
            // calcule la somme des valeur de la diagonale principale ascendante
            int i = nombre - 1;
            int j = 0;
            while (i >= 0 && j < nombre)
            {
                DiagAsc += Damier[i, j].Valeur;
                i--;
                j++;
            }
        }
        public bool Gagne()
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
            Uti.Info("Grille", "Gagne", "");

            if (ControleTotaux())
            {
                Console.WriteLine("Bravo, vous avez résolu le carré magique de " + Nombre + ".");
                CarreMagiqueResolu = true;
                return true;
            }
            else
            {
                Console.WriteLine("Essayez encore.");
                return false;
            }
        }
        public bool ControleTotaux()
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
            // control des valeurs des tableaux
            if (totalParColonnes[0] == SommeATrouver()) /* si la première valeur du tableau ne donne 
                                                           rien ne correspond pas à la SommeATrouver()
                                                           alors inutile de continuer */
            {

                if (ValeursEgales(TotalParColonnes) && ValeursEgales(TotalParLignes))
                    if (TotalParColonnes[0] == TotalParLignes[0])
                        if (TotalParColonnes[0] == DiagAsc)
                            if (DiagAsc == DiagDesc)
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
            // contrôle que les valeurs du tableau en parmètres sont égales.
            int i = 0;
            bool ok = false;
            do
            {
                if (tab[i] != tab[i + 1])
                    return false;
                else
                    ok = true;
                i++;
            } while (i < (Nombre - 1));
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
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (int elt in totalParColonnes)
            {
                GestionEspaces(elt);
            }
            Console.ResetColor();
        }
        public void AffiTotalLignes()
        {
            /* ***************************************************************
    +
    * Fonction pour afficher le total des lignes dans une couleur déterminée
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
            foreach (int elt in totalParLignes)
            {
                GestionEspaces(elt);
            }
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
            TotalParColonnes = new int[nombre];
            TotalParLignes = new int[nombre];
            DiagAsc = 0;
            DiagDesc = 0;
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
            if (DiagAsc < 100)
                Console.Write("  " + DiagAsc + " ");
            else
                Console.Write(" " + DiagAsc + " ");
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
            if (DiagDesc < 100)
                Console.WriteLine("  " + DiagDesc + " ");
            else
                Console.WriteLine(" " + DiagDesc + " ");
            Console.ResetColor();
        }
        public void EspaceAvant()
        {
            // prend en compte la place occupée  par la colonne dévolue aux 
            // diagonales 5 caractères tant que Nombre² est inférieur à 1000
            Console.Write("     ");
        }
        public Cellule TrouverValeur(int valeurATrouver)
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
            if (valeurATrouver >= damier[0, 0].Valeur || valeurATrouver <= damier[(Nombre - 1), (Nombre - 1)].Valeur)
            {
                Console.WriteLine("damier[0,0].Valeur : " + damier[0, 0].Valeur + " damier[Nombre, Nombre].Valeur : " + damier[(Nombre - 1), (Nombre - 1)].Valeur);
                int i = 0;
                int j = 0;
                Cellule compteur = new Cellule();
                compteur.Valeur = 0;
                foreach (Cellule entier in Damier)
                {
                    while (i < Nombre) // lignes
                    {
                        while (j < Nombre) // colonnes
                        {

                            // mise à jour objet
                            compteur.Valeur++;
                            compteur.CoorHori = i;
                            compteur.CoorVerti = j;
                            // ajout cellule au damier 
                            //   instanciation de la cellule du damier
                            Damier[i, j] = new Cellule();
                            //   recopie de valeurs de la cellule compteur dans la cellule du damier
                            Damier[i, j].Valeur = compteur.Valeur;
                            Damier[i, j].CoorHori = compteur.CoorHori;
                            Damier[i, j].CoorVerti = compteur.CoorVerti;
                 
                            if (valeurATrouver == Damier[i, j].Valeur)
                            {
                                // si la valeur est trouvée elle est copiée dans le compteur
                                // avec les coordonnées dans le damier
                                compteur.Valeur = Damier[i, j].Valeur;
                                compteur.CoorHori = Damier[i, j].CoorHori;
                                compteur.CoorVerti = Damier[i, j].CoorVerti;
                                return compteur;
                            }
                            j++;
                        }
                        // passage à une nouvelle ligne
                        if (j >= Nombre)
                        {
                            j = 0;
                        }
                        i++;
                    }
                }
                return compteur; // ne semble servir à rien mais réclamé par l'IDE
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
            int nombreAtrouver = 0;
            // nombre divisé par deux donne un entier 
            nombreAtrouver = nombre / 2 * (1 + (nombre * nombre));
          
            if ((Nombre % 2) != 0)
            {// si nombre est impair               
                Console.WriteLine("impair");
                nombreAtrouver += ((nombre * nombre - 1) / 2) + 1;
            }
            //Console.WriteLine("nombre à trouver : " + nombreAtrouver);
            return nombreAtrouver;
        }
    }

}
