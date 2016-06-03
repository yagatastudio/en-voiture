using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnVoiture.Modele
{
    /// <summary>
    /// Classe représentant une pièce (chunk) de 16x16
    /// </summary>
    public class Piece
    {
        private Route[] _routes = new Route[16*16];
        private Point _position;

        public Piece(Point position)
        {
            _position = position;
        }

        /// <summary>
        /// Sauvegarde le paquet
        /// </summary>
        public void Sauvegarder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Charge un paquet
        /// </summary>
        /// <param name="position">La position du paquet</param>
        /// <returns>Le paquet à la position demandée</returns>
        public static Piece Charger(Point position)
        {
            throw new NotImplementedException();
        }
    }
}
