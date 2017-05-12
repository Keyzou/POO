using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace POO
{
    internal class SVG
    {
        private readonly List<Forme> _formes;
        private readonly bool _is3D;
        private readonly bool _contours;
        private readonly int _tailleContours;

        /// <summary>
        /// Instancie la classe svg
        /// </summary>
        /// <param name="formes">Liste des formes a convertir</param>
        /// <param name="is3D">3D?</param>
        /// <param name="contours">Contours?</param>
        /// <param name="tailleContours">Taille des contours</param>
        private SVG(List<Forme> formes, bool is3D, bool contours, int tailleContours)
        {
            _formes = formes;
            _is3D = is3D;
            _contours = contours;
            _tailleContours = tailleContours;
        }

        /// <summary>
        /// Convertit en svg
        /// </summary>
        /// <returns></returns>
        public string ToSVG()
        {
            var sb = new StringBuilder();
            sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
            sb.AppendLine();
            _formes.Sort();
            Console.WriteLine("Render order: ");
            _formes.ForEach(f => Console.WriteLine(f.GetType()+" "+f.Ordre));
            // TODO: Projection centrale / point de fuite
            _formes.ForEach(f => sb.AppendLine(f.ToSVG(_is3D, _contours, _tailleContours)));
            sb.Append("</svg>");
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// Crée une instance de la classe svg a partir d'un fichier
        /// </summary>
        /// <param name="filePath">Chemin du fichier</param>
        /// <param name="is3D">3D?</param>
        /// <param name="contours">Contour?</param>
        /// <param name="profondeur">Profondeur de la 3d</param>
        /// <param name="tailleContours">Taille des contours</param>
        /// <returns></returns>
        public static SVG FromFile(string filePath, bool? is3D, bool? contours, int profondeur = 0, int tailleContours = 0)
        {
            var strArr = File.ReadAllLines(filePath);
            var formes = new List<Forme>();
            var transforms = new List<string>();
            foreach (var s in strArr)
            {
                var args = s.Split(';');
                var id = int.Parse(args[1]);

                if (string.Equals(args[0], "Rotation") || string.Equals(args[0], "Translation"))
                {
                    transforms.Add(s);
                    continue;
                }

                if (string.Equals(args[0], "Cercle"))
                {
                    var c = new Color
                    {
                        R = (byte) int.Parse(args[5]),
                        G = (byte) int.Parse(args[6]),
                        B = (byte) int.Parse(args[7])
                    };
                    var ordre = int.Parse(args[8]);
                    formes.Add(new Cercle(id, c, ordre, int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4])));
                } else if (string.Equals(args[0], "Ellipse"))
                {
                    var c = new Color
                    {
                        R = (byte)int.Parse(args[6]),
                        G = (byte)int.Parse(args[7]),
                        B = (byte)int.Parse(args[8])
                    };
                    var ordre = int.Parse(args[9]);
                    formes.Add(new Ellipse(id, c, ordre, int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5])));
                } else if (string.Equals(args[0], "Rectangle"))
                {
                    var c = new Color
                    {
                        R = (byte)int.Parse(args[6]),
                        G = (byte)int.Parse(args[7]),
                        B = (byte)int.Parse(args[8])
                    };
                    var ordre = int.Parse(args[9]);
                    formes.Add(new Rectangle(id, c, ordre, int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5])));
                } else if (string.Equals(args[0], "Texte"))
                {
                    var c = new Color
                    {
                        R = (byte)int.Parse(args[5]),
                        G = (byte)int.Parse(args[6]),
                        B = (byte)int.Parse(args[7])
                    };
                    var ordre = int.Parse(args[8]);
                    formes.Add(new Texte(id, c, ordre, args[4], new Point(int.Parse(args[2]), int.Parse(args[3]))));

                }
                else if (string.Equals(args[0], "Polygone"))
                {
                    var c = new Color
                    {
                        R = (byte) int.Parse(args[3]),
                        G = (byte) int.Parse(args[4]),
                        B = (byte) int.Parse(args[5])
                    };
                    var pointsStr = args[2].Split(' ');
                    var points = new Point[pointsStr.Length];
                    for (int i = 0; i < points.Length; i++)
                    {
                        var str = pointsStr[i].Split(',');
                        points[i] = new Point(int.Parse(str[0]), int.Parse(str[1]));
                    }
                    var ordre = int.Parse(args[6]);
                    formes.Add(new Polygone(id, c, ordre, points));
                }else if (string.Equals(args[0], "Chemin"))
                {

                    var c = new Color
                    {
                        R = (byte)int.Parse(args[3]),
                        G = (byte)int.Parse(args[4]),
                        B = (byte)int.Parse(args[5])
                    };
                    var ordre = int.Parse(args[6]);
                    formes.Add(new Chemin(id, c, ordre, args[2]));
                }
                

            }
            if(is3D.Value)
                formes.ForEach(f => f.Profondeur = profondeur);
            foreach (var transform in transforms)
            {
                var args = transform.Split(';');
                switch (args[0])
                {
                    case "Rotation":
                        var rotatable = formes[int.Parse(args[1]) - 1] as IRotatable;
                        rotatable?.Rotation(int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]));
                        break;
                    case "Translation":
                        var translatable = formes[int.Parse(args[1]) - 1] as ITranslatable;
                        translatable?.Translation(int.Parse(args[2]), int.Parse(args[3]));
                        break;
                    default:
                        break;
                }
            }

            return new SVG(formes, is3D ?? false , contours ?? false, tailleContours);
        }
        /// <summary>
        /// Enregistre le fichier svg
        /// </summary>
        /// <param name="path">Chemin du nouveau fichier</param>
        public void Save(string path)
        {
            File.WriteAllText(path, ToSVG());
        }

        public override string ToString()
        {
            return ToSVG();
        }
    }
}
