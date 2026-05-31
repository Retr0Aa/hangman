using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangingMan.Game
{
    public class WordLibrary
    {
        public static string[] ReadWordsFromFile()
        {
            try
            {
                return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "words.txt"));
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading words from file: " + e.Message);
                
                Environment.Exit(1);
                
                return null;
            }
        }
    }
}
