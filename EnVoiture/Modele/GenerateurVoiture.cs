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

        public Image VoitureImage { get; set; }

        public GenerateurVoiture()
        {
            this.VoitureImage = Properties.Resources.voiture_rouge;
        }
    }
}
