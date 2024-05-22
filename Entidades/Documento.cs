using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        /*---Tipos Anidados---*/

        /// <summary>
        /// Enumerador de los pasos del documento en el escáner.
        /// </summary>
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        /*---Campos---*/

        /// <summary>
        /// Atributos del documento.
        /// </summary>
        int anio;
        string autor;
        string barcode;
        Paso estado = Paso.Inicio;
        string numNormalizado;
        string titulo;

        /*---Constructor---*/

        /// <summary>
        /// Constructor que inicializa los atributos del documento con valores determinados.
        /// </summary>
        /// <param name="titulo">Título del documento</param><<
        /// <param name="autor">Autor del documento</param><<
        /// <param name="anio">Año de publicación del documento</param><<
        /// <param name="numNormalizado">Número para identificar al documento</param><<
        /// <param name="barcode">Código de barras del documento</param><<
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
        }

        /*---Propiedades---*/

        /// <summary>
        /// Getter para obtener el valor del atributo privado "anio".
        /// </summary>
        public int Anio
        {
            get => this.anio;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "autor".
        /// </summary>
        public string Autor
        {
            get => this.autor;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "barcode".
        /// </summary>
        public string Barcode
        {
            get => this.barcode;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "estado".
        /// </summary>
        public Paso Estado
        {
            get => this.estado;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "numNormalizado".
        /// </summary>
        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "titulo".
        /// </summary>
        public string Titulo
        {
            get => this.titulo;
        }

        /*---Métodos---*/

        /// <summary>
        /// Avanza el estado del documento en el escáner.
        /// </summary>
        /// <returns>True si avanzó el estado, False si ya está terminado</returns>
        public bool AvanzarEstado()
        {
            bool retorno;
            if (this.estado == Paso.Terminado)
            {
                retorno = false;
            }
            else
            {
                this.estado++;
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Sobreescritura del método ToString para visulizar información del documento.
        /// </summary>
        /// <returns>Un string con toda la información del documento</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {this.titulo}");
            sb.AppendLine($"Autor: {this.autor}");
            sb.AppendLine($"Año: {this.anio}");
            sb.AppendLine($"Código de Barras: {this.barcode}");
            return sb.ToString();
        }
    }
}