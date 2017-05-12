using System;
using System.Text;
using System.Windows.Media;

namespace POO
{
    internal class Ellipse : Cercle, IRotatable
    {
        public Ellipse(int idElement, Color couleur, int ordre, int cx, int cy, int rx, int ry)
            : base(idElement, couleur, ordre, cx, cy, rx)
        {
            RayonY = ry;
        }

        public int RayonY { get; private set; }

        public override string ToSVG(bool is3D, bool contours, int tailleContours = 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!-- ELLIPSE -->");
            sb.AppendLine("<ellipse "+ (contours ? AddLineStyle(tailleContours) : "") + " cx=\""+Centre.X+"\" cy=\""+Centre.Y+"\" rx=\""+Rayon+"\" ry=\""+RayonY+"\" "+AddShapeStyle(contours)+" />");
            if (is3D)
            {
                sb.AppendLine("\t<!-- 3D -->");
                int x1 = Rayon > RayonY ? Centre.X : Centre.X - Rayon;
                int y1 = Rayon > RayonY ? Centre.Y - RayonY : Centre.Y;
                int x2 = Rayon > RayonY ? Centre.X : Centre.X + Rayon;
                int y2 = Rayon > RayonY ? Centre.Y + RayonY : Centre.Y;
                int rx = Rayon > RayonY ? (int) (Profondeur * Math.Cos(Math.PI / 4) * 0.5f) : Rayon;
                int ry = Rayon > RayonY ? RayonY : (int) (Profondeur * Math.Sin(Math.PI / 4) * 0.5f);
                sb.AppendLine("\t<path d=\"M" + x1 + " " + y1 + " A " + rx + " " + ry + ", 0, 0 0, " + x2 + " " + y2 + "\" " + AddPerspectiveStyle(contours) + " />");
                sb.AppendLine("\t<path stroke-dasharray=\"5,5\" d=\"M" + x1 + " " + y1 + " A " + rx +
                          " " + ry + ", 0, 0 1, " + x2 + " " +
                          y2 + "\" " + AddPerspectiveStyle(contours) + "/>");
                // TODO: Cylindres?
                sb.AppendLine("\t<!-- FIN 3D -->");
            }
            sb.AppendLine("<!-- FIN ELLIPSE -->");
            return sb.ToString();
        }

        public void Rotation(int angle, int cx, int cy)
        {
            TransformString += "rotate("+angle+" "+cx+","+cy+") ";
        }
    }
}