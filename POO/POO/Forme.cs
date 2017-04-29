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

        public int CompareTo(Forme other)
        {
            return Ordre.CompareTo(other.Ordre);
        }
    }
}