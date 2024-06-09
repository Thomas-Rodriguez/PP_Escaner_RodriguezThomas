using System.Text;

namespace Entidades
{
    public abstract class Documento
    {
        public enum Paso { Inicio, Distribuido, EnEscaner, EnRevision, Terminado }

        private int año;
        private string autor;
        private string barcode;
        private Paso estado = Paso.Inicio;
        private string numNormalizado;
        private string titulo;

        public Documento(string titulo, string autor, int año, string barcode, string numNormalizado)
        {
            this.año = año;
            this.autor = autor;
            this.barcode = barcode;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
        }
        public int Año { get { return año; } }
        public string Autor { get { return autor; } }
        public string Barcode { get { return barcode; } }
        public Paso Estado { get { return estado; } }
        protected string NumNormalizado { get { return numNormalizado; } }
        public string Titulo { get { return titulo; } }


        public bool AvanzarEstado()
        {
            bool retorno = true;
            
            if (estado != Paso.Terminado)
            {
                estado ++;
            }
            else if (estado == Paso.Terminado)
            {
                retorno = false;
            }

            
            return retorno;

        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Titulo: {titulo}");
            text.AppendLine($"Autor: {autor}");
            text.AppendLine($"Año: {año}");
            return text.ToString();
        }


    }
}
