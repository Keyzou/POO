using System.Windows.Media;

namespace Projet_POO
{
    internal abstract class Forme
    {
        protected Forme(int idElement, Color couleur, int ordre)
        {
            IdElement = idElement;
            Couleur = couleur;
            Ordre = ordre;
        }

        public int IdElement { get; private set; }
        public Color Couleur { get; private set; }
        public int Ordre { get; private set; }
    }
}