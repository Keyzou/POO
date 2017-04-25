using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Ellipse : Cercle, ITranslatable, IRotatable
    {
        public int RayonY { get; private set; }

        public Ellipse(int idElement, Color couleur, int ordre, int cx, int cy, int rx, int ry) : base(idElement, couleur, ordre, cx, cy, rx)
        {
            this.RayonY = ry;
        }

        public void Translation()
        {
            throw new NotImplementedException();
        }

        public void Rotation()
        {
            throw new NotImplementedException();
        }
    }
}
