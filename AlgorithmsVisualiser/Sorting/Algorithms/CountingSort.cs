using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public class CountingSort : SortAlgorithm
    {

        private int previousCountIndex;
        public CountingSort(SortView sortView) : base(sortView) { }

        public override string Name => "Counting Sort";

        public async override void Sort(IList<int> list)
        {
            int[] output = new int[list.Count];
            int[] count = new int[list.Count + 1];
            int i;

            for(i = 0; i < list.Count; i++)
            {
                count[list[i]]++;
                CountFrequencyFor(i);
                await Wait();
            }

            for(i = 1; i < count.Length; i++)
            {

                count[i] += count[i - 1];
                CountFrequencyFor(i - 1);
                await Wait();
            }

            for(i = 0; i < list.Count; i++)
            {
                output[count[list[i]] - 1] = list[i];
                count[list[i]]--;
            }

            for(i = 0; i < list.Count; i++)
            {
                list[i] = output[i];
            }
            UpdateContainer(list);
        }

        private void CountFrequencyFor(int index)
        {
            ((Rectangle)sortView.Children[previousCountIndex]).Fill = new SolidColorBrush(Colours.Default);
            ((Rectangle)sortView.Children[index]).Fill = new SolidColorBrush(Colours.Blue);
            previousCountIndex = index;
        }
    }
}
