using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting.Filling
{
    public class AscendingFillStrategy : IFillStrategy
    {
        public void Fill(IList<int> list, int elementCount)
        {
            for (int i = 0; i < elementCount; i++)
            {
                list.Add(i + 1);
            }
        }
    }
}
