using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___KnapsackProblem
{
    internal class Item
    {
        static int staticID = 1;
        int id;
        int weight;
        int value;
        int profit;

        public Item(int weight, int value)
        {
            id = staticID++;

            this.weight = weight;
            this.value = value;

            this.profit = value / weight;
        }

        public Item(Item item)
        {
            id = staticID++;
            this.weight = item.weight;
            this.value = item.value;
            this.profit = item.profit;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Item otherItem = (Item)obj;
            return this.ID == otherItem.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int ID { get => id; }
        public int Weight { get => weight; }
        public int Value { get => value; }
        public int Profit { get => profit; }
    }
}
