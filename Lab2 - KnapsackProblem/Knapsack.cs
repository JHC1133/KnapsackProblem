using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___KnapsackProblem
{
    internal class Knapsack
    {
        static int staticID;
        int id;

        int size;
        int capacity;

        bool isFull;

        List<Item> knapSackItems;

        public int Size { get => size; set => size = value; }
        public int Capacity { get => capacity; }
        public bool IsFull { get => isFull; set => isFull = value; }
        public int Id { get => id; set => id = value; }

        public Knapsack(int capacity)
        {
            this.capacity = capacity;

            Id = staticID++;
            knapSackItems = new List<Item>();
        }

        private void UpdateWeightSize(int newWeight)
        {
            size += newWeight;
        }

        public void PrintWeightSize()
        {
            Console.WriteLine($"Current weight of Knapsack with {Id}: size {size} of a total of {capacity} capacity");
        }

        public List<Item> GetStoredItems()
        {
            return knapSackItems;
        }

        public void PrintStoredItems()
        {
            int totalProfit = 0;

            //Console.WriteLine(" ");
            //Console.WriteLine($"Current items stored in Knapsack with id {Id}: ");
            //Console.WriteLine(" ");

            foreach (Item item in knapSackItems)
            {
                //Console.WriteLine($"Item {item.ID}");
                //Console.WriteLine($"Value: {item.Value} | Weight: {item.Weight} | Profit: {item.Profit}");
                //Console.WriteLine("---------");

                totalProfit += item.Profit;
            }

            Console.WriteLine($"The total profit for knapsack with id {Id}: {totalProfit} ");
        }

        public void AddItem(Item item)
        {
            if (!knapSackItems.Any(i => i.Equals(item)))
            {
                knapSackItems.Add(item);
                UpdateWeightSize(item.Weight);
            }

        }

        public bool CanAddItem(Item item)
        {
            if (knapSackItems.Contains(item) || knapSackItems.Any(i => i.Equals(item)))
            {
                return false;
            }

            foreach (Item knapSackitem in knapSackItems)
            {
                if (knapSackitem.ID == item.ID)
                {
                    return false;
                }
            }

            // Check if adding the item would exceed the knapsack's capacity
            return (size + item.Weight) <= this.Capacity;
        }

        public void RemoveItem(Item item)
        {
            knapSackItems.Remove(item);
            size -= item.Weight;
        }

        public Item GetLeastProfitableItem()
        {
            if (knapSackItems.Count == 0)
            {
                return null; // Return null if the knapsack is empty
            }

            // Use LINQ to find the item with the lowest profit
            var leastProfitableItem = knapSackItems.OrderBy(item => item.Profit).FirstOrDefault();
            return leastProfitableItem;
        }

        public void RemoveLeastProfitableItem()
        {
            if (knapSackItems.Count > 0)
            {
                Item leastProfitableItem = knapSackItems.OrderByDescending(i => i.Profit).Last();
                RemoveItem(leastProfitableItem);
            }
        }

        public Item ReturnLeastProfitableItem()
        {
            if (knapSackItems.Count > 0)
            {
                Item leastProfitableItem = knapSackItems.OrderByDescending(i => i.Profit).Last();
                return leastProfitableItem;
            }
            return null;
        }

        public void RemoveLastAddedItem()
        {
            if (knapSackItems.Count > 0)
            {
                knapSackItems.RemoveAt(knapSackItems.Count - 1);
            }
        }

    }
}
