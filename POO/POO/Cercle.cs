﻿using System;
using System.Windows.Media;

namespace Projet_POO
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

        public void Translation()
        {
            throw new NotImplementedException();
        }
    }
}