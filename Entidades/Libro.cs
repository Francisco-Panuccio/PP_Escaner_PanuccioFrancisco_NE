using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        /*---Campo---*/

        /// <summary>
        /// Atributos del libro.
        /// </summary>
        int numPaginas;

        /*---Constructor---*/

        /// <summary>
        /// Constructor que inicializa los atributos del libro con valores determinados.
        /// </summary>
        /// <param name="titulo">Título del libro</param><<
        /// <param name="autor">Autor del libro</param><<
        /// <param name="anio">Año de publicación del libro</param><<
        /// <param name="numNormalizado">Número para identificar al libro</param><<
        /// <param name="codebar">Código de barras del libro</param><<
        /// <param name="numPaginas">Total de páginas del libro</param><<
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }

        /*---Propiedades---*/

        /// <summary>
        /// Getter para obtener el valor del atributo privado "numNormalizado", renombrado a ISBN.
        /// </summary>
        public string ISBN
        {
            get => this.NumNormalizado;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "numPagina".
        /// </summary>
        public int NumPaginas
        {
            get => this.numPaginas;
        }

        /*---Operadores---*/

        /// <summary>
        /// Operador sobreescrito != que permite comparar dos libros.
        /// </summary>
        /// <param name="l1">Primer libro a comparar</param><<
        /// <param name="l2">Segundo libro a comparar</param><<
        /// <returns>True si son distintos, False si son iguales</returns>
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        /// <summary>
        /// Operador sobreescrito == que permite comparar dos libros.
        /// </summary>
        /// <param name="l1">Primer libro a comparar</param><<
        /// <param name="l2">Segundo libro a comparar</param><<
        /// <returns>True si son iguales, False si son distintos</returns>
        public static bool operator ==(Libro l1, Libro l2)
        {
            return ((l1.Barcode == l2.Barcode) || (l1.ISBN == l2.ISBN) || ((l1.Titulo == l2.Titulo) && (l1.Autor == l2.Autor)));
        }

        /*---Método---*/

        /// <summary>
        /// Sobreescritura del método ToString para visulizar información del libro.
        /// </summary>
        /// <returns>Un string con toda la información del libro</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int lenght = base.ToString().IndexOf("Código") - 1;
            sb.Append($"{base.ToString()}");
            sb.Insert(lenght, $"\nISBN: {this.ISBN}");
            sb.AppendLine($"Número de Páginas: {this.NumPaginas}.");
            return sb.ToString();
        }
    }
}
