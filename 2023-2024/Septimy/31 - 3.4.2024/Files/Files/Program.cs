using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Files
{
    internal class Program
    {
        /*
         * Mate pripravenou jednoduchou tridu reprezentujici osobu a vasim ukolem je naiplementovat 3 ukladaci a 3 nacitaci funkce pracujici se soubory ve tride Person.
         * Kde mate psat kod poznate podle toho, ze je v dane sekci komentar //TODO s popisem co tam mate nakodit.
         * 
         * Pracovat budete se 3 typy souboru:
         *  - klasicky textovy soubor (.txt)
         *  - "tabulkovy" format CSV (.csv) viz https://cs.wikipedia.org/wiki/CSV
         *  - Java Script Object Notation (.json) viz https://www.w3schools.com/whatis/whatis_json.asp
         *      Pouzivat budete tento balicek jiz importovany v projektu https://www.newtonsoft.com/json a vyuzivame ho pomoci radku 4 (using Newtonsoft.Json)
         *      Z balicku Json.NET vam staci dve funkce - SerializeObject() a DeserializeObject() ze stranky https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
         * 
         * V mainu bezi jednoduchy nekonecny while cyklus, ve kterm se cte co chce uzivatel delat (vytvorit novou osobu, ulozit existujici, nacist osobu ze souboru atd.)
         * Soubory muzete jednoduse vytvorit (a psat do nich) StreamWriterem tak, ze mu do parametru (cesty souboru) napisete pozadovany format,
         * tedy parametr muze vypadat napr. takto: string filePath = "C:\Users\Honza\Desktop\KarelNovak.txt", nebo treba "C:\Users\Honza\Desktop\KarelNovak.csv".
         * 
         * Pripomente si praci s textovymi soubory prezentaci https://github.com/Yeenya/Gymvod_23-24/blob/main/Oktavy/19%20-%209.1.2024/Okt%C3%A1vy%2019.%20-%209.1.2024.pdf,
         * posledni sekce "Textove soubory".
         * Do CSV souboru pisete uplne stejne jako do obycejnych textovych souboru, akorat dodrzujte konvenci co radek to "hodnota1,hodnota2,hodnota3" atd, tedy mejte stringy
         * ve spravnem tvaru.
         * Do Json souboru take pisete stejne, akorat tomu opet musite dat string ve spravnem tvaru/formatu, coz je ten, ktery dostanete z funkce
         * SerializeObject() zminene vyse
         * 
         * Nejste si necim jisti, nerozumite, bojite se, ze vam vybouchne pocitac a smazete si system? Ptejte se me :)
         */

        static Random rng; // Jedna random instance na generovani id osob
        static List<Person> people; // List vsech aktualnich osob

        class Person
        {
            public string Name { get; set; }

            public float Height { get; set; }

            public float Weight { get; set; }

            private int id; // Automaticky generovane id pro odliseni osob se stejnym jmenem, vahou a vyskou

            private string filePath; // Nastavte podle toho, jak chcete, aby se vase soubory jmenovaly, a kde budou ulozene

            // Jednoduchy konstruktor, ktery vytvori osobu podle zadanych parametru a nahodne vygeneruje id
            public Person(string name, float height, float weight)
            {
                Name = name;
                Height = height;
                Weight = weight;

                id = rng.Next();
            }

            // Prazdny konstruktor pro vase pripadne vyuziti
            public Person() { } 

            // Override ToString funkce, aby se vypisovaly informace, ktere nam neco o osobe reknou
            public override string ToString()
            {
                return Name + ", " + Height + "cm tall, weighing " + Weight + "kg.";
            }

            public static Person CreatePerson() // Staticka funkce pro vytvoreni osoby uzivatelem z konzole, zavola se jako Person.CreatePerson()
            {
                Console.Write("Enter name of the new person: ");
                string name = Console.ReadLine();
                Console.Write("Enter height of the new person: ");
                float height = float.Parse(Console.ReadLine());
                Console.Write("Enter weight of the new person: ");
                float weight = float.Parse(Console.ReadLine());
                Person newPerson = new Person(name, height, weight);

                Console.WriteLine("Person " + name + " created successfully.");
                return newPerson;
            }

            // Funkce pro ulozeni osoby do textoveho souboru. Je nestaticka, takze se rovnou muzeme odkazovat na Name, Height atd.
            public void SaveToTxt()
            {
                //TODO: Vymyslete jak se bude soubor jmenovat a kde bude ulozeny (klidne pevnou cestou k projektu na disku) a vepiste informace o osobe do textoveho dokumentu
                //      Jak tam budete informace ukladat je ciste na vas. Potrebujete je nasledne byt schopni nacist v nasledujici funkci.
            }

            // Staticka funkce pro nacteni osoby ulozene v textovem souboru
            public static Person LoadFromTxt()
            {
                //TODO: Nactete vami ulozene informace z textoveho souboru. Nejdriv se uzivatele zeptejte koho chce nacist a podle toho najdete spravny soubor obsahujici
                //      chtenou osobu. Nasledne z nej uz jenom prectete informace, vytvore diky nim novou instanci Person a vratte ji
                return new Person(); // Prepiste tento radek tak, ze v nem budete vracet vytvorenou instanci Person (osobu nactenou ze souboru)
            }

            // Funkce pro ulozeni osoby do csv souboru. Je nestaticka, takze se rovnou muzeme odkazovat na Name, Height atd.
            public void SaveToCsv()
            {
                //TODO: Stejne, jako SaveToTxt, akorat vytvorte Csv soubor
            }

            // Staticka funkce pro nacteni osoby ulozene v textovem souboru
            public static Person LoadFromCsv()
            {
                //TODO: Stejne, jako LoadFromTxt, ale nacitejte z Csv souboru
                return new Person(); // Prepiste tento radek tak, ze v nem budete vracet vytvorenou instanci Person (osobu nactenou ze souboru)
            }

            // Funkce pro ulozeni osoby do json souboru. Je nestaticka, takze se rovnou muzeme odkazovat na Name, Height atd.
            public void SaveToJson()
            {
                //TODO: Stejne, jako SaveToTxt, akorat vytvorte Json soubor
            }

            // Staticka funkce pro nacteni osoby ulozene v textovem souboru
            public static Person LoadFromJson()
            {
                //TODO: Stejne, jako LoadFromTxt, ale nacitejte z Json souboru
                return new Person(); // Prepiste tento radek tak, ze v nem budete vracet vytvorenou instanci Person (osobu nactenou ze souboru)
            }
        }

        static void Main(string[] args)
        {
            rng = new Random();
            people = new List<Person>();

            while (true)
            {
                Console.WriteLine("What do you want to do? 1 - Create a new person, 2 - List existing people, 3 - Save an existing person, 4 - Load person from file, 5 - End");
                switch (Console.ReadLine())
                {
                    case "1": // Vytvoreni nove osoby a pridani do listu people
                        people.Add(Person.CreatePerson());
                        break;
                    case "2": // Vypsani listu people do konzole
                        foreach (Person person in people) { Console.Write(person.ToString()); }
                        if (people.Count == 0) Console.Write("The people list is empty!");
                        Console.Write("\n");
                        break;
                    case "3": // Ulozeni osoby, ktera je uz v listu people, do souboru (uzivatel definuje do jakeho souboru chce osobu ulozit)
                        Console.Write("Save which person? (Write name of the person): ");
                        string personName = Console.ReadLine();
                        Person personToSave = people.FirstOrDefault(person => person.Name.Equals(personName));
                        if (personToSave == default(Person))
                        {
                            Console.WriteLine("No (such) person found");
                            continue;
                        }
                        Console.Write("Save to which type of file? (txt, csv, json): ");
                        string fileType = Console.ReadLine();
                        switch (fileType)
                        {
                            case "txt":
                                personToSave.SaveToTxt();
                                break;
                            case "csv":
                                personToSave.SaveToCsv();
                                break;
                            case "json":
                                personToSave.SaveToJson();
                                break;
                            default:
                                Console.WriteLine("This file type is not supported.");
                                break;
                        }
                        break;
                    case "4": // Nacteni osoby ze souboru a jeji pridani do listu person
                        Console.Write("Load from which type of file? (txt, csv, json): ");
                        fileType = Console.ReadLine();
                        switch (fileType)
                        {
                            case "txt":
                                people.Add(Person.LoadFromTxt());
                                break;
                            case "csv":
                                people.Add(Person.LoadFromCsv());
                                break;
                            case "json":
                                people.Add(Person.LoadFromJson());
                                break;
                            default:
                                Console.WriteLine("This file type is not supported.");
                                break;
                        }
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("I cannot process such input.");
                        break;
                }
            }
        }
    }
}
