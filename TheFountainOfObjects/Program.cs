namespace TheFountainOfObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SMALL = 4;
            const int MEDIUM = 6;
            const int LARGE = 8;
            // ask the player for the world size at the start of the game
            Console.WriteLine("Welcome to The Fountain of Objects!");
            Console.WriteLine("Please select the size of the world:");
            Console.WriteLine("1. Small (4x4)");
            Console.WriteLine("2. Medium (6x6)");
            Console.WriteLine("3. Large (8x8)");
            Console.Write("Enter the number of your choice: ");
            int size = int.Parse(Console.ReadLine());
            if (size == 1)
            {
                size = SMALL;
            }
            else if (size == 2)
            {
                size = MEDIUM;
            }
            else if (size == 3)
            {
                size = LARGE;
            }
            else
            {
                Console.WriteLine("Invalid choice, defaulting to small world.");
                size = SMALL;
            }
            TheFountainOfObjects game = new(size);
            game.Run();
        }
    }
}
