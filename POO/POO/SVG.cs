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

        private SVG(List<Forme> formes)
        {
            _formes = formes;
        }

        public string ToSVG()
        {
            var sb = new StringBuilder();
            sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
            sb.AppendLine();
            _formes.Sort();
            _formes.ForEach(f => sb.Append("\t"+f.ToSVG()+"\n"));
            sb.Append("</svg>");
            sb.AppendLine();
            return sb.ToString();
        }

        public static SVG FromFile(string filePath)
        {
            var strArr = File.ReadAllLines(filePath);
            var formes = new List<Forme>();
            foreach (var s in strArr)
            {
                var args = s.Split(';');
                var id = int.Parse(args[1]);
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
                }
            }
            return new SVG(formes);
        }

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
