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
        int iPosX = 45;
        int iPosY = 140;
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
            g.FillRectangle(Brushes.Black, new Rectangle(0, 100, 100, 100));
            g.DrawImage(GenerateurVoiture.VoitureImage, new Point(iPosX, iPosY));

        }
    }
}
