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
        public int Ordre { get; private set; }

        public abstract string ToSVG();

        public int CompareTo(Forme other)
        {
            return Ordre.CompareTo(other.Ordre);
        }
    }
}