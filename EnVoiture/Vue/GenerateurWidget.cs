using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnVoiture.Modele;

namespace EnVoiture.Vue
{
   
  public class GenerateurWidget
    {
        const int HAUTEUR = 100;
        const int LARGEUR = 100;
        const int MARGEX = 0;
        const int MARGEY = 0;

        /// accesseurs du générateur 
        public Generateur Generateur { get; set; }

      /// <summary>
      /// permet de récuperer la route par le générateur
      /// </summary>
        public RouteWidget RouteWidget
        {
            get
            {
                return new RouteWidget(Generateur.Route);
            }
        }

      /// <summary>
      /// constructeur du GenerateurWidget qui prend en paramètre le générateur
      /// </summary>
      /// <param name="generateur"></param>
        public GenerateurWidget(Generateur generateur)
        {
            Generateur = generateur;
        }

        /// <summary>
        /// La fonction orientation permet de recevoir en paramètre un point et permet de le transformer en orientation.
        /// </summary>
        /// <param name="point"></param>
        public Orientation DetectionOrientation(Point point)
        {
            //fonctionne 
            int posGauche = point.X - MARGEX;
            int posHaut = point.Y - MARGEY;
            int posDroite = LARGEUR-point.X;
            int posBas = HAUTEUR-point.Y;
            int minX = Math.Min(posGauche, posDroite);
            int minY = Math.Min(posBas, posHaut);
            int min = Math.Min(minX, minY);
            if (min == posGauche)
            {
                return Orientation.OUEST;
            }
            else
            {
                if (min == posDroite)
                {
                    return Orientation.EST;
                }
                else
                {
                    if (min == posHaut)
                    {
                        return Orientation.NORD;
                    }
                    else
                    {
                        return Orientation.SUD;
                    }
                }
            }
        }

      /// <summary>
      /// Permet de dessinner le générateur sur la boite à outil
      /// </summary>
      /// <param name="g"></param>
        public void DessinerSurOrigine(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(MARGEX, MARGEY, HAUTEUR, LARGEUR));
            RouteWidget.DessinerSurOrigine(g);
        }

      /// <summary>
      /// Recupère le point du click et détecte la position du click
      /// </summary>
      /// <param name="point"></param>
      /// <returns></returns>
        public bool Detectcontenu(Point point)
        {
            return point.X <= MARGEX + LARGEUR && point.X >= MARGEX && point.Y <= MARGEY + HAUTEUR && point.Y >= MARGEY;
        }
    }
}
