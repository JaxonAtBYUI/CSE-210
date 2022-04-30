using System;

namespace solo_prep_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your grade percentage? ");
            int percentage = int.Parse(Console.ReadLine());
            string letter = "A";
            
            // Find the letter grade
            if (percentage > 90) {
                letter = "A";
            }
            else if (percentage > 80) {
                letter = "B";
            }
            else if (percentage > 70) {
                letter = "C";
            }
            else if (percentage > 60) {
                letter = "D";
            }
            else {
                letter = "F";
            }

            // Find the sign on the end of the grade
            string sign = null;
            if (!(percentage >= 97) || !(percentage < 70)) {
                int single = percentage % 10;
                if (single <= 3) {
                    sign = "-";
                }
                else if (single >= 7) {
                    sign = "+";
                }
            
            // Ouput their letter grade
            Console.WriteLine($"Your letter grade is {letter}{sign}.");
            }
        }
    }
}