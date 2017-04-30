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

        public override string ToSVG(bool is3D, bool contours)
        {
            var sb = new StringBuilder();
            if (is3D)
            {
                sb.Append("<polygon points=\"");
                foreach (var point in Points)
                {
                    //TODO: Profondeur variable
                    int perspX = (int)(point.X + Math.Cos(Math.PI / 4) * 50 * 0.5f);
                    int perspY = (int)(point.Y - Math.Sin(Math.PI / 4) * 50 * 0.5f);
                    sb.Append(perspX + "," +perspY + " ");
                }
                sb.Append("\" " + AddPerspectiveStyle() + " />");
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    var p1 = Points[i];
                    var p2 = Points[i + 1];
                    int persp1X = (int)(p1.X + Math.Cos(Math.PI / 4) * 50 * 0.5f);
                    int persp1Y = (int)(p1.Y - Math.Sin(Math.PI / 4) * 50 * 0.5f);
                    int persp2X = (int)(p2.X + Math.Cos(Math.PI / 4) * 50 * 0.5f);
                    int persp2Y = (int)(p2.Y - Math.Sin(Math.PI / 4) * 50 * 0.5f);
                    sb.Append("<polygon points=\"" + p1.X + "," + p1.Y + " " + p2.X +
                              "," + p2.Y + " " + persp2X + "," + persp2Y + " " + persp1X + "," + persp1Y + "\" " + AddPerspectiveStyle() + "/>");
                    if (contours)
                    {
                        //TODO: Diviser le polygone en triangles et regarder si un point est dans le triangle et dans ce cas ne pas dessiner la ligne
                        sb.Append("<line x1=\"" + p1.X + "\" y1=\"" + p1.Y + "\" x2=\"" + p2.X + "\" y2=\"" + p2.Y + "\" " +
                             AddLineStyle() + " />");
                        sb.Append("<line x1=\"" + p1.X + "\" y1=\"" + p1.Y + "\" x2=\"" + persp1X + "\" y2=\"" + persp1Y + "\" " +
                             AddLineStyle() + " />");
                        sb.Append("<line x1=\"" + persp1X + "\" y1=\"" + persp1Y + "\" x2=\"" + persp2X + "\" y2=\"" + persp2Y + "\" " +
                             AddLineStyle() + " />");
                        sb.Append("<line x1=\"" + persp2X + "\" y1=\"" + persp2Y + "\" x2=\"" + p2.X + "\" y2=\"" + p2.Y + "\" " +
                             AddLineStyle() + " />");
                    }
                }
            }
            sb.Append("<polygon points=\"");
            Points.ForEach(point => sb.Append(point.X+","+point.Y+" "));
            sb.Append("\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + " />");
            if (contours)
            {
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    var p1 = Points[i];
                    var p2 = Points[i + 1];
                    sb.Append("<line x1=\"" + p1.X + "\" y1=\"" + p1.Y + "\" x2=\"" + p2.X + "\" y2=\"" + p2.Y + "\" " +
                              AddLineStyle() + " />");
                }
                sb.Append("<line x1=\"" + Points[Points.Count-1].X + "\" y1=\"" + Points[Points.Count - 1].Y + "\" x2=\"" + Points[0].X + "\" y2=\"" + Points[0].Y + "\" " +
                              AddLineStyle() + " />");
            }
            return sb.ToString();
        }
        
        public void Rotation(int angle, int cx, int cy)
        {
            TransformString += "rotate(" + angle + " " + cx + "," + cy + ") ";
        }
    }
}