using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public static class Informes
    {
        /*---Métodos---*/

        /// <summary>
        /// Muestra la cantidad, el total de páginas o superficie, y los datos de los documentos dependiendo del estado en el que se encuentren.
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="estado">Estado del documento</param><<
        /// <param name="extension">Parámetro por referencia</param><<
        /// <param name="cantidad">Parámetro por referencia</param><<
        /// <param name="resumen">Parámetro por referencia</param><<
        static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    if (doc is Libro)
                    {
                        extension += ((Libro)doc).NumPaginas;
                    }
                    else
                    {
                        extension += ((Mapa)doc).Superficie;
                    }
                    cantidad++;
                    resumen += ($"{doc.ToString()}");
                }
            }
        }

        /// <summary>
        /// Muestra la cantidad, el total de páginas o superficie, y los datos del documento en estado "Distribuido".
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="extension">Parámetro por referencia</param><<
        /// <param name="cantidad">Parámetro por referencia</param><<
        /// <param name="resumen">Parámetro por referencia</param><<
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra la cantidad, el total de páginas o superficie, y los datos del documento en estado "EnEscaner".
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="extension">Parámetro por referencia</param><<
        /// <param name="cantidad">Parámetro por referencia</param><<
        /// <param name="resumen">Parámetro por referencia</param><<
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra la cantidad, el total de páginas o superficie, y los datos del documento en estado "EnRevision".
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="extension">Parámetro por referencia</param><<
        /// <param name="cantidad">Parámetro por referencia</param><<
        /// <param name="resumen">Parámetro por referencia</param><<
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra la cantidad, el total de páginas o superficie, y los datos del documento en estado "Terminado".
        /// </summary>
        /// <param name="e">Escáner</param><<
        /// <param name="extension">Parámetro por referencia</param><<
        /// <param name="cantidad">Parámetro por referencia</param><<
        /// <param name="resumen">Parámetro por referencia</param><<
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}