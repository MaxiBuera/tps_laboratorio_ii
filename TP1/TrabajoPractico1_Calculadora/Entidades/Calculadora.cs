using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// valida el operador recibido por parametro
        /// </summary>
        /// <param name="operador">operador</param>
        /// <returns>retorna el operador. Si el operador es vacio devuelve +</returns>
        private static char ValidarOperador(char operador) {

            switch (operador)
            {
                case '+':
                    return '+';
                case '-':
                    return '-';
                case '*':
                    return '*';
                case '/':
                    return '/';
                default:
                    return '+';
            }
        }

        /// <summary>
        /// se encarga de realizar la operación con los parámetros que recibe
        /// </summary>
        /// <param name="num1">numero1 de tipo Operando</param>
        /// <param name="num2">numero2 de tipo Operando</param>
        /// <param name="operador">el operador aritmético en tipo Char</param>
        /// <returns>devuelve el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValidado;
            operadorValidado = ValidarOperador(operador);

            switch (operadorValidado)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    return num1 + num2;
            }

        }

    }
}
