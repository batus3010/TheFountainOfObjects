using System;

namespace TheFountainOfObjects
{
    internal class Program
    {

        const int SMALL = 4;
        const int MEDIUM = 6;
        const int LARGE = 8;
        static void Main(string[] args)
        {
            int size = GetWorldSize();
            TheFountainOfObjects game = new(size);
            game.Run();
        }

        static int GetWorldSize()
        {
            // Ask the player for the world size at the start of the game
            Console.WriteLine("Welcome to The Fountain of Objects!");
            Console.WriteLine("Please select the size of the world:");
            Console.WriteLine("1. Small (4x4)");
            Console.WriteLine("2. Medium (6x6)");
            Console.WriteLine("3. Large (8x8)");
            Console.Write("Enter the number of your choice: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return SMALL;
                        case 2:
                            return MEDIUM;
                        case 3:
                            return LARGE;
                        default:
                            Console.WriteLine("Invalid choice, defaulting to small world.");
                            return SMALL;
                    }
                }
                else
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 3: ");
                }
            }
        }

    }
}
