using System;
using System.Collections.Generic;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace DFS
{
    internal class Program
    {
        /* INFO:
         * Dnes si vyzkoušíte prohledávání do hloubky v binárním stromu.
         * Minule jsme se bavili o tom, že existují "chytré" způsoby, jak se pohybovat v grafu.
         * Jedním z těchto způsobů je právě prohledávání do hloubky.
         * Pro jednoduchost si graf, se kterým budeme pracovat, trochu specifikujeme.
         * Budeme pracovat s tzv. binárním stromem.
         * 
         * O stromech jsme si říkali, že to jsou souvislé (z každého uzlu se dostanu do každého) grafy bez kružnic (Tedy bez cyklů - z nějakého uzlu se nedostanu do toho samého.)
         * Každý strom má tzv. kořen, což je uzel, ve kterém strom začíná, a nemá rodiče (V této implementaci je to proměnná root ve třídě BinaryTree.)
         * 
         * My budeme pracovat s binárním stromem, který je specifický tím, že každý jeho uzel má maximálně dva potomky (V našem případě vždy přesně dva.)
         * Představit si to prakticky lze třeba tak, že každý uzel je nějaká podmínka (if) a jeho levý potomek je případ, kdy je podmínka splněna,
         * a pravý potomek je případ, kdy podmínka splněna není.
         * Tento typ grafu používáme proto, že je velmi jednoduchý na nakreslení a intuitivně se v něm pohybuje. Prohledávání do hloubky, které budete dneska
         * implementovat, ovšem funguje na jakýchkoliv jiných grafech :)
         * 
         * Příklad binárního stromu hloubky 3:
         *                                   1      (kořen)
         *                                 /   \
         *                                2     3
         *                               / \   / \
         *                              4  5  6   7 (uzly 4, 5, 6 a 7 jsou listy)
         * 
         * Prohledávání do hloubky, neboli Depth First Search (DFS) jde co nejhlouběji nějakou cestou, kterou vybere, a jakmile dorazí na konec
         * (do tzv. listu, tedy koncového uzlu, který už nemá potomky), tak se vrátí o jeden uzel zpět, zvolí druhou cestu a v té opět zase jde co nejhlouběji
         * dokud nenarazí na hledaný uzel.
         * Vizualizaci a dodatečné vysvětlení najdete na těchto videích, podívejte se na ně: https://www.youtube.com/watch?v=Urx87-NMm6c a https://www.youtube.com/watch?v=h1RYvCfuoN4
         * 
         * V naší implementaci máme jednu instanci binárního stromu, kterému při inicializaci dáváme jeho hloubku (tedy kolik "vrstev" uzlů bude mít).
         * Při vypsání do konzole si všimněte, že graf je natočený o 90 stupňů proti směru hodinových ručiček, tedy že kořen je úplně vlevo a strom se "rozrůstá" doprava.
         * Hrany mezi uzly jsou naznačeny "/" a "\". Klidně si zkuste vygenerovat různě hluboké stromy, jen pozor, že stromy hlubší než cca 5 jsou už v konzoli blbě čitelné.
         * V daném binárním stromu chceme najít nějaký konkrétní uzel, respektive jeho index.
         * Tento index se vždy generuje náhodně, ovšem při debugování si ho klidně zafixujte na nějaké konkrétní číslo.
         * Hledaný uzel tady máme daný jeho indexem, tedy proměnnou targetNodeIndex. Podívejte se do toho, jak je napsaná třída Node pro jednotlivé uzly
         * a třída BinaryTree pro celý binární strom. Pracovat budete primárně se třídou Node.
         * Při implementaci DFS si budete muset v každém uzlu pamatovat které jeho potomky jste už navštívili a které ne.
         * Pro to se vám bude hodit druhý list Nodů visitedChildren, který je definovaný ve třídě Node.
         * Je dobré si uvědomit, že když najdete kýžený uzel, cesta k němu je jednoduše získatelná - stačí "probublat" rodiči až do kořene, a všechny uzly, kterými jste prošli,
         * dohromady tvoří cestu k hledanému uzlu.
         * Pozor ovšem na to, že cesta od hledaného uzlu do kořene je přesně opačná, než chceme, tedy od kořene do hledaného uzlu.
         * Jsem hodný a vypsání cesty do konzole jsem už na tohle ošetřil, tedy vámi nalezená cesta pozpátku se vypíše pozpátku, tedy popředu.
         * Je to matoucí, já vím, ale je to tak :D
         * 
         * Hodně štěstí s psaním, pište prosím bez ChatGPT a nezlobte profesorku Kožíškovou! :)
         * Pokud jste rychlíci, zkuste si naimplementovat prohledávání do šířky (Breadth First Search - BFS)
         */
        static List<int> DepthFirstSearch(BinaryTree graph, int targetNodeIndex)
        {
            List<int> pathToTargetNode = new List<int>();

            Node currentNode = graph.root; // We start in root and we want to find a path from root to the target node

            /*
             * TODO: Naimplementujte prohledávání do hloubky
             */

            return pathToTargetNode;
        }

        static void Main(string[] args)
        {
            // Change this variable as you wish, just watch out that deeper trees are not very readable in console
            int treeDepth = 3;
            BinaryTree binaryTree = new BinaryTree(treeDepth);

            // Print the tree
            Console.WriteLine("Binary Tree: (Remember that the tree is rotated 90 degrees counter-clockwise)");
            binaryTree.PrintTree();
            Console.WriteLine();

            // Create a random index of a node present in the tree (a tree of depth n contains 2^n nodes, so the biggest index in the tree is 2^n)
            Random rng = new Random();
            int randomNodeIndex = rng.Next(1, (int)Math.Pow(2, treeDepth));

            List<int> path = DepthFirstSearch(binaryTree, randomNodeIndex);

            // Print the path to the node
            Console.Write("Path to node " + randomNodeIndex + " goes as follows: ");
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.Write(i);
                if (i > 0) Console.Write(" -> ");
            }
            Console.WriteLine();

            // Used so that the console does not close immediately
            Console.ReadKey();
        }
    }
}
