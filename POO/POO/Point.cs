using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Point : ITranslatable, IRotatable
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
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
