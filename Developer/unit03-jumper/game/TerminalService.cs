using System;
using System.Collections.Generic;

namespace unit03_jumper.game
{
    /// <summary>
    /// Handles all the terminal interactions within the jumper game.
    /// </summary>
    class TerminalService
    {
        List<string> gameDisplay = new List<string>();
        
        /// <summary>
        /// Defines a standard terminal for the jumper game.
        /// </summary>
        public TerminalService() {
            gameDisplay.Add(@"        ___---___");
            gameDisplay.Add(@"     _--    |    --_");
            gameDisplay.Add(@"    / \     |     / \");
            gameDisplay.Add(@"   |   \    |    /   |");
            gameDisplay.Add( "   -------------------\n   \\                 /\n    \\               /\n     \\             /\n      \\           /\n       \\         /\n        \\       /\n         \\     /\n          \\   /");
            gameDisplay.Add( "            O\n           /|\\\n           / \\\n\n\n\n                /\\\n /\\      /\\    /  \\  /\\\n/  \\/\\  /  \\/\\/    \\/  \\  /\\\n   /  \\/    \\/      \\/\\ \\/\n  /    \\    /       /  \\/\n /      \\  /  /\\   /    \\\n/  /\\    \\/  /  \\ /      \\\n ");
        }
        
        /// <summary>
        /// Displays how much of the parachute is left.
        /// </summary>
        public void DisplayJumper(int durability) {
            Console.WriteLine();
            for (int i = (5 - durability); i <= 5; i++) {
                Console.WriteLine(gameDisplay[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Asks the user for a guess and return it.
        /// </summary>
        public char GetGuess() {
            Console.Write("Guess a letter [a-z]: ");
            return char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Display the guessed word.
        /// </summary>
        public void ShowGuessed(string guessedWord) {
            Console.WriteLine();
            Console.WriteLine(guessedWord);
        }

    }
}



