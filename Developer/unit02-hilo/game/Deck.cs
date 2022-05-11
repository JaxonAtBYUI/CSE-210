using System;

namespace unit02_hilo.game {
    /// <summary>
    /// A deck of 52 cards, divided into four suits with values 1-13.
    ///
    /// Holds the values of the top and second card for play.
    /// </summary>
    class Deck {
        Random rnd = new Random();
        public int topCard;
        public int secondCard;

        public Deck() {
            topCard = rnd.Next(1, 13);
            secondCard = rnd.Next(1, 13);
        }

        /// <summary>
        /// "Shuffles" the deck and makes the top two cards randomly assigned for playing the game.
        /// </summary>
        public void Shuffle() {
            topCard = rnd.Next(1, 13);
            secondCard = rnd.Next(1, 13);
        }
    }
}
