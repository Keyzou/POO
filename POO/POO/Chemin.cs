using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace POO
{
    internal class Chemin : Forme, IRotatable
    {
        public Chemin(int idElement, Color couleur, int ordre, string path) : base(idElement, couleur, ordre)
        {
            Path = path;
        }

        public string Path { get; }
        protected int TailleContours = 0;

        public override string ToSVG(bool is3D, bool contours, int tailleContours = 0)
        {
            TailleContours = tailleContours;
            // TODO: => 3D
            /*
            var d = Path.Split('L', 'M', 'C', 'A', 'Z', 'T', 'Q', 'S', 'V', 'H');
            d = d.Where(p => !string.IsNullOrEmpty(p)).ToArray();
            d = d.Select(s => s.Trim()).ToArray();
            var regx = new Regex("[^a-zA-Z -]");
            var mvt = regx.Replace(Path, "").Replace(" ", "");
            */
            // TODO: => 3D

            return "<path d=\""+Path+"\" "+AddShapeStyle(contours)+" />";
        }
   
        protected override string AddShapeStyle(bool contours)
        {
            return "style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ");" + (contours ? AddLineStyle(TailleContours) : "") + "\" " +
                      (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
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