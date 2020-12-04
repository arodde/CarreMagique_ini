using System;
using System.Collections.Generic;
using System.Text;

namespace MagicSquare
{
    public class Cell
    {
        public int value;
        public int horizontalPosition;
        public int verticalPosition;
        public override bool Equals(object obj)
        {
            Cell c = obj as Cell;
            if (c == null)
                return false;
            return value == c.value && horizontalPosition == c.horizontalPosition && verticalPosition == c.verticalPosition;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(value, horizontalPosition, verticalPosition, value, horizontalPosition, verticalPosition);
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

            string description = "Valeur " + value + " CoorHori " + horizontalPosition + " coorVerti " + verticalPosition;
            return description;
        }
    }
}
