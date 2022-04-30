using System;

namespace solo_prep_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Random randomGenerator = new Random();
            string response = "y";
            do {
                Console.Write("What is the max number? ");
                int max = int.Parse(Console.ReadLine());
                int magicNumber = randomGenerator.Next(0, max);
                int? guess = null;
                int guesses = 0;
                while (guess != magicNumber) {
                    Console.Write("What is your guess? ");
                    guess = int.Parse(Console.ReadLine());
                    guesses ++;
                    if (guess > magicNumber) {
                        Console.WriteLine("Lower.");
                    }
                    else if (guess < magicNumber) {
                        Console.WriteLine("Higher.");
                    }
                }
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"You made {guesses} guesses.");
                Console.Write("Would you like to play again? (y/n) ");
                response = Console.ReadLine();
            } while (response == "y");
        }
    }
}
