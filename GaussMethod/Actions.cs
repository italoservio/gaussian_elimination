using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussMethod
{
    class Actions
    {
        // Flag 0 = Sistema possível e determinado
        // Flag 1 = Sistema possível e indeterminado
        // Flag 2 = Sistema impossível
        public static int Flag = 0;
          

        // Definir Tamanho da Matriz
        public static int[] inputSize()
        {
            int lines = 0, cols = 0;
            int[] arraySize = new int[2];
            bool lValidType;

            // Linhas
            do
            {
                Console.Write("                   Insira a quantidade de Equações:");
                try // Verificando se tipo do dado inserido é possivel converter em Double
                {
                    lines = Convert.ToInt32(Console.ReadLine());

                    if (lines > 1)
                    {
                        lValidType = true;
                    }
                    else
                    {

                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ERROR: Quantidade de equações inválida! (Deve possuir ao menos 2 equações)");
                        Console.ResetColor();                        

                        lValidType = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("	        ERROR: Valor inserido não é de um tipo válido!            ");
                    Console.ResetColor();

                    lValidType = false;
                }

            } while (!lValidType);

            // Colunas
            do
            {
                
                Console.Write("                   Insira a quantidade de Variáveis:");
                try // Verificando se tipo do dado inserido é possivel converter em Double
                {
                    cols = Convert.ToInt32(Console.ReadLine());

                    if (cols > 1)
                    {
                        lValidType = true;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ERROR: Quantidade de variáveis inválida! (Devem possuir mais que 2 variáveis)");
                        Console.ResetColor();

                        lValidType = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("	        ERROR: Valor inserido não é de um tipo válido!            ");
                    Console.ResetColor();

                    lValidType = false;
                }

            } while (!lValidType);

            arraySize[0] = lines;
            arraySize[1] = cols + 1; // Mais 1 pois trata-se de uma matriz extendida e deve conter os termos independentes.
            return arraySize;
        }


        // Popular Matriz
        public static double[,] inputValues(int pLines, int pCols)
        {
            double[,] lMatGauss = new double[pLines, pCols]; //Criando a Matriz   
            bool lValidType = false;

            // Preencher matriz dos coeficientes
            for (int i = 0; i < lMatGauss.GetLength(0); i++)
            {
                for (int j = 0; j < lMatGauss.GetLength(1) - 1; j++)
                {
                    // Preencher matriz dos coeficientes
                    do
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("	       Agora vamos preencher os campos dos COEFICIENTES:          ");
                        Console.ResetColor();

                        Actions.printMat(lMatGauss);
                        Console.Write("\nInsira um valor para a posição [{0},{1}]: ", i, j);

                        try // Verificando se tipo do dado inserido é possivel converter em Double
                        {
                            lMatGauss[i, j] = Convert.ToDouble(Console.ReadLine());

                            Console.Clear();

                            lValidType = true;
                        }
                        catch
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("	        ERROR: Valor inserido não é de um tipo válido!            ");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.Clear();

                            lValidType = false;
                        }

                    } while (!lValidType);
                }
            }

            // Preencher matriz dos termos independentes
            for (int i = 0; i < lMatGauss.GetLength(0); i++)
            {
                for (int j = 0; j < lMatGauss.GetLength(1); j++)
                {
                    if (j == lMatGauss.GetLength(1) - 1)
                    {
                        // Preencher matriz dos termos independentes
                        do
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("	   Agora vamos preencher os campos dos TERMOS INDEPENDENTES:      ");
                            Console.ResetColor();

                            Actions.printMat(lMatGauss);
                            Console.Write("\nInsira um valor para o termo na posição [{0},{1}]: ", i, j);

                            try // Verificando se tipo do dado inserido é possivel converter em Double
                            {
                                lMatGauss[i, j] = Convert.ToDouble(Console.ReadLine());
                                Console.Clear();

                                lValidType = true;
                            }
                            catch
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("	        ERROR: Valor inserido não é de um tipo válido!            ");
                                Console.ResetColor();
                                Console.ReadKey();
                                Console.Clear();

                                lValidType = false;
                            }

                        } while (!lValidType);
                    }
                }
            }

            Console.Clear();
            return lMatGauss;
        }


        // Imprimir Matriz
        public static void printMat(double[,] pMat)
        {
            string lPrint = "";

            for (int i = 0; i < pMat.GetLength(0); i++)
            {
                lPrint += "\n";

                for (int j = 0; j < pMat.GetLength(1); j++)
                {
                    lPrint += " [" + pMat[i, j] + "]";
                }
            }
            Console.WriteLine(lPrint);
        }


        // Imprimir Vetor
        public static void printVec(double[] pVec)
        {
            string lPrint = "";

            for (int i = 0; i < pVec.Length; i++)
            {
                lPrint += " [" + pVec[i] + "]";
            }
            Console.WriteLine(lPrint);
        }


        // Extrai linha da matriz e retorna vetor
        public static double[] extractLine(double[,] pMat, int pLine)
        {
            double[] lVec = new double[pMat.GetLength(1)];  // Vetor onde ficarão os elementos da linha

            for (int j = 0; j < pMat.GetLength(1); j++)
            {
                lVec[j] = pMat[pLine, j];
            }
            return lVec;
        }


        // Troca as linhas quando a posição do pivot = 0 ('i' representa a coluna do pivot)
        // Verifica a matriz, e atualiza a flag
        public static double[,] swapLines(double[,] pMat, int i)
        {
            if (pMat[i, i] == 0)  // Caso o elemento pivot for zero
            {
                int lNewLine, lLinhaAtual = i;

                for (lNewLine = 1; lNewLine < pMat.GetLength(0); lNewLine++) // Percorrerá as linhas em busca de um pivot != 0
                {
                    try
                    {
                        if (pMat[i + lNewLine, i] != 0) // Se na proxima linha o valor for != 0
                        {
                            break;
                        }
                    }
                    catch // Não tem próxima linha ('i' é a última linha) ou não tem elemento para ser pivot 
                    {
                        double[] lVetStatus = extractLine(pMat, i); // Pegue a linha atual
                        int cont = 0;

                        foreach (int item in lVetStatus) // Vamos verificar os itens
                        {
                            if (item != 0)
                            {
                                cont++;
                            }
                        }

                        if (cont > 0) // Encontrou um elemento != de zero na última linha
                        {
                            Actions.Flag = 2;
                            return pMat;
                        }
                        else        // A última linha zerou completamente
                        {
                            Actions.Flag = 1;
                            return pMat;
                        }
                    }
                }

                if ((i + lNewLine) == pMat.GetLength(0)) // Se tiver percorrido todas as linhas e ainda e não encontrar elemento != 0         
                {
                    Actions.Flag = 1; // Sistema possível e indeterminado 
                    return pMat;
                }
                else
                {
                    for (int k = 0; k <= pMat.GetLength(0); k++)  // Vamos trocar as linhas
                    {
                        double lTemp = pMat[lLinhaAtual, k]; // Guardando a linha atual em 'lTemp'
                        pMat[lLinhaAtual, k] = pMat[lLinhaAtual + lNewLine, k]; // Linha atual recebe a linha que possui pivot != 0
                        pMat[lLinhaAtual + lNewLine, k] = lTemp; // Linha que possui pivot != 0 recebe linha atual ('lTemp')
                    }
                }
            }

            return pMat;
        }


        // Recebe a matriz e uma linha (Pois toda a linha é afetada) retorna matriz com a linha pivoteada
        public static double[,] pivot(double[,] pMat, int i) //'i' = linha
        {
            double lPivot = pMat[i, i]; // Pivot é o elemento da diagonal principal            
            double[] lVec = Actions.extractLine(pMat, i);

            for (int j = 0; j < lVec.Length; j++)
            {
                lVec[j] = (1 / lPivot) * lVec[j];     // Transformando o pivot em 1 (Afeta toda a linha)                
                lVec[j] = Math.Round(lVec[j], 2);   // Aredondando valores para 2 casas decimais
            }

            for (int k = 0; k < lVec.Length; k++)
            {
                pMat[i, k] = lVec[k]; // Passando os valores da linha pivoteada para a matriz
            }

            return pMat;
        }


        // Esvaziar a coluna do pivot
        public static double[,] emptyColumn(double[,] pMat, int i)
        {
            double[] lVecPivot = Actions.extractLine(pMat, i);
            double lPivot = pMat[i, i];
            double[,] lTempMat = pMat;            


            for (int lLines = 0; lLines < pMat.GetLength(0); lLines++) // For que percorrerá as linhas e as transformará em 0 os elementos na coluna do pivot
            {
                if (lLines != i) // Pois a linha do pivot não deve ser alterada
                {
                    double[] lVetInicial = Actions.extractLine(pMat, lLines);   // Salvando a linha inicial
                    double[] lVetTemp = Actions.extractLine(pMat, lLines);      // Linha que sofrerá as alterações

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n                 ----x----                  ");
                    Console.Write("\nLinha do Pivô: ");
                    Console.ResetColor();
                    Actions.printVec(lVecPivot);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Linha a ser alterada: ");
                    Console.ResetColor();
                    Actions.printVec(lVetInicial);
                    

                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n                 Cálculos:                  \n");
                    Console.ResetColor();

                    for (int lColumns = 0; lColumns < pMat.GetLength(1); lColumns++)
                    {
                        // Cálculo: Lx(Columns) -> Lx(Columns) + (-(Lx(ColumnInicial) * Lpivot(Column))
                        Console.WriteLine(lVetTemp[lColumns] + " = " + lVetTemp[lColumns] + "+(-(" + lVetInicial[i] + ")*" + lVecPivot[lColumns] + ")");

                        lVetTemp[lColumns] = lVetTemp[lColumns] + (-(lVetInicial[i]) * lVecPivot[lColumns]);
                    }
                                        
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n             Linha após cálculo:            \n");
                    Console.ResetColor();
                    Actions.printVec(lVetTemp); // Imprime a linha alterada  

                    for (int k = 0; k < lVetTemp.Length; k++)
                    {                        
                        pMat[lLines, k] = lVetTemp[k]; // Passando os valores da linha alterada para a matriz                        
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n             Situação da matriz:            ");
            Console.ResetColor();
            printMat(pMat);
            Console.ReadKey();
            return pMat;
        }


        // Responsável por trazer a forma escalonada reduzida
        public static double[,] reduceMat(double[,] pMat)
        {
            // Percorre as linhas da matriz
            for (int i = 0; i < pMat.GetLength(0); i++)
            {

                pMat = Actions.swapLines(pMat, i);
                if (Actions.Flag == 0) // Flag 0 = Tudo OK (Sistema possível e determinável até agora)
                {                    
                    pMat = Actions.pivot(pMat, i);
                    pMat = Actions.emptyColumn(pMat, i);
                }
                else
                {
                    return pMat;
                }
            }
            return pMat;
        }


        // Imprime os resultados
        public static void printResults(double[,] pMat)
        {
            string results = "S = {";
            for (int i = 0; i < pMat.GetLength(0); i++)
            {
                results += " " + Math.Round(pMat[i, pMat.GetLength(1) - 1], 1) + ",";
            }
            results = results.Substring(0, results.Length - 1);
            results += " }";
            
            Console.WriteLine("\n" + results);
        }
    }
}
