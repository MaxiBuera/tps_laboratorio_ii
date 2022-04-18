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

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string numero)
        {
            this.numero = ValidarOperando(numero);
        }

        public Operando() : this(0)
        {

        }

        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        public double ValidarOperando(string strNumero)
        {
            double oprandoValido;

            if (double.TryParse(strNumero, out oprandoValido))
            {
                return oprandoValido;
            }
            else
            {
                return 0;
            }
        }

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

        public string BinarioDecimal(string numero)
        {
            string retorno = "Valor inválido";
            double numASumar = 0;

            if (EsBinario(numero))
            {
                for (int i = 0; i < numero.Length; i++)
                {

                    if (numero[i] == '1')
                    {
                        double len = numero.Length - 1 - i;
                        numASumar += Math.Pow(2, len);//los voy sumando here
                    }
                }

                retorno = numASumar.ToString();
            }

            return retorno;

        }
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
        public string DecimalBinario(string numero)
        {
            double numeroVerificado;
            double.TryParse(numero, out numeroVerificado);

            return DecimalBinario(numeroVerificado);
        }

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
