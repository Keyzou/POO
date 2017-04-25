using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Cercle : Forme, ITranslatable
    {

        public Point Centre { get; private set; }
        public int Rayon { get; private set; }
        
        public Cercle(int idElement, Color couleur, int ordre, int cx, int cy, int r) : base(idElement, couleur, ordre)
        {
            Centre = new Point(cx, cy);
            Rayon = r;
        }

        public void Translation()
        {
            throw new NotImplementedException();
        }
    }
}
