using System;
using System.Windows.Media;

namespace Projet_POO
{
    internal class Texte : Forme, ITranslatable, IRotatable
    {
        public Texte(int idElement, Color couleur, int ordre, string contenu) : base(idElement, couleur, ordre)
        {
            Contenu = contenu;
        }

        public string Contenu { get; private set; }

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