using System;

namespace Entidades
{
    public static class Calculadora
    {

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
