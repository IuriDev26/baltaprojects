using System;

namespace Stopwatch
{
    class Program
    {
        static int WindowWidth = Console.WindowWidth;
        
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-', WindowWidth));
            Console.WriteLine("Stopwatch Master 3000");
            Console.WriteLine("\nInstruções");
            Console.WriteLine("10s = 10 Segundos");
            Console.WriteLine("10m = 10 Minutos");
            Console.WriteLine(new string('-', WindowWidth));

            Console.Write("Digite quanto tempo você desejar cronometrar: ");
            string response = Console.ReadLine();
            
            string operation = response.Substring(response.Length - 1, 1);
            int finalTime = int.Parse(response.Substring(0, response.Length - 1));
            
            Start(finalTime, operation);
        }

        static void Start(int finalTime, string operation)
        {
            int initialTime = 1;
            int incrementTime = 0;

            switch (operation.ToLower())
            {
                case "s": incrementTime = 1000; break;
                case "m": incrementTime = 60000; break;
                
            }

            while (initialTime <= finalTime)
            {
                Console.Clear();
                Console.WriteLine($"Tempo Decorrido: {initialTime}");
                Thread.Sleep(incrementTime);
                initialTime++;
            }
            
        }
        
    }
}

