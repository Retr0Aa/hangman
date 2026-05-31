using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangingMan.Game
{
    public class GameManager
    {
        public int wrongMoves = 0;
        public string selectedWord = "";
        public List<char> usedLetters = new List<char>();
        public List<char> rightLetters = new List<char>();

        public Stats stats;

        public void StartGame()
        {
            stats = StatsLoader.LoadStats();

            string[] wordlist = WordLibrary.ReadWordsFromFile();
            selectedWord = wordlist[Random.Shared.Next(wordlist.Length)];

            TestPlayer();
        }

        public void TestPlayer()
        {
            Console.Clear();

            Console.WriteLine(Animations.wrongGuessesFrames[wrongMoves]);

            Console.WriteLine("=======================");
            Console.WriteLine("Used Letters: " + string.Join(" ", usedLetters));

            Console.Write("Word: ");
            foreach (var ltr in selectedWord)
            {
                if (rightLetters.Contains(ltr))
                {
                    Console.Write(ltr);
                }
                else
                {
                    Console.Write('_');
                }
            }

            Console.WriteLine();

            char character = char.ToLower(Console.ReadKey().KeyChar);

            if (selectedWord.Contains(character))
            {
                // Contains
                if (rightLetters.Contains(character))
                {
                    if (wrongMoves < Animations.wrongGuessesFrames.Length - 1)
                    {
                        wrongMoves++;
                        usedLetters.Add(character);
                        TestPlayer();
                    }
                    else
                    {
                        // Lose
                        Animations.PlayDeathAnimation(stats);
                        Console.Clear();
                        if (stats.useColors) Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Animations.lossScreenText);
                        if (stats.useColors) Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=======================");

                        StatsLoader.AddLose();

                        TryAgainPrompt();
                    }
                }

                rightLetters.Add(character);
                if (rightLetters.Count == selectedWord.Length)
                {
                    // Win
                    Console.Clear();
                    if (stats.useColors) Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Animations.winScreenText);
                    if (stats.useColors) Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=======================");

                    StatsLoader.AddWin();

                    TryAgainPrompt();
                }
                else
                {
                    TestPlayer();
                }
            }
            else
            {
                // Doesn't Contain
                if (wrongMoves < Animations.wrongGuessesFrames.Length - 1)
                {
                    wrongMoves++;
                    usedLetters.Add(character);
                    TestPlayer();
                }
                else
                {
                    // Lose
                    Animations.PlayDeathAnimation(stats);
                    Console.Clear();
                    if (stats.useColors) Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Animations.lossScreenText);
                    if (stats.useColors) Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=======================");

                    StatsLoader.AddLose();

                    TryAgainPrompt();
                }
            }
        }

        public void TryAgainPrompt()
        {
            Console.WriteLine("Try Again? (y/n)");
            char answer = char.ToUpper(Console.ReadKey().KeyChar);
            if (answer == 'Y')
            {
                GameManager gameManager = new GameManager();
                gameManager.StartGame();
            }
            else if (answer == 'N')
            {
                MainMenuScreen mainMenuScreen = new MainMenuScreen();
                mainMenuScreen.StartMenu();
            }
            else
            {
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou should choose only Y(Yes) or N(No)!");
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.White;
                TryAgainPrompt();
            }
        }
    }
}