using System;
using System.Collections;
using System.Windows.Media;

namespace POO
{
    internal abstract class Forme : IComparable<Forme>
    {
        /// <summary>
        /// Constructeurs de la classe forme encaplusé pour n'être utilisé que dans les classes héritées et dérivées.
        /// </summary>
        /// <param name="idElement">Id eleme</param>
        /// <param name="couleur">Couleur de l'element</param>
        /// <param name="ordre">Ordre de l'element</param>
        protected Forme(int idElement, Color couleur, int ordre)
        {
            IdElement = idElement;
            Couleur = couleur;
            Ordre = ordre;
        }

        public int IdElement { get; private set; }
        public Color Couleur { get; private set; }
        public int Ordre { get; }
        protected string TransformString;
        public int Profondeur { get; set; }

        public abstract string ToSVG(bool is3D, bool contours, int tailleContours = 0);

        /// <summary>
        /// Methode pour les classe héritées: Dessine les contours de la forme
        /// </summary>
        /// <param name="taille">Rajoute un contour</param>
        /// <returns>Retourne la ligne de code svg</returns>
        protected virtual string AddLineStyle(int taille)
        {
            return "style=\"stroke:rgb(" + Math.Max(0, Couleur.R - 150) + "," +
                      Math.Max(0, Couleur.G - 150) + "," + Math.Max(0, Couleur.B - 150) + ");"+(taille>0 ? "stroke-width:"+taille+";" : "")+"\" " + (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "") + "";
        }
        /// <summary>
        /// Remplie la forme de la couleur rgb renseignée
        /// </summary>
        /// <param name="contours"></param>
        /// <returns></returns>
        protected virtual string AddShapeStyle(bool contours)
        {
            return "style=\"fill: rgb(" + Couleur.R + "," + Couleur.G + "," + Couleur.B + ")\" " +
                      (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }
        /// <summary>
        /// Rajoute de la couleur a la perspective
        /// </summary>
        /// <param name="contours"></param>
        /// <returns></returns>
        protected virtual string AddPerspectiveStyle(bool contours)
        {
            return "style=\"fill:rgb(" + Math.Max(0, Couleur.R - 70) + "," + Math.Max(0, Couleur.G - 70) + "," +
                   Math.Max(0, Couleur.B - 70) + ")\" " +
                   (!string.IsNullOrEmpty(TransformString) ? "transform=\"" + TransformString + "\"" : "");
        }
        /// <summary>
        /// On compare en fonction de l'ordre d'affichage
        /// </summary>
        /// <param name="other">Autre forme</param>
        /// <returns></returns>
        public int CompareTo(Forme other)
        {
            return Ordre.CompareTo(other.Ordre);
        }
    }
}