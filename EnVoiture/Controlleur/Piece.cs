using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

using EnVoiture.Controlleur;
using EnVoiture.Modele;
using EnVoiture.Vue;

namespace EnVoiture.Controlleur
{
    /// <summary>
    /// Classe représentant une pièce (chunk) de 16x16
    /// </summary>
    public class Piece
    {
        private const string VERSION = "0.13";

        private RouteWidget[] _routes = new RouteWidget[16*16];
        private Point _position;
        private EnVoiturePanel _panel;

        private string _chemin = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\EnVoiture";
        private string _cheminPiece;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="position"></param>
        public Piece(Point position, EnVoiturePanel panel)
        {
            this._position = position;
            this._panel = panel;
            this._cheminPiece = _chemin + string.Format("\\{0}-{1}.ev", _position.X, _position.Y);
            Charger();
        }

        /// <summary>
        /// Sauvegarde le paquet
        /// </summary>
        public void Sauvegarder()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(_cheminPiece, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, new Serialisableur(VERSION, _routes));
            stream.Close();
        }

        /// <summary>
        /// Charge un paquet
        /// </summary>
        /// <param name="position">La position du paquet</param>
        /// <returns>Le paquet à la position demandée</returns>
        public void Charger()
        {
            if (!Directory.Exists(_chemin))
                Directory.CreateDirectory(_chemin);
            if (File.Exists(_cheminPiece))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(_cheminPiece, FileMode.Open, FileAccess.Read, FileShare.Read);
                object o = formatter.Deserialize(stream);

                if (o is Serialisableur)
                {
                    Serialisableur s = o as Serialisableur;
                    if (s.Version == VERSION)
                    {
                        _routes = s.Routes;
                    }
                    else
                    {
                        MessageBox.Show("Les versions " + s.Version + " et " + VERSION + " sont incompatibles !");
                    }
                }
                stream.Close();
            }
            else
            {
                Sauvegarder();
                //Generer();
            }
        }

        /// <summary>
        /// Génère les routes.
        /// </summary>
        private void Generer()
        {
            //Sauvegarder();
            throw new NotImplementedException();
        }
    }
}
