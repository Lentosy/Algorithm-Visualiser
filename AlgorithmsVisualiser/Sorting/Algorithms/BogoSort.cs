using System.Collections.Generic;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public class BogoSort : SortAlgorithm
    {
        public BogoSort(SortView sortView) : base(sortView) { }

        public override string Name => "Bogo Sort";

        public async override void Sort(SortList list)
        {
            while (!IsSorted(list))
            {
                list.Shuffle();
                await Wait();
                UpdateContainer(list);
            }
        }

        private bool IsSorted(SortList list)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                SelectElement(i + 1);
                CompareElement(i);
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
