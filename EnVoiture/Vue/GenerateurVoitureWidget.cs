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
        const int TAILLEX = 100;
        const int TAILLEY = 100;
        int iPosX = 45;
        int iPosY = 35;
        List<VoitureWidget> Voitures = new List<VoitureWidget>();


        public GenerateurVoiture GenerateurVoiture { get; private set; }

        public GenerateurVoitureWidget(GenerateurVoiture generateur)
        {
            this.GenerateurVoiture = generateur;
            Voitures.Add(new VoitureWidget(GenerateurVoiture.Voiture));
        }

        /// <summary>
        /// permet de dessiner la voiture sur la boite à outil
        /// </summary>
        /// <param name="g"></param>
        public void DessinerSurBoite(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, TAILLEX, TAILLEY));
            g.DrawImage(GenerateurVoiture.VoitureImage, new Point(iPosX, iPosY));

        }
    }
}
