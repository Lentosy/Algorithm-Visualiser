using AlgorithmsVisualiser.Sorting.Filling;
using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting
{
    public class SortList : List<int>
    {
        public void Fill(IFillStrategy fillStrategy, int elementCount)
        {
            fillStrategy.Fill(this, elementCount);
        }
    }
}
