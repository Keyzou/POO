using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Polygone : Forme, IRotatable
    {

        public List<Point> Points { get; private set; }

        public Polygone(int idElement, Color couleur, int ordre, params Point[] points) : base(idElement, couleur, ordre)
        {
            Points = new List<Point>(points);
        }

        public void Rotation()
        {
            throw new NotImplementedException();
        }
    }
}
