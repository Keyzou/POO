using System;
using System.Collections;
using System.Windows.Media;

namespace POO
{
    internal abstract class Forme : IComparable<Forme>
    {
        protected Forme(int idElement, Color couleur, int ordre)
        {
            IdElement = idElement;
            Couleur = couleur;
            Ordre = ordre;
        }

        public int IdElement { get; private set; }
        public Color Couleur { get; private set; }
        public int Ordre { get; }
        protected string TransformString;

        public abstract string ToSVG(bool is3D, bool contours);

        protected virtual string AddLineStyle()
        {
            return "style=\"stroke:rgb(" + Math.Max(0, Couleur.R - 150) + "," +
                      Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + "";
        }

        protected virtual string AddShapeStyle(bool contours)
        {
            return "style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" " +
                      (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }

        protected virtual string AddPerspectiveStyle(bool contours)
        {
            return "style=\"fill:rgb(" + Math.Max(0, Couleur.R - 70) + "," + Math.Max(0, Couleur.G - 70) + "," +
                   Math.Max(0, Couleur.B - 70) + ")\" " +
                   (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }

        public int CompareTo(Forme other)
        {
            return Ordre.CompareTo(other.Ordre);
        }
    }
}