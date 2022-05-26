using System;

namespace unit03_jumper.game
{
    /// <summary>
    /// Manage the other classes and define the game loop for the jumper game.
    /// </summary>
    class Director
    {
        Parachute parachute = new Parachute();
        TerminalService terminal = new TerminalService();
        Word word = new Word();
        bool playing = true;

        /// <summary>
        /// Standard director values.
        /// </summary>
        public Director() {
        }

        /// <summary>
        /// The standard jumper game loop.
        /// </summary>
        public void StartGame() {
            DoOutputs();
            while (playing) {
                char guess = GetInputs();
                DoUpdates(guess);
                DoOutputs();
            }
        }

        /// <summary>
        /// The input phase of gameplay.
        /// </summary>
        char GetInputs() {
            return terminal.GetGuess();
        }

        /// <summary>
        /// The update phase of gameplay.
        /// </summary>
        void DoUpdates(char guess) {
            bool correct = word.CheckGuessed(guess);
            if (!correct) {
                parachute.damageParachute();
            }
            if (parachute.getDurability() == 0) {
                playing = false;
            }
            if (word.CheckAllGuessed()) {
                playing = false;
            }
        }

        /// <summary>
        /// The output phase of gameplay.
        /// </summary>
        void DoOutputs() {
            terminal.ShowGuessed(word.GetGuessedWord());
            terminal.DisplayJumper(parachute.getDurability());
        }
    }
}
