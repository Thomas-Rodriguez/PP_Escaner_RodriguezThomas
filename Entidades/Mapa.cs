using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        private int alto;
        private int ancho;

        public Mapa(string titulo, string autor, int año, string numNormalizado, string barcode, int ancho, int alto)
            : base(titulo, autor, año, barcode, numNormalizado)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public int Ancho { get { return ancho; } }
        public int Alto { get { return alto; } }
        public int Superficie { get { return ancho * alto; } }

        public static bool operator ==(Mapa M1, Mapa M2)
        {
            return M1.Barcode == M2.Barcode || (M1.Titulo == M2.Titulo && M1.Autor == M2.Autor && M1.Año == M2.Año && M1.Superficie == M2.Superficie);
        }

        public static bool operator !=(Mapa M1, Mapa M2)
        {
            return !(M1.Barcode == M2.Barcode || (M1.Titulo == M2.Titulo && M1.Autor == M2.Autor && M1.Año == M2.Año && M1.Superficie == M2.Superficie));
        }

        public new string ToString()
        {
            StringBuilder text = new StringBuilder(base.ToString());
            text.AppendLine($"Cod de Barras: {Barcode}");
            text.AppendLine($"Superficie: {Alto} * {Ancho} = {Superficie} cm2");
            return text.ToString();
        }
    }
}
