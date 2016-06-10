﻿using EnVoiture.Modele;
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
    public class BoiteAOutils : UserControl
    {
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
            Paint += new PaintEventHandler((source, e) =>
            {
                GenerateurWidget.DessinerSurOrigine(e.Graphics);
                GenerateurVoitureWidget.DessinerSurBoite(e.Graphics);
            });
            MouseClick += new MouseEventHandler(this.RouteBouton_MouseClick);
            MouseClick += new MouseEventHandler(this.VoitureBouton_MouseClick);
        }

        private void VoitureBouton_MouseClick(object sender, MouseEventArgs e)
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
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoiteAOutils
            // 
            this.AutoScroll = true;
            this.Name = "BoiteAOutils";
            this.Size = new System.Drawing.Size(311, 194);
            this.ResumeLayout(false);

        }
    }
}
