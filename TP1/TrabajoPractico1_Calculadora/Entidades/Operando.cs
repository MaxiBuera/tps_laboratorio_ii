using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Constructor que asigna a número el valor pasado por parámetro de tipo double
        /// </summary>
        /// <param name="numero">Valor con el que se inicializara el atributo numero</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que asigna a número el valor pasado por parámetro de tipo string
        /// </summary>
        /// <param name="numero">Valor con el que se inicializara el atributo numero validado</param>
        public Operando(string numero)
        {
            this.numero = ValidarOperando(numero);
        }

        /// <summary>
        /// Constructor por defecto. Inicializa el valor en 0
        /// </summary>
        public Operando() : this(0)
        {

        }

        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        /// <summary>
        /// Valida que el operando sea valido
        /// </summary>
        /// <param name="numero">operando</param>
        /// <returns>Devuelve el operando, si no es valido devuelve 0</returns>
        public double ValidarOperando(string numero)
        {
            double oprandoValido;

            if (double.TryParse(numero, out oprandoValido))
            {
                return oprandoValido;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida que el parametro sea un numero binario
        /// </summary>
        /// <param name="binario">parametro a validar</param>
        /// <returns>Devuelve true si la cadena es binario, sino devuelve false</returns>
        private bool EsBinario(string binario)
        {
            foreach (char letra in binario)
            {
                if (letra != '1' && letra != '0')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// convierte el numero pasado por parametro a decimal
        /// </summary>
        /// <param name="numero">parametro a convertir</param>
        /// <returns>Devuelve el numero decimal o un mensaje de error</returns>
        public string BinarioDecimal(string numero)
        {
            string numeroAux = "Valor invalido";
            double numASumar = 0;

            if (EsBinario(numero))
            {
                for (int i = 0; i < numero.Length; i++)
                {

                    if (numero[i] == '1')
                    {
                        double len = numero.Length - 1 - i;
                        numASumar += Math.Pow(2, len);
                    }
                }

                numeroAux = numASumar.ToString();
            }

            return numeroAux;

        }

        /// <summary>
        /// Convierte un numero decimal a binario 
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Devuelve un numero binario, en caso de ser posible. Caso contrario retornará "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            string numeroBinario = string.Empty;
            int numeroAbsoluto;
            int calculador;
            numeroAbsoluto = Math.Abs((int)numero);

            if (numeroAbsoluto == 0)
            {
                numeroBinario = "0";
            }
            else
            {
                while (numeroAbsoluto > 0)
                {
                    calculador = numeroAbsoluto % 2;
                    numeroAbsoluto /= 2;
                    numeroBinario = calculador.ToString() + numeroBinario;
                }
            }

            return numeroBinario;
        }

        /// <summary>
        /// Convierte un numero decimal a binario 
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Devuelve un numero binario, en caso de ser posible. Caso contrario retornará "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            double numeroVerificado;
            double.TryParse(numero, out numeroVerificado);

            return DecimalBinario(numeroVerificado);
        }

        //Sobrecargas de operadores
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return Double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
