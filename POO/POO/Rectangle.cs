using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Rectangle : Forme, ITranslatable, IRotatable
    {
        public Point Location { get; private set; }
        public int Longueur { get; private set; }
        public int Largeur { get; private set; }

        public Rectangle(int idElement, Color couleur, int ordre, int x, int y, int longueur, int largeur) : base(idElement, couleur, ordre)
        {
            Location = new Point(x, y);
            this.Longueur = longueur;
            this.Largeur = largeur;
        }

        public void Translation()
        {
            throw new NotImplementedException();
        }

        public void Rotation()
        {
            throw new NotImplementedException();
        }
    }
}
