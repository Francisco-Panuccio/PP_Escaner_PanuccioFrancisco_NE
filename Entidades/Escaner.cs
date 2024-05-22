using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        /*---Tipos Anidados---*/

        /// <summary>
        /// Enumerador del departamento del escáner según el tipo de documento.
        /// </summary>
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        /// <summary>
        /// Enumerador de los tipos de escáner.
        /// </summary>
        public enum TipoDoc
        {
            libro,
            mapa
        }

        /*---Campos---*/

        /// <summary>
        /// Atributos del escáner.
        /// </summary>
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        /*---Propiedades---*/

        /// <summary>
        /// Getter para obtener la lista de documentos del escáner.
        /// </summary>
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }

        /// <summary>
        /// Getter para obtener la locación del escáner.
        /// </summary>
        public Departamento Locacion
        {
            get => this.locacion;
        }

        /// <summary>
        /// Getter para obtener la marca del escáner.
        /// </summary>
        public string Marca
        {
            get => this.marca;
        }

        /// <summary>
        /// Getter para obtener el tipo del escáner.
        /// </summary>
        public TipoDoc Tipo
        {
            get => this.tipo;
        }

        /*---Constructor---*/

        /// <summary>
        /// Constructor que inicializa los atributos del escáner con valores determinados.
        /// </summary>
        /// <param name="marca">Marca del escáner</param><<
        /// <param name="tipo">Tipo del escáner</param><<
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            if (this.tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else if (this.tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }

        /*---Operadores---*/

        /// <summary>
        /// Operador sobreescrito != que indica si un documento NO se encuentra en la lista del escáner.
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="d">Documento a comparar</param><<
        /// <returns>True si no se encuentra, False si ya está en la lista</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /// <summary>
        /// Operador sobreescrito + que indica si un documento puede ser agregado a la lista del escáner.
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="d">Documento a agregar</param><<
        /// <returns>True si puede agregarse, False si no puede hacerlo por estar repetido o por tener un escáner incorrecto</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;
            if ((e != d) && (d.Estado == Documento.Paso.Inicio))
            {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Operador sobreescrito == que indica si un documento ya se encuentra en la lista del escáner.
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="d">Documento a comparar</param><<
        /// <returns>True si se encuentra en la lista (está repetido), False si se encuentra</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            TipoDoc tipoDocumento = d is Libro ? TipoDoc.libro : TipoDoc.mapa;
            if (e.Tipo == tipoDocumento)
            {
                foreach (Documento doc in e.listaDocumentos)
                {
                    if ((d is Libro && ((Libro)doc == (Libro)d)) || (d is Mapa && ((Mapa)doc == (Mapa)d)))
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        /*---Método---*/

        /// <summary>
        /// Cambia el estado del documento pasado por parámetro en caso de que se encuentre en la lista del escáner.
        /// </summary>
        /// <param name="d">Documento a cambiar de estado</param><<
        /// <returns>True si logró cambiarlo de estado, False si no lo hizo</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool retorno = false;
            if (this == d)
            {
                retorno = d.AvanzarEstado();
            }
            return retorno;
        }
    }
}