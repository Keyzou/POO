﻿using System;
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
            return "<circle cx=\"" + Centre.X + "\" cy=\"" + Centre.Y + "\" r=\"" + Rayon + "\" style=\"fill: rgb(" +
                   Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + " />";
        }

        public void Translation(int dx, int dy)
        {
            TransformString += "translate(" + dx + "," + dy + ") ";
        }
    }
}