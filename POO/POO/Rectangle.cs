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
                   Largeur + "\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" "+(!string.IsNullOrEmpty(TransformString) ? "transform=\""+TransformString+"\"" : "")+" />";
        }

        public void Translation(int dx, int dy)
        {
            TransformString += "translate(" + dx + "," + dy + ") ";
        }

        public void Rotation(int angle, int cx, int cy)
        {
            TransformString += "rotate(" + angle + " " + cx + "," + cy + ") ";
        }
    }
}