using System;
using System.Collections.Generic;

namespace solo_prep_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int newNumber = 1;
            List<int> numbers = new List<int>();
            
            // Get the list of numbers from the user
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            do {
                Console.Write("\tEnter a number: ");
                newNumber = int.Parse(Console.ReadLine());
                numbers.Add(newNumber);
            } while (newNumber != 0);

            // Compute the sum.
            int sum = 0;
            for (int i = 0; numbers[i] != 0;  i++) {
                sum += numbers[i];
            }
            Console.WriteLine($"The sum is: {sum}");

            // Compute the average.
            float average = 0;
            if (numbers.Count > 1) {
                average = sum / (numbers.Count - 1);
            }
            Console.WriteLine($"The average is: {average}");

            // Find the number with the largest magnitude.
            int largest = numbers[0];
            for (int i = 0; numbers[i] != 0; i++) {
                if (Math.Abs(numbers[i]) > largest) largest = numbers[i];
            }
            Console.WriteLine($"The largest magnitude is: {largest}");

            // Find the number with the smallest magnitude.
            int smallest = numbers[0];
            for (int i = 0; numbers[i] != 0; i++) {
                if (Math.Abs(numbers[i]) < smallest) smallest = numbers[i];
            }
            Console.WriteLine($"The smallest magnitude is: {smallest}");

            // Print the sorted list.
            Console.WriteLine("The following is the sorted list:");
            while (numbers[0] != 0) {
                int number = 0;
                for (int i = 0; numbers[i] != 0; i++) {
                    if (numbers[i] < numbers[number]) number = i;
                }
                Console.WriteLine($"\t{numbers[number]}");
                numbers.RemoveAt(number);
            }
            
        }
    }
}

