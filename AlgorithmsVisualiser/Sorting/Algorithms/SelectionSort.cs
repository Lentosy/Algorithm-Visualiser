using AlgorithmsVisualiser.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmsVisualiser.Sorting.Algorithms
{
    public class SelectionSort : SortAlgorithm
    {
        private int previousMaxIndex;

        public SelectionSort(SortView sortView) : base(sortView) { }

        public override string Name => "Selection Sort";

        public async override void Sort(IList<int> list)
        {
            for(int i = list.Count - 1; i > 0; i--)
            {
                int imax = i;
                SelectElement(i);

                for(int j = 0; j < i; j++)
                {
                    CompareElement(j);
                    if(list[j] > list[imax])
                    {
                        imax = j;
                        SelectMax(j);
                    }
                    await Task.Delay(Delay);
                }

                int temp = list[i];
                list[i] = list[imax];
                list[imax] = temp;
                UpdateContainer(list);
            }
        }

        private void SelectMax(int index)
        {
            ((Rectangle)sortView.Children[previousMaxIndex]).Fill = new SolidColorBrush(Colours.Green);
            ((Rectangle)sortView.Children[index]).Fill = new SolidColorBrush(Colours.Blue);
            previousMaxIndex = index;
        }
    }
}
