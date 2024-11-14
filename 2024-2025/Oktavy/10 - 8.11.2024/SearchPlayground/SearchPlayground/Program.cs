using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPlayground
{
    internal class Program
    {
        static int LinearSearch(int[] array, int elementToSearch)
        {
            /*
             * TODO: naimplementuj lineární vyhledávání (nebo ho zkopíruj z ArrayPlayground z TODO 7)
             * Projdi for cyklem celé pole od začátku do konce (0 až array.Length - 1) a u každého prvku zkontroluj, jestli se nerovná hledanému prvku.
             * Pokud ano, vrať jeho index (Který se rovná i počtu prvků, které jsi prošel, než jsi požadované číslo našel.)
             */
            return -1;
        }

        static int BinarySearch(int[] array, int elementToSearch)
        {
            /*
             * TODO: naimplementuj binární vyhledávání
             * Budeš potřebovat několik proměnných:
             * - jednu na index dolního okraje intervalu
             * - jednu na index horního okraje intervalu
             * - jednu na index prostředku intervalu
             * Na začátku nastav dolní okraj na 0 (první prvek pole) a horní okraj na array.Length - 1 (poslední prvek pole)
             * Potom v cyklu (dokud se horní a dolní index nepotkají) spočítej prostředek, zkontroluj, jestli na prostředním indexu není hledaný prvek
             * a případně uprav horní nebo dolní okraj podle toho, jestli je prvek na prostředním indexu větší, nebo menší, než hledaný prvek.
             * 
             * Až ti bude binary search fungovat, přidej k němu proměnnou, která ti bude počítat, kolikrát jsi musel rozdělit interval, než jsi prvek našel
             * a před returnem ho vypiš uživateli do konzole.
             */
            return -1;
        }

        static int BinarySearchRecursive(int[] array, int elementToSearch, int lower, int upper)
        {
            //TODO naimplementuj binární vyhledávání rekurzivním způsobem (Zamysli se nad parametry, které tato funkce přijímá vzpomeň si na přístup Rozděl a Panuj.)
            return -1;
        }

        //Naplní pole náhodnými rostoucími čísly.
        static void FillArray(int[] array)
        {
            Random rng = new Random();
            int lastNumber = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = lastNumber + rng.Next(1, 10);
                lastNumber = array[i];
            }
        }

        //Vypíše pole do konzole
        static void WriteArrayToConsole(int[] array, string arrayName)
        {
            Console.Write(arrayName + " = [");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }

        //Zavolá postupně lineární, binární a rekurzivní binární vyhledávání pro zadané pole (a vypíše jeho jméno pro přehlednost)
        static void SearchArray(int[] array, string arrayName)
        {
            Random rng = new Random();
            int randomElement = array[rng.Next(array.Length)];
            Console.WriteLine($"Prohledávám {arrayName} a hledám v něm prvek {randomElement}:");
            int index;

            index = LinearSearch(array, randomElement);
            Console.WriteLine($"    Lineární vyhledávání našlo prvek {randomElement} na indexu {index}");

            index = BinarySearch(array, randomElement);
            Console.WriteLine($"    Binární vyhleádávání našlo prvek {randomElement} na indexu {index}");

            index = BinarySearchRecursive(array, randomElement, 0, array.Length - 1);
            Console.WriteLine($"    Rekurzivní binární vyhledávání našlo prvek {randomElement} na indexu {index}");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] smallArray = new int[10];
            FillArray(smallArray);

            int[] mediumArray = new int[1000];
            FillArray(mediumArray);

            int[] largeArray = new int[1000000];
            FillArray(largeArray);

            WriteArrayToConsole(smallArray, "Malé pole");
            SearchArray(smallArray, "Malé pole");

            //WriteArrayToConsole(mediumArray, "Střední pole");
            SearchArray(mediumArray, "Střední pole");

            //WriteArrayToConsole(largeArray, "Velké pole");
            SearchArray(largeArray, "Velké pole");

            Console.ReadKey();
        }
    }
}
