using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        private int numPaginas;

        public Libro(string titulo, string autor, int año, string barcode, string numNormalizado, int numPaginas)
            : base(titulo, autor, año, barcode, numNormalizado)
        {
            this.numPaginas = numPaginas;
        }
        public string ISBN { get { return NumNormalizado; } }
        public int NumPaginas { get { return numPaginas; } }

        public static bool operator ==(Libro L1, Libro L2)
        {
            return L1.Barcode == L2.Barcode || L1.ISBN == L2.ISBN || (L1.Titulo == L2.Titulo && L1.Autor == L2.Autor);
        }

        public static bool operator !=(Libro L1, Libro L2)
        {
            return !(L1.Barcode == L2.Barcode || L1.ISBN == L2.ISBN || (L1.Titulo == L2.Titulo && L1.Autor == L2.Autor));
        }

        public new string ToString()
        {
            StringBuilder text = new StringBuilder(base.ToString());
            text.AppendLine($"ISBN: {ISBN}");
            text.AppendLine($"Cod. de Barras: {Barcode}");
            text.AppendLine($"Numero de Paginas: {numPaginas}");
            return text.ToString();
        }
    }
}
