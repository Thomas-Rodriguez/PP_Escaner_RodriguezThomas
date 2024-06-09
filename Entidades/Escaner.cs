using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        public enum Departamento { nulo, mapoteca, procesosTecnicos }
        public enum TipoDoc { libro, mapa }

        private List<Documento> listaDocumentos;
        private Departamento location;
        private string marca;
        private TipoDoc tipo;


        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            if (this.tipo == TipoDoc.mapa)
            {
                this.location = Departamento.mapoteca;
            }
            else if (this.tipo == TipoDoc.libro)
            {
                this.location = Departamento.procesosTecnicos;
            }
        }

        public List<Documento> ListaDocumentos { get { return listaDocumentos; } }
        public Departamento Location { get { return location; } }
        public string Marca { get { return marca; } }
        public TipoDoc Tipo { get { return tipo; } }

        public static bool operator ==(Escaner e, Documento d)
        {
            TipoDoc escanerTipo = e.tipo;
            TipoDoc documentoTipo;

            if (d is Libro)
            {
                documentoTipo = TipoDoc.libro;
            }
            else
            {
                documentoTipo = TipoDoc.mapa;
            }

            if (escanerTipo != documentoTipo)
            {
                throw new TipoIncorrectoExcepcion("Este escáner no acepta este tipo de documento", "Escaner", "Sobrecarga ==");
            }

            foreach (Documento doc in e.listaDocumentos)
            {
                if ((d is Libro && doc is Libro) && ((Libro)d == (Libro)doc)) //si el tipo de documento es "d" es un Libro y la instancia de "doc" es Libro tambien 
                {
                    return true;
                }
                else if ((d is Mapa && doc is Mapa) && ((Mapa)d == (Mapa)doc))//si el tipo de documento es "d" es un Mapa y la instancia de "doc" es Mapa tambien 
                {
                    return true;
                }
                else if (d.GetType() == doc.GetType() && d == doc) // verifica si la instancia "d" y "doc" son del mismo tipo y que d y doc son los mismos en memoria
                {
                    return true;
                }
            }
            return false;                       
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            try
            {
                if ((e == d) || (e != d && d.Estado != Documento.Paso.Inicio))
                {
                    return false;
                }

                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                return true;
            }
            catch (TipoIncorrectoExcepcion ex)
            {                
                throw new TipoIncorrectoExcepcion("El Documento no se pudo añadir a la lista.", "Escaner", "Sobrecarga +", ex);
            }
        }


        public bool CambiarEstadoDocumento(Documento d)
        {
            foreach (Documento documento in listaDocumentos)
            {
                if (documento == d)
                {
                    return documento.AvanzarEstado();
                }
            }
            return false;
        }
    }
}
