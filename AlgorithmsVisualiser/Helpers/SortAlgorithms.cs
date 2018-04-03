using AlgorithmsVisualiser.Sorting;
using AlgorithmsVisualiser.Sorting.Algorithms;
using System.Collections.Generic;

namespace AlgorithmsVisualiser.Helpers
{
    public static class SortAlgorithms
    {

        public static IList<SortAlgorithm> GetSortAlgorithms(SortView sortView)
        {
            return new List<SortAlgorithm>
            {
                new InsertionSort(sortView),
                new SelectionSort(sortView),
                new CountingSort(sortView),
                new BogoSort(sortView)
            };
        }
    }
}
