using System;
using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting.Filling
{
    public class RandomFillStrategy : IFillStrategy
    {
        public void Fill(IList<int> list, int elementCount)
        {
            Random random = new Random();
            for (int i = 0; i < elementCount; i++)
            {
                list.Add(random.Next(1, elementCount));
            }
        }
    }
}
