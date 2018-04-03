using AlgorithmsVisualiser.Sorting.Filling;
using System;
using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting
{
    public class SortList : List<int>
    {
        public void Fill(IFillStrategy fillStrategy, int elementCount)
        {
            fillStrategy.Fill(this, elementCount);
        }

        /// <summary>
        /// Fisher-Yates shuffle
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            int n = Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = this[k];
                this[k] = this[n];
                this[n] = value;
            }
        }
    }
}
