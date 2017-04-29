using System;
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

        public override string ToSVG(bool is3D, bool contours)
        {
            return "<ellipse cx=\""+Centre.X+"\" cy=\""+Centre.Y+"\" rx=\""+Rayon+"\" ry=\""+RayonY+"\" style=\"fill: rgb("+Couleur.R+","+Couleur.G+","+Couleur.B+ ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + " />";
        }

        public void Rotation(int angle, int cx, int cy)
        {
            TransformString += "rotate("+angle+" "+cx+","+cy+") ";
        }
    }
}