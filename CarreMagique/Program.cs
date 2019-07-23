using System;

namespace CarreMagique
{
    class Program
    {
        static void Main(string[] args)
        {
            Uti.Info("Program", "Main", "");
            //Grille grille = new Grille();
            //Persistance persistance =  new Persistance(Grille);

            ///*
            // * Comment charger depuis la mémoire le fichier en cours?    
            // * Quel objet créé avant le damier avec son constructeur 
            // * qui définit sa taille?
            // * Ou la persistance qui permet de sélectionner une sauvegarde
            // * d'un damier d'une taille définie?
            // */
            //Grille.AffiDamier();
            //bool quitter = false;
            //int cpt = 0;
            //do
            //{
            //    Grille.ProposerPermutation();
            //    if (Grille.Gagne())
            //    {
            //        quitter = true;
            //    }
            //    else
            //    {
            //        // proposer d'arrêter toutes les 4 permutations 
            //        if (cpt == 4)
            //        {

            //            quitter = Uti.Quitter("");

            //            cpt = 0;
            //        }
            //    }
            //    cpt++;
            //} while (!quitter);
            //// proposer de sauvegarder si le joueur quitte le jeu en ayant résolu le carré magique ou non.
            //if (quitter)
            //{
            //    if (Uti.Action("sauvegarder", "Sauvegarde lancée.", "Perte du damier actuel", ""))
            //    {
            //        // l'objet persistance est implémenté à ce stade pour ne pas encombrer la mémoire
            //        /*
            //         * si la persistance au moyen d'un objet extérieur
            //         * n'est pas concluante, les fonctions de la classe 
            //         * seront réintégrées dans la classe qui a le damier
            //         */

            //        persistance.SauvegarderDansFichier();
            //    }
            //}
            Menu menu = new Menu();
            menu.MethodesMenuJeu();
            Console.WriteLine();
        }
    }
}
