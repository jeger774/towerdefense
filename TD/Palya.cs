using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Osveny
    {
        /* Az ösvény "tárolása" egy két dimenziós byte tömbben történik,
           a .map fájlban az ösvény karakteres formában "le van rajzolva"
           itt ezt elemezzük és minden karakterhez egy számot rendelünk. 
           Getter és setter metódussal változtatjuk később futás közben .*/
        private static byte[,] osveny;
        public static int[] kezdo;
        public static byte[,] GetOsveny()
        {
            return osveny;
        }
        public static void SetOsveny(string[] input)
        {
            kezdo = new int[2];
            osveny = new byte[input.Length, input[0].Length];
            for (int i = 0; i < osveny.GetLength(0); i++)
            {
                for (int j = 0; j < osveny.GetLength(1); j++)
                {
                    switch (input[i][j])
                    {
                        case ' ':
                            osveny[i, j] = 0;
                            break;
                        case '-':
                            osveny[i, j] = 1;
                            break;
                        case 'S':
                            osveny[i, j] = 2;
                            kezdo[0] = i;
                            kezdo[1] = j;
                            break;
                        case 'E':
                            osveny[i, j] = 3;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static void SetOsveny(byte[,] input)
        {
            osveny = input;
        }
        // A kiírás a korábban beállított szám - karakter hozzárendelések alapján történik
        public static void Osveny_Kiir()
        {
            Console.Clear();
            for (int i = 0; i < osveny.GetLength(0); i++)
            {
                for (int j = 0; j < osveny.GetLength(1); j++)
                {
                    switch (osveny[i,j])
                    {
                        case 0:
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("-");
                            break;
                        case 2:
                            Console.Write("S");
                            break;
                        case 3:
                            Console.Write("E");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("M");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
