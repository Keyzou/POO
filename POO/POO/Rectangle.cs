using System;
using System.Windows.Media;

namespace POO
{
    internal class Rectangle : Forme, ITranslatable, IRotatable
    {
        public Rectangle(int idElement, Color couleur, int ordre, int x, int y, int longueur, int largeur)
            : base(idElement, couleur, ordre)
        {
            Location = new Point(x, y);
            Longueur = longueur;
            Largeur = largeur;
        }

        public Point Location { get; private set; }
        public int Longueur { get; private set; }
        public int Largeur { get; private set; }

        public override string ToSVG()
        {
            return "<rect x=\"" + Location.X + "\" y=\"" + Location.Y + "\" width=\"" + Longueur + "\" height=\"" +
                   Largeur + "\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" "+TransformString+" />";
        }

        public void Translation(int dx, int dy)
        {
            throw new NotImplementedException();
        }

        public void Rotation(double angle, int cx, int cy)
        {
            throw new NotImplementedException();
        }
    }
}