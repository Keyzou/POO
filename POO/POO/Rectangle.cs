using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace POO
{
    internal class Rectangle : Polygone, ITranslatable
    {
        public Rectangle(int idElement, Color couleur, int ordre, int x, int y, int longueur, int largeur)
            : base(idElement, couleur, ordre, new[] {new Point(x,y), new Point(x+longueur, y), new Point(x+longueur, y+largeur), new Point(x, y+largeur)})
        {
            Location = new Point(x, y);
            Longueur = longueur;
            Largeur = largeur;
        }
        
        public Point Location { get; private set; }
        public int Longueur { get; private set; }
        public int Largeur { get; private set; }

        public override string ToSVG(bool is3D, bool contours)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!-- RECTANGLE -->");
            if (is3D)
            {
                sb.AppendLine("\t<!-- 3D -->");
                AddPerspective(sb, contours);
                sb.AppendLine("\t<!-- FIN 3D -->");
            }

            sb.AppendLine("<rect x=\"" + Location.X + "\" y=\"" + Location.Y + "\" width=\"" + Longueur + "\" height=\"" +
                      Largeur + "\" "+AddShapeStyle(contours)+" />");
            sb.AppendLine("<!-- FIN RECTANGLE -->");
            return sb.ToString();
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