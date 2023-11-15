using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] my2DArray = new int[5, 5];
            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
                {
                    my2DArray[i, j] = i * 5 + j + 1;
                    //Console.Write(my2DArray[i, j] + " ");
                    Console.Write($"{my2DArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 1;
            for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
            {
                Console.Write(my2DArray[nRow,j] + " ");
            }
            Console.WriteLine("\n");

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 3;
            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                Console.Write(my2DArray[i,nColumn] + " ");
            }
            Console.WriteLine("\n");

            //BONUS TODO: HLAVNÍ DIAGONÁLA
            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky/sloupce, je to jedno
            {
                Console.Write(my2DArray[i, i] + " ");
            }
            Console.WriteLine("\n");

            //BONUS TODO 2: VEDLEJŠÍ DIAGONÁLA (prvky [4,0],[3,1],[2,2],[1,3],[0,4])
            // i - 4, 3, 2, 1, 0
            // j - 0, 1, 2, 3, 4
            //int second = 0;
            for (int i = my2DArray.GetLength(0) - 1; i >= 0; i--) //pres radky/sloupce, je to jedno
            {
                Console.Write(my2DArray[i, my2DArray.GetLength(0) - 1 - i] + " ");
                //second++;
            }
            Console.WriteLine("\n");

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý.
            int xFirst = 0;
            int yFirst = 0;

            int xSecond = 4;
            int ySecond = 4;

            //int temporary = my2DArray[xFirst, yFirst];
            //my2DArray[xFirst, yFirst] = my2DArray[xSecond, ySecond];
            //my2DArray[xSecond, ySecond] = temporary;

            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{my2DArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
            {
                //int temp = my2DArray[nRowSwap, j];
                //my2DArray[nRowSwap, j] = my2DArray[mRowSwap, j];
                //my2DArray[mRowSwap, j] = temp;
            }

            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{my2DArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;
            for (int i = 0; i < my2DArray.GetLength(1); i++) //pres sloupce
            {
                //int temp = my2DArray[i, nColSwap];
                //my2DArray[i, nColSwap] = my2DArray[i, mColSwap];
                //my2DArray[i, mColSwap] = temp;
            }

            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{my2DArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 0; i < my2DArray.GetLength(0) / 2; i++) //pres radky/sloupce, je to jedno
            {
                int temp = my2DArray[i, i];
                int coordToSwap = my2DArray.GetLength(0) - 1 - i;
                my2DArray[i, i] = my2DArray[coordToSwap, coordToSwap];
                my2DArray[coordToSwap, coordToSwap] = temp;
            }

            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{my2DArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = my2DArray.GetLength(0) - 1; i > my2DArray.GetLength(0) / 2; i--) //pres radky/sloupce, je to jedno
            {
                int j = my2DArray.GetLength(0) - 1 - i;
                int temp = my2DArray[i, j];
                my2DArray[i, j] = my2DArray[j, i];
                my2DArray[j, i] = temp;
            }

            for (int i = 0; i < my2DArray.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{my2DArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
