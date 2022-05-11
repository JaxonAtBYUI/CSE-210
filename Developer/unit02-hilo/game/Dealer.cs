using System;

namespace unit02_hilo.game {
    /// <summary>
    /// The dealer is in charge of running the game and keeping score.
    /// </summary>
    class Dealer {
        bool isPlaying;
        int score;
        string hilo;
        Deck deck = new Deck();

        public Dealer() {
            isPlaying = true;
            score = 300;
            hilo = "l";
        }

        /// <summary>
        /// You sit down at the table, the dealer acknowledges you.
        /// The game begins.
        /// </summary>
        public void StartGame() {
            while(isPlaying) {
                deck.Shuffle();
                DisplayCard(deck.topCard);
                Guess();
                DisplayCard(deck.secondCard);
                UpdateScore();
                DisplayScore();
                GamblersFallacy();
            }
        }

        /// <summary>
        /// The dealer flips a card for you to see.
        /// </summary>
        public void DisplayCard(int card) {
            Console.WriteLine($"The card is: {card}");
        }

        /// <summary>
        /// You see the card on the table. "Higher or Lower?".
        /// The answer could win big or lose your hard earned points. Which is it?
        /// </summary>
        public void Guess() {
            bool valid = false;
            while (!valid) {
                Console.Write("Higher or Lower? [h/l] ");
                hilo = Console.ReadLine();
                if ((hilo == "l") || (hilo == "h")) {
                    valid = true;
                }
            }
        }

        /// <summary>
        /// The dealer takes the two cards into account.
        /// He notes your score.
        /// </summary>
        public void UpdateScore() {
            if (deck.topCard == deck.secondCard) {
                Console.WriteLine("Darn! No points!");
            }
            else if ((deck.topCard < deck.secondCard) && (hilo == "h")) {
                score += 100;
                Console.WriteLine("100 points for guessing right!");
            }
            else if ((deck.topCard > deck.secondCard) && (hilo == "l")) {
                score += 100;
                Console.WriteLine("100 points for guessing right!");
            }
            else {
                score -= 75;
                Console.WriteLine("There goes 75 points!");
            }
        }

        /// <summary>
        /// The dealer announces to you your new score.
        /// </summary>
        public void DisplayScore() {
            Console.WriteLine($"Your score is: {score}");
        }

        /// <summary>
        /// If you haven't busted and lost everything, you feel the urge to keep going.
        /// The next big win is always on the horizon. It has to happen eventually.
        /// </summary>
        public void GamblersFallacy() {
            if (score <= 0) {
                Console.WriteLine("Looks like you lose!");
                isPlaying = false;
            }
            else {
                Console.Write("Play again? [y/n] ");
                string response = Console.ReadLine();
                if (response == "n") {
                    isPlaying = false;
                }
            }
            Console.WriteLine();
        }
    }


}

