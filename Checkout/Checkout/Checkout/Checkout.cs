using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout
{
    public class Checkout : ICheckout
    {

        private int currentTotal;
        private StoreInventory storeInventory;
        private Dictionary<string, int> session;

        public Checkout()
        {
            currentTotal = 0;
            storeInventory = new StoreInventory();
            storeInventory.PopulateDefault();
            session = new Dictionary<string, int>();
        }

        // Development Testing
        static void Main(string[] args)
        {
            Checkout instance = new Checkout();

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

        public void Scan(Item item)
        {
            IStoreItem scanItem = storeInventory.GetItem(item.Name);

            if(scanItem == null)
            {
                Console.WriteLine("Error: Item - "+ item.Name + " - not found.");
                return;
            }

            if (!session.ContainsKey(scanItem.Name))
            {
                session.Add(scanItem.Name, 1);
            }
            else
            {
                session[scanItem.Name] += 1;
            }

            ApplyRulesTotal();

        }

        public void ApplyRulesTotal()
        {
            currentTotal = 0;

            foreach (var item in session)
            {
                IStoreItem itemData = storeInventory.GetItem(item.Key);
                if((itemData.RuleQuantity > 1) && (item.Value >= itemData.RuleQuantity))
                {
                    int rulesCount = item.Value / itemData.RuleQuantity;
                    int remainderCount = item.Value % itemData.RuleQuantity;

                    currentTotal += (rulesCount * itemData.RulePrice);
                    currentTotal += (remainderCount * itemData.Price);

                    Console.WriteLine("Discount Applied: " + item.Key);
                }
                else
                {
                    currentTotal += (itemData.Price * item.Value);
                }
            }
        }

        public void ResetSession()
        {
            currentTotal = 0;
            session.Clear();
        }

        public void PrintSession()
        {
            Console.WriteLine();
            Console.WriteLine("Name - Quantity");
            foreach (var item in session)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }

        public int Total()
        {
            return currentTotal;
        }
    }
}
