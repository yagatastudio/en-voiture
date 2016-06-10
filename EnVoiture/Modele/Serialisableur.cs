using EnVoiture.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnVoiture.Modele
{
    [Serializable]
    public class Serialisableur
    {
        public RouteWidget[] Routes { get; private set; }

        public string Version { get; private set; }

        public Serialisableur(string version, RouteWidget[] routes)
        {
            this.Version = version;
            this.Routes = routes;
        }
    }
}
