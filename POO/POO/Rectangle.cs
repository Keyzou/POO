using System;
using System.Text;
using System.Windows;
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

        public int Profondeur = 15;
        public Point Location { get; private set; }
        public int Longueur { get; private set; }
        public int Largeur { get; private set; }

        public override string ToSVG(bool is3D, bool contours)
        {
            var sb = new StringBuilder();
            sb.Append("<rect x=\"" + Location.X + "\" y=\"" + Location.Y + "\" width=\"" + Longueur + "\" height=\"" +
                      Largeur + "\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" " +
                      (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + " />");
            if (is3D)
            {
                // TODO: automatiser
                int perspX = (int) (Location.X + Math.Cos(Math.PI / 4) * Location.Y * 0.5f);
                int perspY = (int)(Location.Y - Math.Sin(Math.PI / 4) * Location.X * 0.5f);
                sb.Append("\n\t\t<path d=\"M"+Location.X+" "+Location.Y+" L"+perspX+" "+perspY+" L"+(Longueur+perspX)+" "+perspY+" L"+(Longueur+perspX)+" "+(Largeur+perspY)+" L"+ (Location.X + Longueur) +" "+(Location.Y + Largeur) +" L"+(Location.X+Longueur)+" "+Location.Y+" Z\" style=\"fill:rgb("+Math.Max(0, Couleur.R - 70)+","+Math.Max(0, Couleur.G - 70)+","+ Math.Max(0, Couleur.B - 70) + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") +" />");
                if (contours)
                {
                    sb.Append("\n\t\t\t<line x1=\"" + (Location.X + Longueur) + "\" y1=\"" + Location.Y + "\" x2=\"" + (perspX + Longueur) +
                      "\" y2=\"" + (perspY) + "\" "+AddStyle()+" />");
                    sb.Append("\n\t\t\t<line x1=\"" + Location.X+"\" y1=\""+Location.Y+"\" x2=\""+perspX+"\" y2=\""+perspY+"\" "+AddStyle()+" />");
                    sb.Append("\n\t\t\t<line x1=\"" + perspX + "\" y1=\"" + perspY + "\" x2=\"" + (perspX+Longueur) + "\" y2=\"" + (perspY) + "\" " + AddStyle() + " />");
                    sb.Append("\n\t\t\t<line x1=\"" + (perspX+Longueur) + "\" y1=\"" + perspY + "\" x2=\"" + (perspX+Longueur) + "\" y2=\"" + (perspY+Largeur) + "\" " + AddStyle() + " />");
                    sb.Append("\n\t\t\t<line x1=\"" + (Location.X+Longueur) + "\" y1=\"" + (Location.Y+Largeur) + "\" x2=\"" + (perspX+Longueur) + "\" y2=\"" + (perspY+Largeur) + "\" " + AddStyle() + " />");
                }
                // =========================================================
            }
            // TODO: automatiser
            if (contours)
            {
                sb.Append("\n\t\t<line x1=\"" + (Location.X) + "\" y1=\"" + Location.Y + "\" x2=\"" + (Location.X + Longueur) +
                      "\" y2=\"" + (Location.Y) + "\" " + AddStyle() + " />");
                sb.Append("\n\t\t<line x1=\"" + (Location.X+Longueur) + "\" y1=\"" + Location.Y + "\" x2=\"" + (Location.X + Longueur) +
                      "\" y2=\"" + (Location.Y+Largeur) + "\" " + AddStyle() + " />");
                sb.Append("\n\t\t<line x1=\"" + (Location.X) + "\" y1=\"" + (Location.Y+Largeur) + "\" x2=\"" + (Location.X + Longueur) +
                      "\" y2=\"" + (Location.Y+Largeur) + "\" " + AddStyle() + " />");
                sb.Append("\n\t\t<line x1=\"" + (Location.X) + "\" y1=\"" + Location.Y + "\" x2=\"" + (Location.X) +
                      "\" y2=\"" + (Location.Y+Largeur) + "\" " + AddStyle() + " />");
            }
            return sb.ToString();
        }

        private string AddStyle()
        {
            return "style=\"stroke:rgb(" + Math.Max(0, Couleur.R - 150) + "," +
                      Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + "";
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