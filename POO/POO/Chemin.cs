using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace POO
{
    internal class Chemin : Forme, IRotatable
    {
        public Chemin(int idElement, Color couleur, int ordre, string path) : base(idElement, couleur, ordre)
        {
            Path = path;
        }

        public string Path { get; private set; }
        
        public override string ToSVG(bool is3D, bool contours)
        {
            return "<path d=\""+Path+"\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + " />";
        }

        public void Rotation(int angle, int cx, int cy)
        {
            TransformString += "rotate(" + angle + " " + cx + "," + cy + ") ";
        }
    }
}