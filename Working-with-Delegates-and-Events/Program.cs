using System;

namespace delegatesAndEvents
{
    public delegate void Delegate(int n);

    public class Race
    {
        public event Delegate Something;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            Something(champ);

        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new Race();
            // register with the footRace event
            round1.Something += footRace;
            // trigger the event
            round1.Racing(6, 5);
            // register with the carRace event
            round1.Something -= footRace;
            round1.Something += carRace;
            //trigger the event
            round1.Racing(34, 3);
            // register a bike race event using a lambda expression
            round1.Something -= carRace;
            round1.Something += (winner) => Console.WriteLine($"The bike race winner is {winner}");
            // trigger the event
            round1.Racing(22, 4);

        }

        // event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}