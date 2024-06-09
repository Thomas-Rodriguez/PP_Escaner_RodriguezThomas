using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Entidades
{
    public class TipoIncorrectoExcepcion : Exception
    {
        private string nombreClase;
        private string nombreMetodo;

        public string NombreClase { get { return nombreClase; } }
        public string NombreMetodo { get { return nombreMetodo; } }

        public TipoIncorrectoExcepcion(string mensaje, string nombreClase, string nombreMetodo)
            :this(mensaje, nombreClase, nombreMetodo, new Exception())
        {
            this.nombreMetodo = nombreMetodo;
            this.nombreClase = nombreClase;
        }

        public TipoIncorrectoExcepcion(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            :base(mensaje, innerException)
        {
            this.nombreMetodo = nombreMetodo;
            this.nombreClase = nombreClase;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Excepción en el método {this.nombreMetodo} de la clase {this.nombreClase}");
            text.AppendLine("Algo salió mal, revisa los detalles.");
            text.AppendLine($"Detalles: {this.InnerException}");
            return text.ToString();
        }
    }
}
