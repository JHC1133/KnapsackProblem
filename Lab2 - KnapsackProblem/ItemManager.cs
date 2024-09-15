using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___KnapsackProblem
{

    internal class ItemManager
    {
        Random rand;
        List<Item> itemsToStore;

        public List<Item> ItemsToStore { get => itemsToStore; set => itemsToStore = value; }

        public ItemManager()
        {
            rand = new Random();
        }

        public void SetNumberOfItems(int nrOfItems)
        {
            itemsToStore = new List<Item>();

            for (int i = 0; i < nrOfItems; i++)
            {
                Item item = new Item(GetRandomWeight(), GetRandomValue());
                itemsToStore.Add(item);
            }
        }

        public void PrintItems()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Items to store:");
            Console.WriteLine(" ");

            foreach (Item item in itemsToStore)
            {
                Console.WriteLine($"Item {item.ID}");
                Console.WriteLine($"Value: {item.Value} | Weight: {item.Weight} | Profit: {item.Profit}");
                Console.WriteLine("---------");
            }
        }

        private int GetRandomWeight()
        {
            return rand.Next(2, 5);
        }

        private int GetRandomValue()
        {
            return rand.Next(5, 30);
        }

    }
}
