using System;
using System.Collections.Generic;

namespace BinaryToDecimalConverter
{
    class Program
    {
        // TO DO 
        // Add support for decimal binary values
        // Add support for application loops
        // Add session history
        // Add Export?
        // -> Perhaps to PDF, CSV, or something of the like

        // FUTURE
        // Turn into a library that can be used on a website to create an online tool

        static void Main(string[] args)
        {
            // Launch the calculation tool
            BinaryToDecimal();

            // Read the user input - stops the program from stopping
            Console.ReadKey();
        }

        private static void BinaryToDecimal()
        {
            // Vars
            bool inputVerified = false;
            const int compliment = 2;
            double decimalValue = 0;
            string binary = "";
            List<string> formulaValues = new List<string>();


            // Verify that the input is valid binary
            do
            {
                Console.WriteLine("Please enter a binary value: ");
                string tmp = Console.ReadLine();
                bool hasError = false;
                tmp = tmp.Trim();

                // Iterate and test each character in the input string
                foreach (char c in tmp)
                {
                    if (c != '1' && c != '0')
                    {
                        hasError = true;
                        break;
                    }
                }

                // If it contains an illegal character, fail the verification
                if (!hasError)
                {
                    inputVerified = true;
                    binary = tmp;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entered value must be binary. Try again...");
                }
            }
            while (!inputVerified);

            // Clear the console, write the resulting calculation
            Console.Clear();
            Console.WriteLine($"Binary: {binary}");

            // Foreach part of the binary string, calculate the formula for the decimal value
            for (int i = 0; i < binary.Length; i++)
            {
                // Get the calculation for the segement
                decimalValue += int.Parse(binary.Substring(i, 1)) * (Math.Pow(compliment, ((binary.Length - i) - 1)));

                // Add the formula string to a list to display to the user
                formulaValues.Add($"({int.Parse(binary.Substring(i, 1))}x{compliment}^{(binary.Length - i) - 1})"
                    );
            }

            // Write the calcuation steps and the result
            Console.WriteLine(binary + " = " + string.Join("+", formulaValues) + $" = {decimalValue}");

        }
    }
}
