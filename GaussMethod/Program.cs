using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussMethod
{
    class Program
    {
        // Main
        static void Main(string[] args)
        {
            menu();
        }
        
        // Onde tudo começa ...
        static void menu()
        {
            do
            {
                Console.SetWindowSize(74, 30); // Define o tamanho do console
                Console.Clear();
                ConsoleKeyInfo lChoice;                
                Console.WriteLine();
                Console.WriteLine("                          Autor: Ítalo Sérvio ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine();
                Console.WriteLine("                        Método de Gauss Jordan");
                Console.WriteLine("                        ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                Console.ResetColor();
                Console.WriteLine("                  [ F1 ] -> Inserir sistema linear       ");

                lChoice = Console.ReadKey();

                switch (lChoice.Key)
                {
                    case ConsoleKey.F1:
                        Console.Clear();
                        int[] matSize = Actions.inputSize();                                // Inserir tamanho                
                        double[,] matGauss = Actions.inputValues(matSize[0], matSize[1]);   // Inserir valores

                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("       Agora temos a seguinte matriz:       ");
                        Console.ResetColor();

                        Actions.printMat(matGauss); // Exibe a matriz e aguarda uma tecla para iniciar

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\n   Pressione qualquer tecla para iniciar... ");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();

                        matGauss = Actions.reduceMat(matGauss);

                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\n                Concluído:                  ");
                        Console.ResetColor();

                        Actions.printMat(matGauss);

                        switch (Actions.Flag)
                        {
                            case 0:
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\n      Sistema possível e determinado!       ");                                
                                Console.ResetColor();
                                Actions.printResults(matGauss); // Imprime o conjunto solução
                                break;

                            case 1:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\n WARNING: Sistema possível e indeterminado! ");
                                Console.ResetColor();
                                break;

                            case 2:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n         ERROR: Sistema impossível!         ");
                                Console.ResetColor();
                                break;
                        }
                        Console.ReadKey();
                        Actions.Flag = 0; // Reiniciando a flag
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n                           Tecla inválida!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

            } while (true);
            
        }
    }
}
