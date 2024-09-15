using System;

namespace Lab2___KnapsackProblem
{
    internal class Program
    {
        const int firstKnapsackCapacity = 70;
        const int secondKnapsackCapacity = 60;
        const int thirdKnapsackCapacity = 50;

        List<Knapsack> knapsacks;

        Program program;
        ItemManager manager;

        Knapsack knapsack;
        Knapsack knapsack2;
        Knapsack knapsack3;

        GreedyAlgoPacker greedy;

        NbrhdSearch nbrdhd;


        static void Main(string[] args)
        {

            Program program = new Program();

            program.Initialize();

            program.RunGreedyAlgorithm();
            program.PrintCurrentStoredItems();
            program.RunNeighborhoodSearch();
         
        }

        private Program()
        {
            manager = new ItemManager();
            knapsack = new Knapsack(firstKnapsackCapacity);
            knapsack2 = new Knapsack(secondKnapsackCapacity);
            knapsack3 = new Knapsack(thirdKnapsackCapacity);
            
            knapsacks = new List<Knapsack>()
            {
                knapsack,
                knapsack2,
                knapsack3
            };

        }

        private void Initialize()
        {
            manager.SetNumberOfItems(100);
            //manager.PrintItems();

            greedy = new GreedyAlgoPacker();

            nbrdhd = new NbrhdSearch(knapsacks, greedy.GetItemsNotStored());
        }

        private void PrintCurrentStoredItems()
        {
            foreach (Knapsack knapsack in knapsacks)
            {
                knapsack.PrintStoredItems();
            }
        }

        private void PrintCurrentKnapbackSizes()
        {
            foreach (Knapsack knapsack in knapsacks)
            {
                knapsack.PrintWeightSize();
            }
        }

        private void RunGreedyAlgorithm()
        {
            //greedy.RunGreedy(manager.ItemsToStore, knapsack);
            greedy.RunGreedyForMultiple(manager.ItemsToStore, knapsacks);
        }

        private void RunNeighborhoodSearch()
        {
            nbrdhd.NbrdhdSearch();
        }
    }
}






