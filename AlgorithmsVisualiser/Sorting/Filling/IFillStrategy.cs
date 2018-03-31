using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting.Filling
{
    public interface IFillStrategy
    {
        void Fill(IList<int> list, int elementCount);
    }
}
