using System;

namespace CharacterAbilityScoreCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;

                
            }
        }

        private static double ReadDouble(double divideBy, string v)
        {
            Console.WriteLine(v + " [" + divideBy + "] : ");

            string value = Console.ReadLine();

            if (double.TryParse(value, out double result))
            {
                Console.WriteLine("using value " + result);
                Console.WriteLine();
                return result;
            }
            else
            {
                Console.WriteLine("using default value " + divideBy);
                Console.WriteLine();
                return divideBy;
            }
        }

        private static int ReadInt(int rollResult, string v)
        {
            // Write the prompt followed by [default value]:
            Console.WriteLine(v + " [" + rollResult + "] : ");

            // Read the line from the input and use int.TryParse to attempt to parse it
            string value = Console.ReadLine();

            if(int.TryParse(value, out int result))
            {
                Console.WriteLine("using value " + result);
                Console.WriteLine();
                return result;
            }
            else
            {
                Console.WriteLine("using default value " + rollResult);
                Console.WriteLine();
                return rollResult;
            }

            // If it can be parsed, write " using value" + value to the console
            // Otherwise write " using default value" + lastUsedValue to the console
        }
    }

    class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;
        
        public void CalculateAbilityScore()
        {
            // Divide the roll result by the DivideBy field
            double divided = RollResult / DivideBy;

            //Add AddAmount to the result of that division
            int added = AddAmount += (int)divided;

            // If the result is too small, use Minimum
            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }
    }
}
