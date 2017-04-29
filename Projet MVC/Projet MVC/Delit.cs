using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_MVC
{
    public class Delit
    {
        public TypeDelit Type { get; }
        public DateTime Date { get; }
        public string Description { get; }
        public int Jurisdiction { get; }
        public string Quartier { get; }

        public string DescriptionSpecificite;

        public double CoordX { get; }
        public double CoordY { get; }

        public enum TypeDelit
        {
            Vol,
            VolVehiculeMoteur,
            Cambriolage
        }
    }
}
