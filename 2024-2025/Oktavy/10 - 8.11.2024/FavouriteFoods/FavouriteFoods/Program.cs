using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavouriteFoods
{
    internal class Program
    {
        static void PrintList(List<string> list)
        {
            if (list.Count > 0)
            {
                Console.Write("Your list of favourite foods: ");
                for (int i = 0; i < list.Count - 1; i++)
                {
                    Console.Write(list[i] + ", ");
                }
                Console.Write(list[list.Count - 1]);
                Console.Write("\n");
            }
            else Console.WriteLine("Your list of favourite foods is empty :(");
        }

        static void AddFood(List<string> list, string food)
        {
            if (!list.Contains(food)) list.Add(food);
            else Console.WriteLine("This food is already in your list.");
        }

        static void RemoveFood(List<string> list, string food)
        {
            if (list.Contains(food)) list.Remove(food);
            else Console.WriteLine("This food is already not in your list.");
        }

        static void EraseList(List<string> list)
        {
            if (list.Count > 0) list.Clear();
            else Console.WriteLine("Your list is already empty.");
        }

        static void Main(string[] args)
        {
            List<string> favouriteFoods = new List<string>();

            string userInput;

            Console.WriteLine("Let's create a list of your favourite foods!");

            while (true)
            {
                Console.WriteLine("Choose your action:\n" +
                    "\"Add\" - Add a new food to your list\n" +
                    "\"Remove\" - Remove a specific food from your list\n" +
                    "\"Erase\" - Remove every food from your list\n" +
                    "\"Quit\" - Quit program");

                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "add":
                        Console.Write("Write your new favourite food: ");
                        AddFood(favouriteFoods, Console.ReadLine().ToLower());
                        break;
                    case "remove":
                        Console.Write("Write the food you no longer like: ");
                        RemoveFood(favouriteFoods, Console.ReadLine().ToLower());
                        break;
                    case "erase":
                        Console.WriteLine("Erasing the whole list.");
                        EraseList(favouriteFoods);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Unknown command. Try again.");
                        break;
                }

                Console.Clear();
                PrintList(favouriteFoods);
                Console.WriteLine();
            }
        }
    }
}
