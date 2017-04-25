using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace POO
{
    internal class Chemin : Forme, IRotatable
    {
        public Chemin(int idElement, Color couleur, int ordre, params Point[] paths) : base(idElement, couleur, ordre)
        {
            Paths = new List<Point>(paths);
        }

        public List<Point> Paths { get; private set; }

        public void Rotation()
        {
            throw new NotImplementedException();
        }

        public override string ToSVG()
        {
            throw new NotImplementedException();
        }
    }
}