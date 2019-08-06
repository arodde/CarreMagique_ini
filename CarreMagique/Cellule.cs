using System;
using System.Collections.Generic;
using System.Text;

namespace CarreMagique
{
    public class Cellule
    {
        private int valeur;
        private int coorHori;
        private int coorVerti;
        public int Valeur
        {
            get
            {
                return valeur;
            }
            set
            {
                valeur = value;
            }
        }
        public int CoorHori
        {
            get
            {
                return coorHori;
            }
            set
            {
                coorHori = value;
            }
        }
        public int CoorVerti
        {
            get
            {
                return coorVerti;
            }
            set
            {
                coorVerti = value;
            }
        }
        public override bool Equals(object obj)
        {
            Cellule c = obj as Cellule;
            if (c == null)
                return false;
            return Valeur == c.Valeur && CoorHori == c.CoorHori && coorVerti == c.CoorVerti;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(valeur, coorHori, coorVerti, Valeur, CoorHori, CoorVerti);
        }

        public override string ToString()
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

            string description = "Valeur " + Valeur + " CoorHori " + CoorHori + " coorVerti " + CoorVerti;
            return description;
        }
    }
}
