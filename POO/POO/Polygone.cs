using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace POO
{
    internal class Polygone : Forme, IRotatable
    {
        //
        public Polygone(int idElement, Color couleur, int ordre, Point[] points)
            : base(idElement, couleur, ordre)
        {
            Points = new List<Point>(points);
        }

        public List<Point> Points { get; private set; }
        protected int TailleContours = 0;

        public override string ToSVG(bool is3D, bool contours, int tailleContours = 0)
        {
            TailleContours = tailleContours;
            var sb = new StringBuilder();
            sb.AppendLine("<!-- POLYGONE -->");
            if (is3D)
            {
                sb.AppendLine("\t<!-- 3D -->");
                sb.Append("\t<polygon points=\"");
                foreach (var point in Points)
                {
                    int perspX = (int)(point.X + Math.Cos(Math.PI / 4) * Profondeur * 0.5f);
                    int perspY = (int)(point.Y - Math.Sin(Math.PI / 4) * Profondeur * 0.5f);
                    sb.Append(perspX + "," +perspY + " ");
                }
                sb.AppendLine("\" " + AddPerspectiveStyle(contours) + " />");
                AddPerspective(sb, contours);

                sb.AppendLine("\t<!-- FIN 3D -->");
            }
            sb.Append("<polygon points=\"");
            Points.ForEach(point => sb.Append(point.X+","+point.Y+" "));
            sb.AppendLine("\" "+AddShapeStyle(contours) +"/>");

            sb.AppendLine("<!-- FIN POLYGONE -->");
            return sb.ToString();
        }

        protected void AddPerspective(StringBuilder sb, bool contours)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                var p1 = Points[i];
                var p2 = Points[i + 1];
                int persp1X = (int)(p1.X + Math.Cos(Math.PI / 4) * 50 * 0.5f);
                int persp1Y = (int)(p1.Y - Math.Sin(Math.PI / 4) * 50 * 0.5f);
                int persp2X = (int)(p2.X + Math.Cos(Math.PI / 4) * 50 * 0.5f);
                int persp2Y = (int)(p2.Y - Math.Sin(Math.PI / 4) * 50 * 0.5f);
                sb.AppendLine("\t<polygon points=\"" + p1.X + "," + p1.Y + " " + p2.X +
                          "," + p2.Y + " " + persp2X + "," + persp2Y + " " + persp1X + "," + persp1Y + "\" " + AddPerspectiveStyle(contours) + "/>");
            }
        }

        protected override string AddShapeStyle(bool contours)
        {
            return "style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ");"+(contours ? AddLineStyle(TailleContours) : "")+"\" " +
                      (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }

        protected override string AddPerspectiveStyle(bool contours)
        {
            return "style=\"fill: rgb(" + Math.Max(0, Couleur.R - 70) + "," + Math.Max(0, Couleur.G - 70) + "," + Math.Max(0, Couleur.B - 70) +");" + (contours ? AddLineStyle(TailleContours) : "") + "\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }

        protected override string AddLineStyle(int taille)
        {
            return "stroke:rgb(" +
                   Math.Max(0, Couleur.R - 150) + "," + Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) +
                   ");stroke-width:"+taille+";";
        }

        public void Rotation(int angle, int cx, int cy)
        {
            TransformString += "rotate(" + angle + " " + cx + "," + cy + ") ";
        }
    }
}