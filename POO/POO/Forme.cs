using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    abstract class Forme
    {
        public int IdElement { get; private set; }
        public Color Couleur { get; private set; }
        public int Ordre { get; private set; }

        protected Forme(int idElement, Color couleur, int ordre)
        {
            this.IdElement = idElement;
            this.Couleur = couleur;
            this.Ordre = ordre; 
        }

    }
}
