using System;
using System.Collections.Generic;
using System.Text;

namespace CarreMagique
{
    public class Cellule
    {
        private int iValeur;
        private int iCoorHori;
        private int iCoorVerti;
        public int IValeur
        {
            get => iValeur;
            set => iValeur = value;
        }
        public int ICoorHori
        {
            get => iCoorHori;
            set => iCoorHori = value;
        }
        public int ICoorVerti
        {
            get => iCoorVerti;
            set => iCoorVerti = value;
        }
        public override bool Equals(object obj)
        {
            Cellule c = obj as Cellule;
            if (c == null)
                return false;
            return IValeur == c.IValeur && ICoorHori == c.ICoorHori && iCoorVerti == c.ICoorVerti;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(iValeur, iCoorHori, iCoorVerti, IValeur, ICoorHori, ICoorVerti);
        }

        public override string ToString()
        {
            /* ***************************************************************
        +
        * Fonction pour afficher les coordonnées et la valeur des cellules dans le damier
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

            string description = "Valeur " + IValeur + " CoorHori " + ICoorHori + " coorVerti " + ICoorVerti;
            return description;
        }
    }
}
