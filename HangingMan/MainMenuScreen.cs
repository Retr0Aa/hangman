using HangingMan.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangingMan
{
    public class MainMenuScreen
    {
        // Options
        List<string> currentOptions = new List<string>();

        List<string> defaultOptions = new List<string>
        {
            "Play",
            "Made by",
            "Use Colors: ",
            "Quit"
        };
        List<string> otherOptions = new List<string>
        {
            "Back"
        };

        int selectedOption = 0;

        Stats stats;

        /// <summary>
        /// Start drawing the menu
        /// </summary>
        public void StartMenu()
        {
            // Load Main Menu
            stats = StatsLoader.LoadStats();

            currentOptions = defaultOptions;

            RedrawMenu();
        }

        /// <summary>
        /// Redraws the menu in the console.
        /// </summary>
        /// <param name="key">The key entered</param>
        public void RedrawMenu()
        {
            Console.Clear();

            if (currentOptions == defaultOptions)
            {
                Console.WriteLine("Hanging Man");
                Console.WriteLine("===============");
            }
            else
            {
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n  ___ ___                       .__                    _____                 \r\n /   |   \\_____    ____    ____ |__| ____    ____     /     \\ _____    ____  \r\n/    ~    \\__  \\  /    \\  / ___\\|  |/    \\  / ___\\   /  \\ /  \\\\__  \\  /    \\ \r\n\\    Y    // __ \\|   |  \\/ /_/  >  |   |  \\/ /_/  > /    Y    \\/ __ \\|   |  \\\r\n \\___|_  /(____  /___|  /\\___  /|__|___|  /\\___  /  \\____|__  (____  /___|  /\r\n       \\/      \\/     \\//_____/         \\//_____/           \\/     \\/     \\/ \r\n");
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Petko Marinov - Team Leader");
                Console.WriteLine("Alexander Buchkov - Programmer");
                Console.WriteLine("Maxim Bikov - Programmer");
                Console.WriteLine("Stefan Ivanov - Documentation Writer");
                Console.WriteLine("Petar Petrov - Documentation Writer");
                Console.WriteLine("~~~ for SoftUni Project ~~~");
                Console.WriteLine("===============");
            }

            for (int i = 0; i < currentOptions.Count; i++)
            {
                string opt = currentOptions[i];

                if (selectedOption == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                if (currentOptions == defaultOptions && opt == "Use Colors: ")
                {
                    Console.WriteLine(opt + (stats.useColors ? "Yes" : "No"));
                }
                else
                {
                    Console.WriteLine(opt);
                }

                Console.ResetColor();

                Console.WriteLine("----------");
            }

            if (currentOptions == defaultOptions)
            {
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Stats: ");
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Wins: {stats.wins}");
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Loses: {stats.loses}");
                if (stats.useColors) Console.ForegroundColor = ConsoleColor.White;
            }

            WaitForKey();
        }

        public void WaitForKey()
        {
            var key = Console.ReadKey(true);

            // When buttons pressed
            if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedOption)
                {
                    case 0:
                        if (currentOptions == defaultOptions)
                        {
                            // Play
                            PlayGame();
                            return;
                        }
                        else
                        {
                            // Back
                            currentOptions = defaultOptions;
                            RedrawMenu();
                            return;
                        }
                    case 1:
                        // Credits
                        selectedOption = 0;
                        currentOptions = otherOptions;
                        RedrawMenu();
                        return;
                    case 2:
                        // Use Colors
                        stats.useColors = !stats.useColors;
                        StatsLoader.ToggleColors(stats.useColors);
                        RedrawMenu();
                        return;
                    case 3:
                        // Quit
                        Environment.Exit(0);
                        return;
                    default:
                        RedrawMenu();
                        break;
                }
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selectedOption > 0)
                    selectedOption--;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (selectedOption < currentOptions.Count - 1)
                    selectedOption++;

            }
            RedrawMenu();
        }

        public void PlayGame()
        {
            Console.Clear();

            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
