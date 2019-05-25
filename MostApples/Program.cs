using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostApples
{ 


    class Program
    {

       
        static void Main(string[] args)
        {
            
            int[,] matrix = new int[3,4] {   {0,1,2,3}, 
                                             {4,2,6,4},
                                             {3,2,1,0}
                                                      };
            string[,] path = new string[matrix.GetLength(0), matrix.GetLength(1)];

            int y = 0;
            int i = 2;
            int x = 2;
            do
            {
                for(int j=y;j<x+1;j++)
                {


                    if (i - j + y == 0)
                    {
                        matrix[i - j + y, j] += matrix[i - j + y, j - 1];
                        path[i - j + y, j] = path[i - j + y, j - 1] + $"-> [{i - j + y},{j - 1}] ";
                    }
                    else if (j == 0)
                    {
                        matrix[i - j + y, j] += matrix[i - j + y - 1, j];
                        path[i - j + y, j] = path[i - j + y - 1, j] + $"-> [{i - j + y-1},{j}] ";
                    }
                    else
                    {
                        if (matrix[i - j + y, j - 1] >= matrix[i - j + y - 1, j])
                        {
                            matrix[i - j + y, j] += matrix[i - j + y, j - 1];
                            path[i - j + y, j] = path[i - j + y, j - 1] + $"-> [{i - j + y},{j - 1}] ";
                        }
                        else
                        {
                            matrix[i - j + y, j] += matrix[i - j + y - 1, j];
                            path[i - j + y, j] = path[i - j + y - 1, j] + $"-> [{i - j + y - 1},{j}] ";
                        }

                    }
            
                }

                if (i < matrix.GetLength(0)-1) i++;
                else y++;
                if(x< matrix.GetLength(1) - 1) x++;
            } while (i+y!= matrix.GetLength(0)+ matrix.GetLength(1)-1);


            Console.WriteLine($"The most apple you can collect is {matrix[matrix.GetLength(0)-1, matrix.GetLength(1)-1]}");
            Console.WriteLine($"The path to collecting them is : [0,0] {path[matrix.GetLength(0)-1, matrix.GetLength(1)-1]}-> [{matrix.GetLength(0) - 1},{matrix.GetLength(1) - 1}]");


            Console.ReadLine();
        }
    }
}