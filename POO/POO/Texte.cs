using System;
using System.Windows.Media;

namespace POO
{
    internal class Texte : Forme, ITranslatable, IRotatable
    {
        public Texte(int idElement, Color couleur, int ordre, string contenu, Point location) : base(idElement, couleur, ordre)
        {
            Contenu = contenu;
            Location = location;
        }

        public Point Location { get; private set; }
        public string Contenu { get; private set; }

        public override string ToSVG()
        {
            return "<text x=\"" + Location.X + "\" y=\"" + Location.Y + "\" fill=\"rgb(" + Couleur.R + "," + Couleur.G +
                   "," + Couleur.B + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + ">" + Contenu + "</text>";
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