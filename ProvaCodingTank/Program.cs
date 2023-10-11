/*
1 - Escreva um programa que faça a leitura de 5 valores Inteiros do usuário.
    Em seguida, o programa deve exibir no console a informação de quantos dos valores digitados são pares,
    quantos dos valores digitados são ímpares, quantos deles são positivos e, por fim, quantos são negativos.
    Cada uma das informações deve ser escrita em uma linha diferente. - Done


2 - Escreva um programa que calcule e escreva a multiplicação e a divisão inteira de dois números inteiros, N1 por N2, que devem ser lidos do teclado.
É importante observar que a máquina que irá executar este programa é capaz de efetuar apenas duas operações matemáticas: adição e subtração.
ou seja, você não poderá usar os operadores de multiplicação, divisão, módulo etc. bem como truncamentos.


3 - Escreva um programa que recebe como entrada uma frase do usuário.
Como saída o programa deve exibir no console as seguintes informações: quantas palavras são maiúsculas,
quantas palavras são minúsculas, quantas palavras iniciam com letra maiúscula,
quantas palavras iniciam com letra minúscula e a quantidade de palavras.
*/


using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProvaCodingTank
{
    internal class Program
    {
        public static void CincoInts()
        {
            Console.WriteLine("Escreva 5 valores, todos `integers`");

            // Inserção de variaveis
            int[] numsArray = new int[5]; 
            string[] input = Regex.Split(Console.ReadLine(), @"[, ]+");
            int numPares = 0;
            int numImpares = 0;
            int numPositivos = 0;
            int numNegativos = 0;
            //Excessão 
            if (input.Length != 5 )
            {
                Console.WriteLine("O input deve possuir 5 digitos.");
                return;
            }

            
            // Excessão e Calculo
            for (int i = 0; i < 5; i++)
            {
                if (!int.TryParse(input[i], out int inputInt))
                {
                    Console.WriteLine("O input não é somente de `integers`");
                    return;
                }
                numsArray[i] = inputInt;
                
                if (inputInt == 0) //Ignorar caso o input for zero
                {
                    continue;
                }
                
                int parImpar = (inputInt % 2 == 0) ? numPares++ : numImpares++; // Pares, impares
                int posNeg = (inputInt > 0) ? numPositivos++ : numNegativos++; // Positivos, Negativos
            }
            
            //Resultados:
            Console.WriteLine($@"Quantos são pares: {numPares}
Quantos são impares: {numImpares}
Quantos são positivos: {numPositivos}
Quantos são negativos: {numNegativos}");

            Console.ReadKey();
        }
        
        public static void MultDivNums()
        {
            Console.WriteLine("Escreva o primeiro inteiro");
            
            // Inputs e Excessões
            string inputUm = Console.ReadLine();
            if (!int.TryParse(inputUm, out int numUm))
            {
                Console.WriteLine("Por favor, insira um valor `int`");
                return;
            }
            Console.WriteLine("Escreva o segundo inteiro");

            string inputDois = Console.ReadLine();
            if (!int.TryParse(Console.ReadLine(), out int numDois))
            {
                Console.WriteLine("Por favor, insira um valor `int`");
                return;
            }
            
            // Caso de zero
            if (numUm == 0 && numDois == 0)
            {
                Console.WriteLine("Ambos valores não podem ser zero");
                return;
            }

            // Multiplicação e Divisão
            int mult = 0;
            int div = 0;

            if (numDois != 0)
            {
                int absNum2 = (numDois > 0) ? numDois : -numDois;

                while (numUm >= absNum2)
                {
                    numUm -= absNum2;
                    div++;
                }
                mult = (numDois > 0) ? numUm : -numUm;
                Console.WriteLine($"Multiplicação: {mult}" +
                                  $"Divisão Inteira: {div}");
            }
        }


        
        public static void FraseLeitura()
        {
            Console.WriteLine("Escreva uma frase");

            // Inserção de variaveis
            string[] input = Console.ReadLine().Split();
            int palMin = 0;
            int palMaiusc = 0;
            int palInicMaiusc = 0;
            int palInicMin = 0;
            int quant = input.Length;

            // Calculos
            // Poderia ser um switch
            foreach (var palavra in input)
            {
                if (string.IsNullOrWhiteSpace(palavra) || int.TryParse(palavra, out _))
                {
                    quant--;
                    continue;
                }
                if (palavra.ToUpper() == palavra)
                {
                    palMaiusc++;
                    continue;
                }

                if (palavra.ToLower() == palavra)
                {
                    palMin++;
                    continue;
                }

                if (palavra.Substring(0, 1) == palavra.Substring(0, 1).ToUpper())
                {
                    palInicMaiusc++;
                }
                if (palavra.Substring(0, 1) == palavra.Substring(0, 1).ToLower())
                {
                    palInicMin++;
                }
            }
                        
            //Resultados:
            Console.WriteLine($@"Quantas são maiusculas: {palMaiusc}
Quantos são minúsculas: {palMin}
Quantas são de inicial maiuscula: {palInicMaiusc}
Quantas são de inicial minuscula: {palInicMin}
Quantidade de palavras : {quant}");
            Console.ReadKey();
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine($@"Olá, escolha qual programa você quer testar da prova.
1 - Contador de 5 `ints`.
2 - Divisor e Multiplicador.
3 - Contador de Palavras");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.Clear();
                    CincoInts();
                    break;
                }
                case "2":
                {
                    Console.Clear();
                    MultDivNums();
                    break;
                }
                case "3":
                {
                    Console.Clear();
                    FraseLeitura();
                    break;
                }
                default:
                {
                    Console.Clear();
                    Console.WriteLine("Insira um numero da sequencia.");
                    break;
                }
            }
        }
    }
}