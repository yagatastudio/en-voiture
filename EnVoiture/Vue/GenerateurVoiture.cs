using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnVoiture.Modele;
using System.Drawing;

namespace EnVoiture.Vue
{
    class GenerateurVoiture
    {
        const int HAUTEUR = 100;
        const int LARGEUR = 100;
        const int MARGEX = 0;
        const int MARGEY = 100;


        public VoitureWidget VoitureWidget { get; set; }

        public GenerateurVoiture(VoitureWidget voiturewidget) {
            this.VoitureWidget = voiturewidget;
        }

        public static void DessinerSurBoite(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(MARGEX, MARGEY, HAUTEUR, LARGEUR));
            VoitureWidget.DessinerSurBoite(g);
        
        }

    }
}
