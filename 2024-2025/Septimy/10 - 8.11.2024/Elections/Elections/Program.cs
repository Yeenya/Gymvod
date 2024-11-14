using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    internal class Program
    {
        static void PrintCandidates(Dictionary<string, int> elections)
        {
            Console.WriteLine("Current state of the elections:");
            if (elections.Count > 0)
            {
                foreach (KeyValuePair<string, int> electionSubject in elections)
                {
                    Console.WriteLine("    Candidate " + electionSubject.Key + " has " + electionSubject.Value + " votes.");
                }
            } else
            {
                Console.WriteLine("There are no candidates in the elections.");
            }
        }

        static void EvaluateElections(Dictionary<string, int> elections)
        {
            if (elections.Count == 0)
            {
                Console.WriteLine("There are no candidates, there is nothing to evaluate.");
                return;
            }
            int totalVotes = elections.Values.Sum();
            string winner = elections.Where(electionSubject => electionSubject.Value == elections.Values.Max()).First().Key;
            foreach (KeyValuePair<string, int> electionSubject in elections)
            {
                float percentVotes = (float)electionSubject.Value / totalVotes * 100;
                Console.WriteLine("Candidate " + electionSubject.Key + " has " + electionSubject.Value + " votes, which make " + percentVotes + " % of the total votes.");
            }
            Console.WriteLine("Winner of the elections is candidate " + winner + ".");
        }

        static void AddCandidate(Dictionary<string, int> elections, string candidate)
        {
            if (!elections.Keys.Contains(candidate)) elections[candidate] = 0;
            else Console.WriteLine("This candidate is already in the elections.");
        }

        static void RemoveCandidate(Dictionary<string, int> elections, string candidate)
        {
            if (elections.Keys.Contains(candidate)) elections.Remove(candidate);
            else Console.WriteLine("This candidate is already not present in the elections.");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void EraseElections(Dictionary<string, int> elections)
        {
            if (elections.Keys.Count > 0) elections.Clear();
            else Console.WriteLine("Elections are already without any candidate.");
            
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void SetVotes(Dictionary<string, int> elections, string candidate, uint votes)
        {
            Console.WriteLine("Setting votes for candidate " + candidate + " to " + votes + ".");
            elections[candidate] = Convert.ToInt32(votes);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void MakeRandomElections(Dictionary<string, int> elections)
        {
            if (elections.Count > 1)
            {
                Random rng = new Random();
                int votersCount = rng.Next(0, 10000000);
                Console.WriteLine("Making elections with " + votersCount + " voters.");
                int availableVotes = votersCount;
                foreach (string candidate in elections.Keys.ToList())
                {
                    int votesForCandidate = rng.Next(0, availableVotes);
                    elections[candidate] = votesForCandidate;
                    availableVotes -= votesForCandidate;
                }
                EvaluateElections(elections);
                Console.WriteLine(availableVotes + " voters (" + ((float)availableVotes / votersCount * 100) + " %) did not vote.");
            }
            else if (elections.Count == 1) Console.WriteLine("What is the point of making elections with only one candidate? We are not communists anymore :)");
            else Console.WriteLine("You have no candidates in the elections.");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> elections = new Dictionary<string, int>();

            string userInput;

            Console.WriteLine("Let's simulate elections!");

            while (true)
            {
                Console.WriteLine("Choose your action:\n" +
                    "\"Add\" - Add a new candidate\n" +
                    "\"Remove\" - Remove a specific candidate\n" +
                    "\"Erase\" - Remove every candidate\n" +
                    "\"Vote\" - Set the number of votes for a specific candidate\n" +
                    "\"Evaluate\" - Evaluate the current state of the elections\n" +
                    "\"Random vote\" - Make random elections with existing candidates\n" +
                    "\"Quit\" - Quit program");

                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "add":
                        Console.Write("Write the new candidate: ");
                        AddCandidate(elections, Console.ReadLine());
                        break;
                    case "remove":
                        Console.Write("Write the candidate who stepped away from the elections: ");
                        RemoveCandidate(elections, Console.ReadLine());
                        break;
                    case "erase":
                        Console.WriteLine("Erasing the whole elections.");
                        EraseElections(elections);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "vote":
                        Console.Write("Write the candidate who's votes you want to set: ");
                        string candidate = Console.ReadLine();
                        while (!elections.ContainsKey(candidate))
                        {
                            Console.Write("No such candidate exists. Write an existing candidate: ");
                            candidate = Console.ReadLine();
                        }

                        Console.Write("Write the number of votes you want to set: ");
                        uint votes;
                        while (!uint.TryParse(Console.ReadLine(), out votes))
                        {
                            Console.Write("Write a positive number, otherwise it does not make sense: ");
                        }

                        SetVotes(elections, candidate, votes);
                        break;
                    case "evaluate":
                        EvaluateElections(elections);
                        break;
                    case "random vote":
                        MakeRandomElections(elections);
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Unknown command. Try again.");
                        break;
                }

                Console.Clear();
                PrintCandidates(elections);
                Console.WriteLine();
            }
        }
    }
}
