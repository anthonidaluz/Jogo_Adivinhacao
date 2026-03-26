using System;
using System.Security.Cryptography;

namespace Jogo_Adivinhacao
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();

            
            bool continuarJogo = true;

            while (continuarJogo == true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("JOGO DE ADIVINHAÇÃO");
                Console.WriteLine("1 - Fácil (10 Tentativas)");
                Console.WriteLine("2 - Médio (5 Tentativas)");
                Console.WriteLine("3 - Difícil (3 Tentativas)");
                Console.WriteLine("===========================================");

                Console.Write("Escolha o nível de dificuldade: ");
                int dificuldade = int.Parse(Console.ReadLine());

                int numAleatorio;
                int tentativasMaximas;
                

                switch (dificuldade)
                {
                    case 1:
                        numAleatorio = RandomNumberGenerator.GetInt32(1, 21);
                        Console.WriteLine("Você escolheu o nível Fácil! Você tem 10 tentativas para adivinhar o número secreto (1 - 20).");
                        tentativasMaximas = 10;
                        break;
                    case 2:
                        numAleatorio = RandomNumberGenerator.GetInt32(1, 51);
                        Console.WriteLine("Você escolheu o nível Médio! Você tem 5 tentativas para adivinhar o número secreto (1 - 50).");
                        tentativasMaximas = 5;
                        break;
                    case 3:
                        numAleatorio = RandomNumberGenerator.GetInt32(1, 101);
                        Console.WriteLine("Você escolheu o nível Difícil! Você tem 3 tentativas para adivinhar o número secreto (1 - 100).");
                        tentativasMaximas = 3;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Por favor, digite ENTER para continuar...");
                        Console.ReadLine();
                        continue;
                }

                int[] numerosDigitados = new int[tentativasMaximas];
                int contadorNumerosDigitados = 0;
                int pontuacao = 1000;

                for (int tentativaAtual = 1; tentativaAtual <= tentativasMaximas; tentativaAtual++)
                {
                    Console.Clear();
                    Console.WriteLine("===========================================");
                    Console.WriteLine("JOGO DE ADIVINHAÇÃO");
                    Console.WriteLine($"Tentativa {tentativaAtual} de {tentativasMaximas}");
                    Console.WriteLine("===========================================");


                    Console.Write("Informe um Número: ");
                    int numero = int.Parse(Console.ReadLine());
                    
                    bool numeroRepetido = false;
                    for (int indiceAtual = 0; indiceAtual < numerosDigitados.Length; indiceAtual++)
                    {
                        if (numerosDigitados[indiceAtual] == numero)
                        {
                            numeroRepetido = true;
                            break;
                        }
                    }

                    if(numeroRepetido == true)
                    {
                        Console.WriteLine("Número já foi informado.. Tente novamente!");
                        Console.WriteLine("Digite ENTER para continuar..");
                        Console.ReadLine();
                        tentativaAtual--;
                        continue;
                    }

                    if (contadorNumerosDigitados < numerosDigitados.Length)
                    {
                        numerosDigitados[contadorNumerosDigitados] = numero;
                        contadorNumerosDigitados++;
                    }
                    else
                    {
                        numerosDigitados = new int[tentativasMaximas];
                        contadorNumerosDigitados = 0;

                        numerosDigitados[contadorNumerosDigitados] = numero;
                        contadorNumerosDigitados++;
                    }

                    if (numero == numAleatorio)
                    {
                        Console.WriteLine($"PARABÉNS! VOCÊ ACERTOU O NÚMERO ERA: {numAleatorio}");
                        break;
                    }
                    else if (numero > numAleatorio)
                    {
                        Console.WriteLine("O número digitado foi maior que o número secreto! ");
                    }
                    else
                    {
                        Console.WriteLine("O número digitado foi menor que o número secreto! ");
                    }

                    int diferencaNumerica = Math.Abs(numAleatorio - numero);

                    if(diferencaNumerica >= 10)
                    {
                        pontuacao -= 100;
                    }
                    else if(diferencaNumerica >= 5)
                    {
                        pontuacao -= 50;
                    }
                    else
                    {
                        pontuacao -= 20;
                    }

                    if(tentativaAtual == tentativasMaximas)
                    {
                        Console.WriteLine($"Você usou todas as tentativas. O Número era {numAleatorio}");
                        break;
                    }

                    Console.WriteLine("Sua pontuação é: " + pontuacao);
                    Console.WriteLine("------------------------------------");
                    Console.Write("Digite ENTER para continuar...");
                    Console.ReadLine();


                }

                Console.WriteLine();
                Console.WriteLine("Deseja Continuar? (S/N)");
                string? continuar = Console.ReadLine();
                if (continuar?.ToUpper() != "S")
                {
                    break;
                }
            }
        }
    }
}
