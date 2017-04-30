using System;
using System.Text;
using System.Windows.Media;

namespace POO
{
    internal class Cercle : Forme, ITranslatable
    {
        public Cercle(int idElement, Color couleur, int ordre, int cx, int cy, int r) : base(idElement, couleur, ordre)
        {
            Centre = new Point(cx, cy);
            Rayon = r;
        }

        public Point Centre { get; private set; }
        public int Rayon { get; private set; }
        
        public override string ToSVG(bool is3D, bool contours)
        {
            var sb = new StringBuilder();

            sb.Append("<circle "+(contours ? AddLineStyle() : "")+" cx=\"" + Centre.X + "\" cy=\"" + Centre.Y + "\" r=\"" + Rayon + "\" "+AddShapeStyle()+" />");
            if (is3D)
            {
                sb.Append("<path d=\"M" + (Centre.X - Rayon) + " " + Centre.Y + " A " + Rayon + " " +
                          (int) (Rayon * Math.Sin(Math.PI / 4) * 0.5f) + ", 0, 0 0, " + (Centre.X + Rayon) + " " +
                          Centre.Y + "\" " + AddPerspectiveStyle() + " />");
                sb.Append("<path stroke-dasharray=\"5,5\" d=\"M" + (Centre.X - Rayon) + " " + Centre.Y + " A " + Rayon +
                          " " + (int) (Rayon * Math.Sin(Math.PI / 4) * 0.5f) + ", 0, 0 1, " + (Centre.X + Rayon) + " " +
                          Centre.Y + "\" " + AddPerspectiveStyle() + "/>");
            }
            //TODO: Ombre ?
            /*sb.AppendLine("<defs>");
            sb.AppendLine("<filter id=\"blur\" x=\"0\" y=\"0\" >");
            sb.AppendLine("<feGaussianBlur in=\"SourceGraphic\" stdDeviation=\"15\" />");
            sb.AppendLine("</filter>");
            sb.AppendLine("</defs>");
            sb.Append("<path d=\"M" + (Centre.X) + " " + (Centre.Y+Rayon) + " A " + Rayon + " " + Rayon + ", 0, 0 0, " + (Centre.X + Rayon) + " " + Centre.Y + "\" style=\"fill: black;\" filter=\"url(#blur)\" />");
            */
            return sb.ToString();
        }

        protected override string AddLineStyle()
        {
            return "stroke=\"rgb(" + Math.Max(0, Couleur.R - 150) + "," +
                   Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) + ")\" stroke-width=\"1\"";
        }

        protected override string AddPerspectiveStyle()
        {
            return "style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ");stroke:rgb(" +
                   Math.Max(0, Couleur.R - 70) + "," + Math.Max(0, Couleur.G - 70) + "," + Math.Max(0, Couleur.B - 70) +
                   ");stroke-width:1\"";
        }

        public void Translation(int dx, int dy)
        {
            TransformString += "translate(" + dx + "," + dy + ") ";
        }
    }
}