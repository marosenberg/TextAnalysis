using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzers.Lib;

namespace WordCounterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("1 argument expected");
                return;
            }
            WordSearcher searcher = WordSearcher.FromFile(args[0]);
            do
            {
                string input = PromptForSearchWord("Please enter text to search for: ");
            AskCase:

                string caseSen = PromptForSearchWord("Should this search be case sensitive? y/n ");
                bool cs = false;
                switch (caseSen.ToLower())
                {
                    case "y":
                        cs = true;
                        break;
                    case "n":
                        cs = false;
                        break;
                    default:
                        Console.WriteLine("You must enter Y or N");
                        goto AskCase;
                        break;
                }
                if (string.IsNullOrWhiteSpace(input)) return;
                int nOccur = searcher.GetWordCount(input, cs);
                Console.WriteLine($"The text {input} appears {nOccur} times");

            } while (true);
        }

        private static string PromptForSearchWord(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }  
    }
}
