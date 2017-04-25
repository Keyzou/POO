using System;

namespace POO
{
    internal class Point : ITranslatable, IRotatable
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

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