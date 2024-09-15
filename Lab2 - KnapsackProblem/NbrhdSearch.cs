using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___KnapsackProblem
{
    internal class NbrhdSearch
    {
        private List<Knapsack> knapsacks;
        private List<Item> itemsNotUsed;
        private Random random;
        private int maxIterations;

        Item randomItemBag0;
        Item randomItemBag1;
        Item randomItemBag2;

        public NbrhdSearch(List<Knapsack> knapsacks, List<Item> itemsNotUsed)
        {
            this.knapsacks = knapsacks;
            this.itemsNotUsed = itemsNotUsed;
            random = new Random();
            maxIterations = 1500;
        }

        public void NbrdhdSearch()
        {
            int currentIteration = 0;
            int currentTotalProfit = CalculateTotalProfit(knapsacks);

            Console.WriteLine("Initial total profit: " + currentTotalProfit);

            for (int i = 0; i < maxIterations; i++)
            {
                currentIteration++;

                // Get the item with lowest profit and moves it from the knapsack to the items not used
                Item itemToRemoveBag0 = knapsacks[0].GetStoredItems().OrderByDescending(i => i.Profit).Last();
                knapsacks[0].RemoveItem(itemToRemoveBag0);

                if (itemsNotUsed.Count > 0)
                {
                    int randomIndex = random.Next(0, itemsNotUsed.Count);
                    randomItemBag0 = itemsNotUsed[randomIndex];

                    // Avoids exceeding the knapsacks capacity
                    if (knapsacks[0].CanAddItem(randomItemBag0))
                    {
                        knapsacks[0].AddItem(randomItemBag0);
                        itemsNotUsed.Remove(randomItemBag0);
                        itemsNotUsed.Add(itemToRemoveBag0);

                    }
                    else if (itemToRemoveBag0 != null)
                    {
                        // If the new item can't be added, just revert the removal of the lowest profit item
                        knapsacks[0].AddItem(itemToRemoveBag0);
                    }
                }

                Item itemToRemoveBag1 = knapsacks[1].GetStoredItems().OrderByDescending(i => i.Profit).Last();
                knapsacks[1].RemoveItem(itemToRemoveBag1);

                if (itemsNotUsed.Count > 0)
                {
                    int randomIndex = random.Next(0, itemsNotUsed.Count);
                    randomItemBag1 = itemsNotUsed[randomIndex];

                    // Avoids exceeding the knapsacks capacity
                    if (knapsacks[1].CanAddItem(randomItemBag1))
                    {
                        knapsacks[1].AddItem(randomItemBag1);
                        itemsNotUsed.Remove(randomItemBag1);
                        itemsNotUsed.Add(itemToRemoveBag1);
                    }
                    else if (itemToRemoveBag1 != null)
                    {
                        // If the new item can't be added, just revert the removal of the lowest profit item
                        knapsacks[1].AddItem(itemToRemoveBag1);
                        
                    }
                }

                Item itemToRemoveBag2 = knapsacks[2].GetStoredItems().OrderByDescending(i => i.Profit).Last();
                knapsacks[2].RemoveItem(itemToRemoveBag2);

                if (itemsNotUsed.Count > 0)
                {
                    int randomIndex = random.Next(0, itemsNotUsed.Count);
                    randomItemBag2 = itemsNotUsed[randomIndex];

                    // Avoids exceeding the knapsacks capacity
                    if (knapsacks[2].CanAddItem(randomItemBag2))
                    {
                        knapsacks[2].AddItem(randomItemBag2);
                        itemsNotUsed.Remove(randomItemBag2);
                        itemsNotUsed.Add(itemToRemoveBag2);
                    }
                    else if (itemToRemoveBag2 != null)
                    {
                        // If the new item can't be added, just revert the removal of the lowest profit item
                        knapsacks[2].AddItem(itemToRemoveBag2);
                       
                    }
                }

                

                int newTotalProfit = CalculateTotalProfit(knapsacks);

                if (newTotalProfit > currentTotalProfit)
                {
                    currentTotalProfit = newTotalProfit;


                    //itemsNotUsed.Add(itemToRemove);
                    Console.WriteLine("Better solution has been found!");
                    Console.WriteLine($"Iteration: {currentIteration}, Improved total profit: {currentTotalProfit}");
                    PrintCurrentStoredItems();
                    Console.WriteLine("--------");
                    //maxIterations = currentIteration;                  
                }
                else
                {
                    // No improvement, revert the change

                    //Knapsack 0
                    knapsacks[0].RemoveItem(randomItemBag0);
                    itemsNotUsed.Add(randomItemBag0);
                    itemsNotUsed.Remove(itemToRemoveBag0);
                    knapsacks[0].AddItem(itemToRemoveBag0);

                    // Knapsack 1
                    knapsacks[1].RemoveItem(randomItemBag1);
                    itemsNotUsed.Add(randomItemBag1);
                    itemsNotUsed.Remove(itemToRemoveBag1);
                    knapsacks[1].AddItem(itemToRemoveBag1);

                    // Knapsack 2
                    knapsacks[2].RemoveItem(randomItemBag2);
                    itemsNotUsed.Add(randomItemBag2);
                    itemsNotUsed.Remove(itemToRemoveBag2);
                    knapsacks[2].AddItem(itemToRemoveBag2);
                }
            }
        }

        private void PrintCurrentStoredItems()
        {
            foreach (Knapsack knapsack in knapsacks)
            {
                knapsack.PrintStoredItems();
            }
        }

        private int CalculateTotalProfit(List<Knapsack> knapsacks)
        {
            int totalProfit = 0;

            // Iterate through each knapsack
            foreach (var knapsack in knapsacks)
            {
                // Iterate through each item in the current knapsack
                foreach (var item in knapsack.GetStoredItems())
                {
                    totalProfit += item.Profit; // Sum up the profit of each item
                }
            }

            return totalProfit; // Return the total profit calculated
        }

    }
}
