using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___KnapsackProblem
{
    internal class GreedyAlgoPacker
    {
        List<Item> itemsNotUsed;
        List<Item> itemsUsed;

        public GreedyAlgoPacker()
        {
            itemsUsed = new List<Item>();
            itemsNotUsed = new List<Item>();
        }

        private Item CompareProfit(Item a, Item b)
        {
            if (a.Profit > b.Profit)
            {
                return a;
            }
            else 
                return b;
        }

        private void PackItem(Item item, Knapsack knapsack)
        {
            knapsack.AddItem(item);
        }

        public void RunGreedy(List<Item> itemList, Knapsack knapsack)
        {
            if (knapsack.Capacity <= knapsack.Size)
            {
                Console.WriteLine("Knapsack is full!");
                return;
            }

            Console.WriteLine("Greedy algorithm running...");
            Console.WriteLine("Sorting items...");

            // Comparing each item available based on profit
            itemList = itemList.OrderByDescending(item => item.Profit).ToList();


            Console.WriteLine("Packing items...");

            List<Item> itemsToRemove = new List<Item>();

            foreach (Item item in itemList)
            {
                if (knapsack.Capacity >= item.Weight && knapsack.Capacity >= (knapsack.Size + item.Weight))
                {
                    knapsack.AddItem(item);
                    itemsUsed.Add(item);
                    itemsToRemove.Add(item);
                }
            }

            foreach (Item item in itemsToRemove)
            {
             
                itemList.Remove(item);
            }

            Console.WriteLine("");
            Console.WriteLine("Items not used: ");
            Console.WriteLine("");

            foreach (Item item in itemList)
            {
                Console.WriteLine($"Item {item.ID}");
                Console.WriteLine($"Value: {item.Value} | Weight: {item.Weight} | Profit: {item.Profit}");
                Console.WriteLine("---------");
            }

        }

        public void RunGreedyForMultiple(List<Item> itemList, List<Knapsack> knapsacks)
        {
            // Checking if knapsacks are full
            foreach (Knapsack knapsack in knapsacks)
            {
                if (knapsack.Capacity <= knapsack.Size)
                {
                    Console.WriteLine($"Knapsack {knapsack.Id} is full!");
                    knapsack.IsFull = true;
                }
            }

            Console.WriteLine("Greedy algorithm running...");
            Console.WriteLine("Sorting items...");

            // Sort items based on their profit
            itemList = itemList.OrderByDescending(item => item.Profit).ToList();

            Console.WriteLine("Packing items...");

            foreach (Item item in itemList.ToList())
            {
                foreach (Knapsack knapsack in knapsacks)
                {
                    // If the knapsack can accommodate the item, add it and break from the inner loop
                    if (!knapsack.IsFull && knapsack.CanAddItem(item))
                    {
                        knapsack.AddItem(item);
                        itemsUsed.Add(item);
                        itemList.Remove(item); // Remove the item from the list since it is already packed
                        break; // Breaking stops checking other knapsacks for the item
                    }
                }
            }

            // After attempting to pack all items, list any items that couldn't be packed
            Console.WriteLine("");
            Console.WriteLine("Items not used: ");
            Console.WriteLine("");

            foreach (Item item in itemList) // Now itemList only contains items not used
            {
                Console.WriteLine($"Item {item.ID}");
                Console.WriteLine($"Value: {item.Value} | Weight: {item.Weight} | Profit: {item.Profit}");
                Console.WriteLine("---------");
                itemsNotUsed.Add(item);
            }
        }

        public List<Item> GetItemsNotStored()
        {
            return itemsNotUsed;
        }

        public List<Item> GetItemsStored()
        {
            return itemsUsed;
        }
    }
}
