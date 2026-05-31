# Hangman Game

A console-based Hangman game developed in C# as a SoftUni project.

## What is Hangman?

Hangman is a classic guessing game where the computer selects a word and the player must guess it by suggesting letters one at a time. You have a limited number of incorrect guesses (6 by default). Each correct letter fills in the corresponding blanks in the word. The goal is to guess the word before the hangman gets drawn.

It's a popular game worldwide and is great for both kids and adults, as it involves logical thinking and strategy.

## How to Play

1. The computer selects a random word from the word list
2. You guess letters one at a time
3. Each correct letter is revealed in the word
4. Each incorrect guess counts against you (max 6 wrong guesses)
5. Win by guessing the complete word before running out of guesses
6. Lose if you run out of guesses before completing the word

## Team

- [Petko Marinov](https://github.com/PetkoMarinov19) - Team Leader
- [Alexander Buchkov](https://github.com/Retr0Aa) - Programmer
- [Maxim Bikov](https://github.com/MaximProjects08/) - Programmer
- [Stefan Ivanov](https://github.com/Necr0Lancer) - Documentation Writer
- [Petar Petrov](https://github.com/Peshi2312) - Documentation Writer

## Project Files

### Game Components

- **[Animations.cs](HangingMan/Game/Animations.cs)** - Contains all animations and ASCII art for the game
- **[GameManager.cs](HangingMan/Game/GameManager.cs)** - Core game logic and turn system
- **[StatsLoader.cs](HangingMan/Game/StatsLoader.cs)** - Handles game statistics (wins/losses) and persistence
- **[WordLibrary.cs](HangingMan/Game/WordLibrary.cs)** - Manages the word list used in the game

### Main Entry Points

- **[Program.cs](HangingMan/Program.cs)** - Application entry point
- **[MainMenuScreen.cs](HangingMan/MainMenuScreen.cs)** - Main menu interface
