using System;
using System.Text;
using System.Windows.Media;

namespace POO
{
    internal class Cercle : Forme, ITranslatable
    {
        //Constructeur
        public Cercle(int idElement, Color couleur, int ordre, int cx, int cy, int r) : base(idElement, couleur, ordre)
        {
            Centre = new Point(cx, cy);
            Rayon = r;
        }

        //Attributs
        public Point Centre { get; private set; }
        public int Rayon { get; private set; }
        
        /// <summary>
        /// Ovveride de la classe 
        /// </summary>
        /// <param name="is3D">Si la forme peut être affiché en 3d</param>
        /// <param name="contours">Savoir si on dessine un contour ou pas</param>
        /// <param name="tailleContours">taille du contour</param>
        /// <returns></returns>
        public override string ToSVG(bool is3D, bool contours, int tailleContours = 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!-- CERCLE -->");

            sb.AppendLine("<circle "+(contours ? AddLineStyle(tailleContours) : "")+" cx=\"" + Centre.X + "\" cy=\"" + Centre.Y + "\" r=\"" + Rayon + "\" "+AddShapeStyle(contours)+" />");
            if (is3D)
            {
                sb.AppendLine("\t<!-- 3D -->");
                sb.AppendLine("\t<path d=\"M" + (Centre.X - Rayon) + " " + Centre.Y + " A " + Rayon + " " +
                          (int) (Rayon * Math.Sin(Math.PI / 4) * 0.5f) + ", 0, 0 0, " + (Centre.X + Rayon) + " " +
                          Centre.Y + "\" " + AddPerspectiveStyle(contours) + " />");
                sb.AppendLine("\t<path stroke-dasharray=\"5,5\" d=\"M" + (Centre.X - Rayon) + " " + Centre.Y + " A " + Rayon +
                          " " + (int) (Rayon * Math.Sin(Math.PI / 4) * 0.5f) + ", 0, 0 1, " + (Centre.X + Rayon) + " " +
                          Centre.Y + "\" " + AddPerspectiveStyle(contours) + "/>");
                sb.AppendLine("\t<!-- FIN 3D -->");
            }
            //TODO: Ombre ?
            /*sb.AppendLine("<defs>");
            sb.AppendLine("<filter id=\"blur\" x=\"0\" y=\"0\" >");
            sb.AppendLine("<feGaussianBlur in=\"SourceGraphic\" stdDeviation=\"15\" />");
            sb.AppendLine("</filter>");
            sb.AppendLine("</defs>");
            sb.Append("<path d=\"M" + (Centre.X) + " " + (Centre.Y+Rayon) + " A " + Rayon + " " + Rayon + ", 0, 0 0, " + (Centre.X + Rayon) + " " + Centre.Y + "\" style=\"fill: black;\" filter=\"url(#blur)\" />");
            */

            sb.AppendLine("<!-- FIN CERCLE -->");
            return sb.ToString();
        }
        //Methodes override de la classe forme
        protected override string AddLineStyle(int taille)
        {
            return "stroke=\"rgb(" + Math.Max(0, Couleur.R - 150) + "," +
                   Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) + ")\" stroke-width=\""+taille+"\"";
        }

        protected override string AddPerspectiveStyle(bool contours)
        {
            return "style=\"fill: rgb(" + Math.Max(0, Couleur.R - 70) + "," + Math.Max(0, Couleur.G - 70) + "," + Math.Max(0, Couleur.B - 70) + ");"+(contours ? "stroke:rgb(" +
                   Math.Max(0, Couleur.R - 150) + "," + Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) +
                   ");stroke-width:1" : "" ) +"\" "+ (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }
        /// <summary>
        /// Fonction redefinie de l'interface Itranslatable
        /// </summary>
        /// <param name="dx">Nouvelle position x</param>
        /// <param name="dy">Nouvelle position y</param>
        public void Translation(int dx, int dy)
        {
            TransformString += "translate(" + dx + "," + dy + ") ";
        }
    }
}