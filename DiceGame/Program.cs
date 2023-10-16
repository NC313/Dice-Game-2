using System;

class DiceRoller
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Grand Circus Casino!");
        int sides = GetNumberOfSides();
        
        bool continueRolling = true;
        int rollNumber = 1;

        while (continueRolling)
        {
            Console.WriteLine($"\nRoll {rollNumber}:");

            int die1 = RollDice(sides);
            int die2 = RollDice(sides);

            Console.WriteLine($"You rolled a {die1} and a {die2} ({die1 + die2} total)");

            string result = CheckCombinations(die1, die2);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }

            continueRolling = RollAgain();
            rollNumber++;
        }

        Console.WriteLine("\nThanks for playing!!");
    }

    static int GetNumberOfSides()
    {
        int sides;

        while (true)
        {
            Console.Write("How many sides should each die have? ");
            if (int.TryParse(Console.ReadLine(), out sides) && sides > 0)
            {
                return sides;
            }
            else
            {
                Console.WriteLine("Please enter a valid number of sides.");
            }
        }
    }

    static int RollDice(int sides)
    {
        return random.Next(1, sides + 1);
    }

    static string CheckCombinations(int die1, int die2)
    {
        if (die1 == 1 && die2 == 1)
        {
            return "Snake Eyes";
        }
        else if (die1 == 1 && die2 == 2)
        {
            return "Ace Deuce";
        }
        else if (die1 == 6 && die2 == 6)
        {
            return "Box Cars";
        }
        return "";
    }

    static bool RollAgain()
    {
        Console.Write("\nRoll again? (y/n): ");
        return Console.ReadLine().Trim().ToLower() == "y";
    }
}
