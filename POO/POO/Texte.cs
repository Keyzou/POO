using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO
{
    class Texte : Forme, ITranslatable, IRotatable
    {

        public string Contenu { get; private set; }

        public Texte(int idElement, Color couleur, int ordre, string contenu) : base(idElement, couleur, ordre)
        {
            this.Contenu = contenu;
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
