﻿using System;
using System.Windows.Media;

namespace Projet_POO
{
    internal class Ellipse : Cercle, ITranslatable, IRotatable
    {
        public Ellipse(int idElement, Color couleur, int ordre, int cx, int cy, int rx, int ry)
            : base(idElement, couleur, ordre, cx, cy, rx)
        {
            RayonY = ry;
        }

        public int RayonY { get; private set; }

        public void Rotation()
        {
            throw new NotImplementedException();
        }

        public void Translation()
        {
            throw new NotImplementedException();
        }
    }
}