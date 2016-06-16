using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EnVoiture.Modele;

namespace EnVoiture.Vue
{
   
    public class GenerateurVoiture
    {
        List<Bitmap> _textureChangeable = new List<Bitmap>();
        int IndexCouleur = 0;

        public Voiture Voiture { get; set; }
        public Image VoitureImage { get; set; }

        /// <summary>
        /// permet d'ajouter l'image de la voiture dans le generateur de voiture
        /// </summary>
        public GenerateurVoiture()
        {
            this.VoitureImage = Properties.Resources.voiture_rouge;
        }

        public GenerateurVoiture(Bitmap CouleurVoiture)
        {
            _textureChangeable.Add(Properties.Resources.voiture_bleue);
            _textureChangeable.Add(Properties.Resources.voiture_jaune);
            _textureChangeable.Add(Properties.Resources.voiture_rouge);
            _textureChangeable.Add(Properties.Resources.voiture_violette);
            this.VoitureImage = CouleurVoiture;
            IndexCouleur = 0;
        }

        public void ChangerVoiture()
        {
            if (IndexCouleur >= _textureChangeable.Count()-1)
            {
                IndexCouleur = 0;
                this.VoitureImage = _textureChangeable[IndexCouleur];
            }
            else
            {
                IndexCouleur++;
                this.VoitureImage = _textureChangeable[IndexCouleur];
            }
        }
        public Couleur getCouleur()
        {
            switch (IndexCouleur)
            {
                case 0:
                    return Couleur.BLEU;
                case 1:
                    return Couleur.JAUNE;
                case 2:
                    return Couleur.ROUGE;
                case 3:
                    return Couleur.VIOLET;
                default:
                    return Couleur.BLEU;
            }
        }
    }
}
