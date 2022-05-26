using System;
using System.Collections.Generic;

namespace unit03_jumper.game
{
    /// <summary>
    /// The word class stores all data relating to the word, both the word itself and the guessed letters.
    /// </summary>
    class Word
    {
        List<string> words = new List<string>();
        string word = "apple";
        List<bool> guessed = new List<bool>();
        Random rnd = new Random();

        /// <summary>
        /// Declare a standard Word class.
        /// </summary>
        public Word() {
            words.Add("apple");
            words.Add("orange");
            words.Add("bannana");
            words.Add("pineapple");
            words.Add("lemon");
            words.Add("strawberry");
            words.Add("watermelon");
            PickWord();
            foreach (char letter in word) {
                guessed.Add(false);
            }
        }
        
        public void PickWord() {
            word = words[rnd.Next(0, words.Count)];
        }

        /// <summary>
        /// Checks the if the guessed letter is correct and then returns if you got one right or not.
        /// As it checks it updates which letter was correct.
        /// </summary>
        public bool CheckGuessed(char guessedLetter) {
            bool correct = false;
            for (int i = 0; i < word.Length; i++) {
                if (guessedLetter == word[i]) {
                    correct = true;
                    guessed[i] = true;
                }
            }
            return correct;
        }

        /// <summary>
        /// Returns the word as the guessed letters.
        /// </summary>
        public string GetGuessedWord() {
            string revealed = "";
            for (int i = 0; i < guessed.Count; i++) {
                if (guessed[i]) {
                    revealed = string.Concat(revealed, string.Concat(word[i], " "));
                }
                else {
                    revealed = string.Concat(revealed, "_ ");
                }
            }
            return revealed;
        }

        /// <summary>
        /// Checks to see if every letter is guessed.
        /// </summary>
        public bool CheckAllGuessed() {
            bool finished = true;
            for (int i = 0; i < guessed.Count; i++) {
                if (!guessed[i]) {
                    finished = false;
                }
            }
            return finished;
        }
    }
}