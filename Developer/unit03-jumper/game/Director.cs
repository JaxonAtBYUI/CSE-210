using System;

namespace unit03_jumper.game
{
    /// <summary>
    /// Manage the other classes and define the game loop for the jumper game.
    /// </summary>
    class Director
    {
        private Parachute parachute = new Parachute();
        private TerminalService terminal = new TerminalService();
        private Word word = new Word();
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
        private char GetInputs() {
            return terminal.GetGuess();
        }

        /// <summary>
        /// The update phase of gameplay.
        /// </summary>
        private void DoUpdates(char guess) {
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
        private void DoOutputs() {
            terminal.ShowGuessed(word.GetGuessedWord());
            terminal.DisplayJumper(parachute.getDurability());
        }
    }
}
