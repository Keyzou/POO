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
        
        public override string ToSVG()
        {
            return "<path d=\""+Path+"\" style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" "+TransformString+" />";
        }

        public void Rotation(double angle, int cx, int cy)
        {
            throw new NotImplementedException();
        }
    }
}