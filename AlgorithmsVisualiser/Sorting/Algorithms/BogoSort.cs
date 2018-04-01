using System.Collections.Generic;
using System.Threading.Tasks;
using AlgorithmsVisualiser.Helpers;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public class BogoSort : SortAlgorithm
    {
        public BogoSort(SortView sortView) : base(sortView) { }

        public override string Name => "Bogo Sort";

        public async override void Sort(IList<int> list)
        {
            while (!IsSorted(list))
            {
                list.Shuffle();
                await Task.Delay(Delay);
                UpdateContainer(list);
            }
        }

        private bool IsSorted(IList<int> list)
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
