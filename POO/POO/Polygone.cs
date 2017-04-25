using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Projet_POO
{
    internal class Polygone : Forme, IRotatable
    {
        public Polygone(int idElement, Color couleur, int ordre, params Point[] points)
            : base(idElement, couleur, ordre)
        {
            Points = new List<Point>(points);
        }

        public List<Point> Points { get; private set; }

        public void Rotation()
        {
            throw new NotImplementedException();
        }
    }
}