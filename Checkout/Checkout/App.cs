using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    class App
    {
        // Development Testing
        static void Main(string[] args)
        {
            CheckoutMain instance = new CheckoutMain();

            Console.WriteLine("------ Cantarus Checkout ------");
            Console.WriteLine("----- Type 'exit' to quit -----");
            Console.WriteLine("-- Type 'print' to see cart ---");
            Console.WriteLine("---- Type 'reset' to reset ----");
            Console.WriteLine("-------------------------------");

            while (true) // Loop indefinitely
            {
                Console.WriteLine();

                Console.WriteLine("Scan Item: ");
                string line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }

                if (line == "print")
                {
                    instance.PrintSession();
                    continue;
                }

                if (line == "reset")
                {
                    instance.ResetSession();
                    continue;
                }

                Item input = new Item();
                input.Name = line;
                instance.Scan(input);

                Console.WriteLine("Current Total: " + instance.Total());
                Console.WriteLine();
            }
        }
    }
}
