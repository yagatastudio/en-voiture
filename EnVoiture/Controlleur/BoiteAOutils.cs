using EnVoiture.Modele;
using EnVoiture.Vue;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnVoiture.Controlleur
{
    public class BoiteAOutils : TabControl
    {
        private TabPage OngletVoiture;
        private TabPage OngletRoute;
    
        public GenerateurWidget GenerateurWidget { get; private set; }
        public GenerateurVoitureWidget GenerateurVoitureWidget { get; private set; }

        public Route RouteSelectionnee
        {
            get
            {
                return GenerateurWidget.RouteWidget.Route;
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public BoiteAOutils()
        {
            InitializeComponent();
            GenerateurWidget = new GenerateurWidget(new Generateur());
            GenerateurVoitureWidget = new GenerateurVoitureWidget(new GenerateurVoiture(Properties.Resources.voiture_bleue));
            OngletRoute.Paint += new PaintEventHandler(OngletRoute_Paint);
            OngletVoiture.Paint += new PaintEventHandler(OngletVoiture_Paint);
            Paint += new PaintEventHandler((source, e) =>
            {
                GenerateurWidget.DessinerSurOrigine(e.Graphics);
                GenerateurVoitureWidget.DessinerSurBoite(e.Graphics);
            });
           /* MouseClick += new MouseEventHandler(this.RouteBouton_MouseClick);
            MouseClick += new MouseEventHandler(this.VoitureBouton_MouseClick);*/
        }

        protected void OngletRoute_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GenerateurWidget.DessinerSurOrigine(g);
        }

        protected void OngletVoiture_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GenerateurVoitureWidget.DessinerSurBoite(g);
        }

        private void ChangerRoute(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (GenerateurWidget.Detectcontenu(e.Location))
                {
                    GenerateurWidget.Generateur.EditionRoute(GenerateurWidget.DetectionOrientation(e.Location));
                }
                Invalidate();
            }
        }

        private void ChangerCouleurVoiture(object sender, MouseEventArgs e)
        {
            GenerateurVoitureWidget.GenerateurVoiture.ChangerVoiture();
            Invalidate();
        }

        /*private void VoitureBouton_MouseClick(object sender, MouseEventArgs e)
        {
            GenerateurVoitureWidget.GenerateurVoiture.ChangerVoiture();
        }

        private void RouteBouton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (GenerateurWidget.Detectcontenu(e.Location))
                {
                    GenerateurWidget.Generateur.EditionRoute(GenerateurWidget.DetectionOrientation(e.Location));
                }
                Invalidate();
            }
        }*/

        private void InitializeComponent()
        {
            this.OngletRoute = new System.Windows.Forms.TabPage();
            this.OngletVoiture = new System.Windows.Forms.TabPage();
            this.SuspendLayout();
            // 
            // OngletRoute
            // 
            this.OngletRoute.Location = new System.Drawing.Point(4, 22);
            this.OngletRoute.Name = "OngletRoute";
            this.OngletRoute.Size = new System.Drawing.Size(303, 168);
            this.OngletRoute.TabIndex = 0;
            this.OngletRoute.Text = "Route";
            this.OngletRoute.UseVisualStyleBackColor = true;
            this.OngletRoute.MouseClick += new MouseEventHandler(ChangerRoute);
            // 
            // OngletVoiture
            // 
            this.OngletVoiture.Location = new System.Drawing.Point(4, 22);
            this.OngletVoiture.Name = "OngletVoiture";
            this.OngletVoiture.Size = new System.Drawing.Size(303, 168);
            this.OngletVoiture.TabIndex = 1;
            this.OngletVoiture.Text = "Voiture";
            this.OngletVoiture.UseVisualStyleBackColor = true;
            this.OngletVoiture.MouseClick += new MouseEventHandler(ChangerCouleurVoiture);
            // 
            // BoiteAOutils
            // 
            this.Controls.Add(this.OngletRoute);
            this.Controls.Add(this.OngletVoiture);
            this.SelectedIndex = 0;
            this.Size = new System.Drawing.Size(311, 194);
            this.ResumeLayout(false);

        }
    }
}
