using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Chemin : Forme, IRotatable
    {
        public List<Point> Paths { get; private set; }

        public Chemin(int idElement, Color couleur, int ordre, params Point[] paths) : base(idElement, couleur, ordre)
        {
            this.Paths = new List<Point>(paths);

        }

        public void Rotation()
        {
            throw new NotImplementedException();
        }
    }
}
