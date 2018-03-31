using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting.Filling
{
    public class DescendingFillStrategy : IFillStrategy
    {
        public void Fill(IList<int> list, int elementCount)
        {
            for (int i = elementCount; i > 0; i--)
            {
                list.Add(i);
            }
        }
    }
}
