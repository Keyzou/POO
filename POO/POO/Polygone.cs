using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace POO
{
    internal class Polygone : Forme, IRotatable
    {
        public Polygone(int idElement, Color couleur, int ordre, params Point[] points)
            : base(idElement, couleur, ordre)
        {
            Points = new List<Point>(points);
        }

        public List<Point> Points { get; private set; }

        public override string ToSVG()
        {
            var sb = new StringBuilder();
            sb.Append("<polygon points=\"");
            Points.ForEach(point => sb.Append(point.X+","+point.Y+" "));
            sb.Append("\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" "+TransformString+" />");
            return sb.ToString();
        }

        public void Rotation(double angle, int cx, int cy)
        {
            throw new NotImplementedException();
        }
    }
}