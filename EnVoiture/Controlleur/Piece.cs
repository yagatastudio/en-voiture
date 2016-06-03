using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnVoiture.Controller;
using EnVoiture.Vue;

namespace EnVoiture.Controller
{
    /// <summary>
    /// Classe représentant une pièce (chunk) de 16x16
    /// </summary>
    public class Piece
    {
        private RouteWidget[] _routes = new RouteWidget[16*16];
        private Point _position;
        private EnVoiturePanel _panel;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="position"></param>
        public Piece(Point position, EnVoiturePanel panel)
        {
            this._position = position;
            this._panel = panel;
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
