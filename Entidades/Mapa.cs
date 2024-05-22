using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        /*---Campos---*/

        /// <summary>
        /// Atributos del mapa.
        /// </summary>
        int alto;
        int ancho;

        /*---Constructor---*/

        /// <summary>
        /// Constructor que inicializa los atributos del mapa con valores determinados.
        /// </summary>
        /// <param name="titulo">Título del mapa</param><<
        /// <param name="autor">Autor del mapa</param><<
        /// <param name="anio">Año de publicación del mapa</param><<
        /// <param name="numNormalizado">Número para identificar al mapa</param><<
        /// <param name="codebar">Código de barras del mapa</param><<
        /// <param name="ancho">Ancho del mapa</param><<
        /// <param name="alto">Alto del mapa</param><<
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        /*---Propiedades---*/

        /// <summary>
        /// Getter para obtener el valor del atributo privado "alto".
        /// </summary>
        public int Alto
        {
            get => this.alto;
        }

        /// <summary>
        /// Getter para obtener el valor del atributo privado "ancho".
        /// </summary>
        public int Ancho
        {
            get => this.ancho;
        }

        /// <summary>
        /// Getter para obtener el valor de la multiplicación entre atributo privado "alto" y el "ancho".
        /// </summary>
        public int Superficie
        {
            get => (this.alto * this.ancho);
        }

        /*---Operadores---*/

        /// <summary>
        /// Operador sobreescrito != que permite comparar dos mapas.
        /// </summary>
        /// <param name="m1">Primer mapa a comparar</param><<
        /// <param name="m2">Segundo mapa a comparar</param><<
        /// <returns>True si son distintos, False si son iguales</returns>
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

        /// <summary>
        /// Operador sobreescrito == que permite comparar dos mapas.
        /// </summary>
        /// <param name="m1">Primer mapa a comparar</param><<
        /// <param name="m2">Segundo mapa a comparar</param><<
        /// <returns>True si son iguales, False si son distintos</returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return ((m1.Barcode == m2.Barcode) || ((m1.Titulo == m2.Titulo) && (m1.Autor == m2.Autor) && (m1.Anio == m2.Anio) && (m1.Superficie == m2.Superficie)));
        }

        /*---Método---*/

        /// <summary>
        /// Sobreescritura del método ToString para visulizar información del mapa.
        /// </summary>
        /// <returns>Un string con toda la información del mapa</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}");
            sb.AppendLine($"Superficie: {alto} * {ancho} = {this.Superficie} cm2.");
            return sb.ToString();
        }
    }
}