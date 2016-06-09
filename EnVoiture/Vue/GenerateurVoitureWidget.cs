using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnVoiture.Modele;
using System.Drawing;

namespace EnVoiture.Vue
{
    public class GenerateurVoitureWidget
    {

        public GenerateurVoiture GenerateurVoiture { get; private set; }    

        public GenerateurVoitureWidget(GenerateurVoiture generateur)
        {
            this.GenerateurVoiture = generateur;
        }

        public void DessinerSurBoite(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(0, 100, 100, 100));
            g.DrawImage(GenerateurVoiture.VoitureImage, new Point(0, 100));

        }
    }
}
