using AlgorithmsVisualiser.Sorting;
using AlgorithmsVisualiser.Sorting.Algorithms;
using System.Collections.Generic;

namespace AlgorithmsVisualiser.Helpers
{
    public static class SortAlgorithms
    {

        public static IList<SortAlgorithm> GetSortAlgorithms(SortView sortView)
        {
            List<SortAlgorithm> sortAlgorithms = new List<SortAlgorithm>
            {
                new InsertionSort(sortView),
                new SelectionSort(sortView),
                new CountingSort(sortView),
                new BogoSort(sortView)
            };
            return sortAlgorithms;
        }
    }

    /// <summary>
    /// This enum contains all the implemented algorithms
    /// </summary>
    public enum ESortingAlgorithm
    {
        INSERTION_SORT,
        SELECTION_SORT,
        COUNTING_SORT,
        BOGO_SORT
    }
}
